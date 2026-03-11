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
    public partial class SearchForm : Form
    {
        private List<IDiscount> _allDiscounts;

        public SearchForm(List<IDiscount> discounts)
        {
            InitializeComponent();
            _allDiscounts = discounts;
            SetupSearchForm();
        }

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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = TextSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введите текст для поиска.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextSearch.Focus();
                return;
            }

            List<IDiscount> results = new List<IDiscount>();
            string selectedField = comboBoxSearchField.SelectedItem?.ToString();

            switch (selectedField)
            {
                case "Название скидки":
                    results = _allDiscounts
                        .Where(d => d.Name.Contains(searchText,
                            StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;

                case "Тип скидки":
                    results = _allDiscounts
                        .Where(d => d.DiscountType.Contains(searchText,
                            StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    break;

                case "Исходная цена":
                    results = _allDiscounts
                        .Where(d => d.OriginPrice.ToString().Contains(searchText))
                        .ToList();
                    break;
            }
            dataGridViewResults.DataSource = null;
            dataGridViewResults.DataSource = results;

            string resultMessage = results.Count > 0
                ? $"Найдено: {results.Count}"
                : "Ничего не найдено";

            this.Text = $"Поиск - {resultMessage}";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}