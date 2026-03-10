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

            dataGridViewDiscounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Название скидки",
                DataPropertyName = "Name",
                Width = 200
            });

            dataGridViewDiscounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountType",
                HeaderText = "Тип скидки",
                DataPropertyName = "DiscountType",
                Width = 150
            });

            dataGridViewDiscounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OriginPrice",
                HeaderText = "Исходная цена",
                DataPropertyName = "OriginPrice",
                Width = 120
            });

            dataGridViewDiscounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountValue",
                HeaderText = "Размер скидки",
                DataPropertyName = "DiscountValue",
                Width = 120
            });

            dataGridViewDiscounts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DiscountPrice",
                HeaderText = "Итоговая цена",
                DataPropertyName = "DiscountPrice",
                Width = 120
            });
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
                _discounts.Add(addForm.NewDiscount);

                dataGridViewDiscounts.DataSource = null;
                dataGridViewDiscounts.DataSource = _discounts;
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
    }
}