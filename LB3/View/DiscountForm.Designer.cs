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
            panelButtons = new Panel();
            buttonLoad = new Button();
            buttonSave = new Button();
            buttonSearch = new Button();
            buttonRemoveDiscount = new Button();
            buttonAddDiscount = new Button();
            colName = new DataGridViewTextBoxColumn();
            DiscountType = new DataGridViewTextBoxColumn();
            OriginPrice = new DataGridViewTextBoxColumn();
            DiscountValue = new DataGridViewTextBoxColumn();
            DiscountPrice = new DataGridViewTextBoxColumn();
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
            groupBoxDiscounts.Size = new Size(820, 340);
            groupBoxDiscounts.TabIndex = 0;
            groupBoxDiscounts.TabStop = false;
            groupBoxDiscounts.Text = "Список скидок";
            // 
            // dataGridViewDiscounts
            // 
            dataGridViewDiscounts.AllowUserToAddRows = false;
            dataGridViewDiscounts.AllowUserToDeleteRows = false;
            dataGridViewDiscounts.BorderStyle = BorderStyle.None;
            dataGridViewDiscounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiscounts.Columns.AddRange(new DataGridViewColumn[] { colName, DiscountType, OriginPrice, DiscountValue, DiscountPrice });
            dataGridViewDiscounts.Dock = DockStyle.Fill;
            dataGridViewDiscounts.Location = new Point(3, 18);
            dataGridViewDiscounts.Margin = new Padding(3, 2, 3, 2);
            dataGridViewDiscounts.Name = "dataGridViewDiscounts";
            dataGridViewDiscounts.ReadOnly = true;
            dataGridViewDiscounts.RowHeadersWidth = 51;
            dataGridViewDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDiscounts.Size = new Size(814, 320);
            dataGridViewDiscounts.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonLoad);
            panelButtons.Controls.Add(buttonSave);
            panelButtons.Controls.Add(buttonSearch);
            panelButtons.Controls.Add(buttonRemoveDiscount);
            panelButtons.Controls.Add(buttonAddDiscount);
            panelButtons.Location = new Point(3, 353);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(814, 51);
            panelButtons.TabIndex = 1;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(674, 16);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(131, 23);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += ButtonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(537, 16);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(131, 23);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(337, 16);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(131, 23);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Поиск";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // buttonRemoveDiscount
            // 
            buttonRemoveDiscount.Location = new Point(146, 16);
            buttonRemoveDiscount.Margin = new Padding(3, 2, 3, 2);
            buttonRemoveDiscount.Name = "buttonRemoveDiscount";
            buttonRemoveDiscount.Size = new Size(131, 22);
            buttonRemoveDiscount.TabIndex = 1;
            buttonRemoveDiscount.Text = "Удалить скидку";
            buttonRemoveDiscount.UseVisualStyleBackColor = true;
            buttonRemoveDiscount.Click += ButtonRemoveDiscount_Click;
            // 
            // buttonAddDiscount
            // 
            buttonAddDiscount.Location = new Point(9, 16);
            buttonAddDiscount.Margin = new Padding(3, 2, 3, 2);
            buttonAddDiscount.Name = "buttonAddDiscount";
            buttonAddDiscount.Size = new Size(131, 22);
            buttonAddDiscount.TabIndex = 0;
            buttonAddDiscount.Text = "Добавить скидку";
            buttonAddDiscount.UseVisualStyleBackColor = true;
            buttonAddDiscount.Click += ButtonAddDiscount_Click;
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
            OriginPrice.HeaderText = "Исходная цена, ₽";
            OriginPrice.MinimumWidth = 6;
            OriginPrice.Name = "OriginPrice";
            OriginPrice.ReadOnly = true;
            OriginPrice.Width = 150;
            // 
            // DiscountValue
            // 
            DiscountValue.DataPropertyName = "DiscountValueDisplay";
            DiscountValue.HeaderText = "Размер скидки, ₽";
            DiscountValue.MinimumWidth = 6;
            DiscountValue.Name = "DiscountValue";
            DiscountValue.ReadOnly = true;
            DiscountValue.Width = 150;
            // 
            // DiscountPrice
            // 
            DiscountPrice.DataPropertyName = "DiscountPrice";
            DiscountPrice.HeaderText = "Итоговая цена, ₽";
            DiscountPrice.MinimumWidth = 6;
            DiscountPrice.Name = "DiscountPrice";
            DiscountPrice.ReadOnly = true;
            DiscountPrice.Width = 150;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 415);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxDiscounts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "DiscountForm";
            Text = "Форма со списком скидок";
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
        private Button buttonSearch;
        private Button buttonLoad;
        private Button buttonSave;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn DiscountType;
        private DataGridViewTextBoxColumn OriginPrice;
        private DataGridViewTextBoxColumn DiscountValue;
        private DataGridViewTextBoxColumn DiscountPrice;
    }
}