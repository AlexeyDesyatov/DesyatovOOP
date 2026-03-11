using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Var5;  

namespace View
{
    /// <summary>
    /// Форма управления списком скидок
    /// </summary>
    public partial class DiscountForm : Form
    {
        /// <summary>
        /// Список объектов
        /// </summary>
        private List<IDiscount> _discounts = new List<IDiscount>();

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public DiscountForm()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        /// <summary>
        /// Насткройка колонки
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridViewDiscounts.AutoGenerateColumns = false;
            dataGridViewDiscounts.ReadOnly = true;
            dataGridViewDiscounts.AllowUserToAddRows = false;
            dataGridViewDiscounts.AllowUserToDeleteRows = false;
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void RefreshDataGridView()
        {
            dataGridViewDiscounts.DataSource = null;
            dataGridViewDiscounts.DataSource = _discounts;
        }

        /// <summary>
        /// Кнопка добавить скидку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventarg"></param>
        private void buttonAddDiscount_Click(object sender,
                EventArgs eventarg)
        {
            var addForm = new AddDiscountForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _discounts.Add(addForm.NewDiscount);
                RefreshDataGridView();
            }
        }

        /// <summary>
        /// Кнопка удалить скидку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventarg"></param>
        private void buttonRemoveDiscount_Click(object sender,
            EventArgs eventarg)
        {
            if (dataGridViewDiscounts.SelectedRows.Count > 0)
            {
                var selectedDiscount = 
                    (IDiscount)dataGridViewDiscounts.SelectedRows[0].DataBoundItem;
                _discounts.Remove(selectedDiscount);
                RefreshDataGridView();
            }
            else
            {
                MessageBox.Show("Выберите скидку для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Кнопка поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventarg"></param>
        private void buttonSearch_Click(object sender, EventArgs eventarg)
        {
            var searchForm = new SearchForm(_discounts);
            searchForm.ShowDialog();
        }

        /// <summary>
        /// Кнопка Сохранить
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_discounts.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string filePath = DiscountSerializer.ShowSaveDialog();
            if (!string.IsNullOrEmpty(filePath) && DiscountSerializer.Save(
                _discounts, filePath))
            {
                MessageBox.Show($"Данные успешно сохранены в:\n{filePath}",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Кнопка Загрузить
        /// </summary>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (_discounts.Count > 0)
            {
                var result = MessageBox.Show(
                    "Текущий список будет заменён. Продолжить?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }

            string filePath = DiscountSerializer.ShowOpenDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                _discounts = DiscountSerializer.Load(filePath);
                RefreshDataGridView();
                MessageBox.Show($"Загружено {_discounts.Count} скидок.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventarg"></param>
        private void DiscountForm_Load(object sender, EventArgs eventarg)
        {
        }
    }
}