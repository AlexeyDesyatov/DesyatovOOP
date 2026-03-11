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
        /// 
        /// </summary>
        private void SetupSearchForm()
        {
            comboBoxSearchField.Items.AddRange(new string[]
            {
                "Название скидки",
                "Тип скидки",
                "Исходная цена"
            });
            comboBoxSearchField.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="IncorrectArgumentException"></exception>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!FieldValidation.TryValidate(() =>
            {
                if (string.IsNullOrWhiteSpace(TextSearch.Text.Trim()))
                    throw new IncorrectArgumentException("Введите текст для поиска.");
            },
            "Текст поиска", TextSearch))
            {
                return;
            }

            string selectedField = comboBoxSearchField.SelectedItem?.ToString();
            string searchText = TextSearch.Text.Trim();

            var searchFunctions = new Dictionary<string, Func<List<IDiscount>>>
            {
                { "Название скидки", () => _allDiscounts
                    .Where(d => d?.Name?.Contains(searchText,
                        StringComparison.OrdinalIgnoreCase) == true).ToList() },

                { "Тип скидки", () => _allDiscounts
                    .Where(d => d?.DiscountType?.Contains(searchText,
                        StringComparison.OrdinalIgnoreCase) == true).ToList() },

                { "Исходная цена", () => _allDiscounts
                    .Where(d => d?.OriginPrice.ToString()
                        .Contains(searchText, StringComparison.OrdinalIgnoreCase) == true).ToList() }
            };

            var results = searchFunctions.TryGetValue(selectedField, out var func)
                ? func()
                : new List<IDiscount>();

            dataGridViewResults.DataSource = null;
            dataGridViewResults.DataSource = results;

            this.Text = $"Поиск - {(results.Count > 0 ? $"Найдено: {results.Count}" : "Ничего не найдено")}";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}