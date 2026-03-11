namespace View
{
    partial class DiscountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxDiscounts = new GroupBox();
            dataGridViewDiscounts = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            DiscountType = new DataGridViewTextBoxColumn();
            OriginPrice = new DataGridViewTextBoxColumn();
            DiscountValue = new DataGridViewTextBoxColumn();
            DiscountPrice = new DataGridViewTextBoxColumn();
            panelButtons = new Panel();
            buttonSearch = new Button();
            buttonRemoveDiscount = new Button();
            buttonAddDiscount = new Button();
            groupBoxDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiscounts).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxDiscounts
            // 
            groupBoxDiscounts.Controls.Add(dataGridViewDiscounts);
            groupBoxDiscounts.Dock = DockStyle.Top;
            groupBoxDiscounts.Location = new Point(0, 0);
            groupBoxDiscounts.Margin = new Padding(3, 2, 3, 2);
            groupBoxDiscounts.Name = "groupBoxDiscounts";
            groupBoxDiscounts.Padding = new Padding(3, 2, 3, 2);
            groupBoxDiscounts.Size = new Size(700, 150);
            groupBoxDiscounts.TabIndex = 0;
            groupBoxDiscounts.TabStop = false;
            groupBoxDiscounts.Text = "Список скидок";
            // 
            // dataGridViewDiscounts
            // 
            dataGridViewDiscounts.AllowUserToAddRows = false;
            dataGridViewDiscounts.AllowUserToDeleteRows = false;
            dataGridViewDiscounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiscounts.Columns.AddRange(new DataGridViewColumn[] { colName, DiscountType, OriginPrice, DiscountValue, DiscountPrice });
            dataGridViewDiscounts.Dock = DockStyle.Fill;
            dataGridViewDiscounts.Location = new Point(3, 18);
            dataGridViewDiscounts.Margin = new Padding(3, 2, 3, 2);
            dataGridViewDiscounts.Name = "dataGridViewDiscounts";
            dataGridViewDiscounts.ReadOnly = true;
            dataGridViewDiscounts.RowHeadersWidth = 51;
            dataGridViewDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDiscounts.Size = new Size(694, 130);
            dataGridViewDiscounts.TabIndex = 0;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Название скидки";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 160;
            // 
            // DiscountType
            // 
            DiscountType.DataPropertyName = "DiscountType";
            DiscountType.HeaderText = "Тип скидки";
            DiscountType.MinimumWidth = 6;
            DiscountType.Name = "DiscountType";
            DiscountType.ReadOnly = true;
            DiscountType.Width = 150;
            // 
            // OriginPrice
            // 
            OriginPrice.DataPropertyName = "OriginPrice";
            OriginPrice.HeaderText = "Исходная цена";
            OriginPrice.MinimumWidth = 6;
            OriginPrice.Name = "OriginPrice";
            OriginPrice.ReadOnly = true;
            OriginPrice.Width = 150;
            // 
            // DiscountValue
            // 
            DiscountValue.DataPropertyName = "DiscountValue";
            DiscountValue.HeaderText = "Размер скидки";
            DiscountValue.MinimumWidth = 6;
            DiscountValue.Name = "DiscountValue";
            DiscountValue.ReadOnly = true;
            DiscountValue.Width = 150;
            // 
            // DiscountPrice
            // 
            DiscountPrice.DataPropertyName = "DiscountPrice";
            DiscountPrice.HeaderText = "Итоговая цена";
            DiscountPrice.MinimumWidth = 6;
            DiscountPrice.Name = "DiscountPrice";
            DiscountPrice.ReadOnly = true;
            DiscountPrice.Width = 150;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonSearch);
            panelButtons.Controls.Add(buttonRemoveDiscount);
            panelButtons.Controls.Add(buttonAddDiscount);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 244);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(700, 94);
            panelButtons.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(613, 44);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonRemoveDiscount
            // 
            buttonRemoveDiscount.Location = new Point(416, 44);
            buttonRemoveDiscount.Margin = new Padding(3, 2, 3, 2);
            buttonRemoveDiscount.Name = "buttonRemoveDiscount";
            buttonRemoveDiscount.Size = new Size(131, 22);
            buttonRemoveDiscount.TabIndex = 1;
            buttonRemoveDiscount.Text = "Удалить скидку";
            buttonRemoveDiscount.UseVisualStyleBackColor = true;
            buttonRemoveDiscount.Click += buttonRemoveDiscount_Click;
            // 
            // buttonAddDiscount
            // 
            buttonAddDiscount.Location = new Point(60, 44);
            buttonAddDiscount.Margin = new Padding(3, 2, 3, 2);
            buttonAddDiscount.Name = "buttonAddDiscount";
            buttonAddDiscount.Size = new Size(131, 22);
            buttonAddDiscount.TabIndex = 0;
            buttonAddDiscount.Text = "Добавить скидку";
            buttonAddDiscount.UseVisualStyleBackColor = true;
            buttonAddDiscount.Click += buttonAddDiscount_Click;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxDiscounts);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DiscountForm";
            Text = "DiscountForm";
            Load += DiscountForm_Load;
            groupBoxDiscounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiscounts).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxDiscounts;
        private DataGridView dataGridViewDiscounts;
        private Panel panelButtons;
        private Button buttonRemoveDiscount;
        private Button buttonAddDiscount;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn DiscountType;
        private DataGridViewTextBoxColumn OriginPrice;
        private DataGridViewTextBoxColumn DiscountValue;
        private DataGridViewTextBoxColumn DiscountPrice;
        private Button buttonSearch;
    }
}