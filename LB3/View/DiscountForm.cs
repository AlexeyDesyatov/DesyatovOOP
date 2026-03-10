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
    }
}