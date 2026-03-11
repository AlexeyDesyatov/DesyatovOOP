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
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventarg"></param>
        private void DiscountForm_Load(object sender, EventArgs eventarg)
        {
        }
    }
}