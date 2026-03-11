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
    public partial class DiscountForm : Form
    {
        private List<IDiscount> _discounts = new List<IDiscount>();

        public DiscountForm()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridViewDiscounts.AutoGenerateColumns = false;

            dataGridViewDiscounts.AutoGenerateColumns = false;
            dataGridViewDiscounts.ReadOnly = true;
            dataGridViewDiscounts.AllowUserToAddRows = false;
            dataGridViewDiscounts.AllowUserToDeleteRows = false;
            dataGridViewDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// Кнопка добавить скидку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddDiscount_Click(object sender, EventArgs e)
        {
            var addForm = new AddDiscountForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                if (addForm.NewDiscount == null)
                {
                    MessageBox.Show("Ошибка: скидка не была создана!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _discounts.Add(addForm.NewDiscount);
                var newDiscount = addForm.NewDiscount;
                MessageBox.Show(
                    $"Добавлена скидка:\n" +
                    $"Name: {newDiscount.Name}\n" +
                    $"Type: {newDiscount.DiscountType}\n" +
                    $"Price: {newDiscount.OriginPrice}\n" +
                    $"Value: {newDiscount.DiscountValue}\n" +
                    $"DiscountPrice: {newDiscount.DiscountPrice}\n\n" +
                    $"Всего скидок в списке: {_discounts.Count + 1}"
                );
                dataGridViewDiscounts.DataSource = null;
                dataGridViewDiscounts.DataSource = _discounts;
                MessageBox.Show(
                   $"Колонок в DataGridView: {dataGridViewDiscounts.Columns.Count}\n" +
                   $"Строк в DataGridView: {dataGridViewDiscounts.Rows.Count}\n" +
                   $"Items в списке: {_discounts.Count}"
               );
            }
        }
        /// <summary>
        /// Кнопка удалить скидку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveDiscount_Click(object sender, EventArgs e)
        {
            if (dataGridViewDiscounts.SelectedRows.Count > 0)
            {
                var selectedDiscount = (IDiscount)dataGridViewDiscounts.SelectedRows[0].DataBoundItem;
                _discounts.Remove(selectedDiscount);

                dataGridViewDiscounts.DataSource = null;
                dataGridViewDiscounts.DataSource = _discounts;
            }
            else
            {
                MessageBox.Show("Выберите скидку для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DiscountForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm(_discounts);
            searchForm.ShowDialog();
        }
    }
}