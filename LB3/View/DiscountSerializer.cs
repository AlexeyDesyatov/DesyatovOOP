using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Var5;

namespace View
{
    /// <summary>
    /// Класс для сериализации/десериализации списка скидок
    /// </summary>
    public static class DiscountSerializer
    {
        /// <summary>
        /// Расширение файла для скидок
        /// </summary>
        private const string FileExtension = ".skd";

        /// <summary>
        /// Настройки JSON-сериализации
        /// </summary>
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true, 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };

        /// <summary>
        /// Сохранение списка скидок в файл
        /// </summary>
        /// <param name="discounts">Список скидок</param>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>True если успешно, иначе False</returns>
        public static bool Save(List<IDiscount> discounts, string filePath)
        {
            try
            {
                if (!filePath.EndsWith(FileExtension, StringComparison.OrdinalIgnoreCase))
                {
                    filePath += FileExtension;
                }
                var json = JsonSerializer.Serialize(discounts, _jsonOptions);
                File.WriteAllText(filePath, json, System.Text.Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Загрузка списка скидок из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Список скидок или пустой список при ошибке</returns>
        public static List<IDiscount> Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return new List<IDiscount>();
                }

                var json = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

                var discounts = JsonSerializer.Deserialize<List<IDiscount>>(json, _jsonOptions);

                return discounts ?? new List<IDiscount>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<IDiscount>();
            }
        }

        /// <summary>
        /// Диалог сохранения файла
        /// </summary>
        public static string ShowSaveDialog()
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Файл скидок|*.skd",
                DefaultExt = "skd",
                AddExtension = true,
                Title = "Сохранить список скидок"
            };

            return saveDialog.ShowDialog() == DialogResult.OK ? saveDialog.FileName : null;
        }

        /// <summary>
        /// Диалог открытия файла
        /// </summary>
        public static string ShowOpenDialog()
        {
            using var openDialog = new OpenFileDialog
            {
                Filter = "Файл скидок|*.skd",
                DefaultExt = "skd",
                AddExtension = true,
                Title = "Открыть список скидок",
                CheckFileExists = true
            };

            return openDialog.ShowDialog() == DialogResult.OK ? openDialog.FileName : null;
        }
    }
}