using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Var5;

namespace View
{
    /// <summary>
    /// Статический класс для сериализации и десериализации
    /// списка скидок в/из JSON-формата.
    /// </summary>
    public static class DiscountSerializer
    {
        /// <summary>
        /// Параметры сериализации и десериализации
        /// </summary>
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        /// Сохраняет список скидок
        /// </summary>
        /// <param name="discounts">Список скидок.</param>
        /// <param name="path">Путь к файлу.</param>
        public static void Save(IEnumerable<IDiscount> discounts, string path) =>
            File.WriteAllText(path, JsonSerializer.Serialize(discounts, _jsonOptions));

        /// <summary>
        /// Загружает список скидок из файла
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Список загруженных скидок.</returns>
        public static List<IDiscount> Load(string path) =>
            JsonSerializer.Deserialize<List<IDiscount>>(
                File.ReadAllText(path), _jsonOptions)
            ?? throw new JsonException(
                "Не удалось десериализовать список скидок.");
    }
}