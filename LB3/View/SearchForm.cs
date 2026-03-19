using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Var5;

namespace View
{
    /// <summary>
    /// Форма поиска скидок
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Список скидок
        /// </summary>
        private readonly List<IDiscount> _allDiscounts;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="discounts"></param>
        public SearchForm(List<IDiscount> discounts)
        {
            InitializeComponent();
            _allDiscounts = discounts;
            SetupSearchForm();
        }

        /// <summary>
        /// Настройка элементов формы
        /// </summary>
        private void SetupSearchForm()
        {
            comboBoxSearchField.SelectedIndex = 0;
            dataGridViewResults.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Обновление результатов
        /// </summary>
        private void RefreshResults(List<IDiscount> results)
        {
            dataGridViewResults.DataSource = null;
            dataGridViewResults.DataSource = results;
            this.Text = $"Поиск - {(results.Count > 0 ?
                $"Найдено: {results.Count}" : "Ничего не найдено")}";
        }

        /// <summary>
        /// Кнопка поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="IncorrectArgumentException"></exception>
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (!FieldValidation.TryValidate(() =>
            {
                if (string.IsNullOrWhiteSpace(TextSearch.Text.Trim()))
                {
                    throw new IncorrectArgumentException("Введите" +
                        " текст для поиска.");
                }
            },
            "Текст поиска", TextSearch))
            {
                return;
            }

            string selectedField = comboBoxSearchField.SelectedItem?.ToString();
            string searchText = TextSearch.Text.Trim();

            var searchFunctions = new Dictionary<string, Func<List<IDiscount>>>
            {
                {
                    "Название скидки",
                    () => _allDiscounts.Where(
                        discount => discount?.Name?.Contains(
                            searchText,
                            StringComparison.OrdinalIgnoreCase) == true)
                    .ToList()
                },

                { "Тип скидки", () => _allDiscounts
                    .Where(discount => discount?.DiscountType?.Contains(
                        searchText,
                        StringComparison.OrdinalIgnoreCase) == true).ToList()},

                { "Исходная цена", () => _allDiscounts
                    .Where(discount => discount?.OriginPrice.ToString()
                        .Contains(searchText,
                        StringComparison.OrdinalIgnoreCase) == true).ToList()}
            };

            var results = searchFunctions.TryGetValue(selectedField,
                    out var searchFunc)
                ? searchFunc()
                : new List<IDiscount>();

            RefreshResults(results);
        }

        /// <summary>
        /// Кнопка завершения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e) => Close();

    }
}