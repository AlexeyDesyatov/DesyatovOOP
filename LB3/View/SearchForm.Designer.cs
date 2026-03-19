namespace View
{
    partial class SearchForm
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
            labelSearchField = new Label();
            comboBoxSearchField = new ComboBox();
            buttonSearch = new Button();
            dataGridViewResults = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            DiscountType = new DataGridViewTextBoxColumn();
            OriginPrice = new DataGridViewTextBoxColumn();
            DiscountValue = new DataGridViewTextBoxColumn();
            DiscountPrice = new DataGridViewTextBoxColumn();
            buttonClose = new Button();
            TextSearch = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // labelSearchField
            // 
            labelSearchField.Location = new Point(0, 0);
            labelSearchField.Name = "labelSearchField";
            labelSearchField.Size = new Size(100, 23);
            labelSearchField.TabIndex = 7;
            // 
            // comboBoxSearchField
            // 
            comboBoxSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSearchField.FormattingEnabled = true;
            comboBoxSearchField.Items.AddRange(new object[] { "Название скидки", "Тип скидки", "Исходная цена" });
            comboBoxSearchField.Location = new Point(129, 185);
            comboBoxSearchField.Margin = new Padding(3, 2, 3, 2);
            comboBoxSearchField.Name = "comboBoxSearchField";
            comboBoxSearchField.Size = new Size(133, 23);
            comboBoxSearchField.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(180, 224);
            buttonSearch.Margin = new Padding(3, 2, 3, 2);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(82, 22);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += ButtonSearch_Click;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { colName, DiscountType, OriginPrice, DiscountValue, DiscountPrice });
            dataGridViewResults.Location = new Point(10, 9);
            dataGridViewResults.Margin = new Padding(3, 2, 3, 2);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(687, 161);
            dataGridViewResults.TabIndex = 4;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Название";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 125;
            // 
            // DiscountType
            // 
            DiscountType.DataPropertyName = "DiscountType";
            DiscountType.HeaderText = "Тип скидки";
            DiscountType.MinimumWidth = 6;
            DiscountType.Name = "DiscountType";
            DiscountType.ReadOnly = true;
            DiscountType.Width = 125;
            // 
            // OriginPrice
            // 
            OriginPrice.DataPropertyName = "OriginPrice";
            OriginPrice.HeaderText = "Исходная цена";
            OriginPrice.MinimumWidth = 6;
            OriginPrice.Name = "OriginPrice";
            OriginPrice.ReadOnly = true;
            OriginPrice.Width = 125;
            // 
            // DiscountValue
            // 
            DiscountValue.DataPropertyName = "DiscountValue";
            DiscountValue.HeaderText = "Размер скидки";
            DiscountValue.MinimumWidth = 6;
            DiscountValue.Name = "DiscountValue";
            DiscountValue.ReadOnly = true;
            DiscountValue.Width = 125;
            // 
            // DiscountPrice
            // 
            DiscountPrice.DataPropertyName = "DiscountValue";
            DiscountPrice.HeaderText = "Итоговая цена";
            DiscountPrice.MinimumWidth = 6;
            DiscountPrice.Name = "DiscountPrice";
            DiscountPrice.ReadOnly = true;
            DiscountPrice.Width = 125;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(614, 224);
            buttonClose.Margin = new Padding(3, 2, 3, 2);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(82, 22);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += ButtonClose_Click;
            // 
            // TextSearch
            // 
            TextSearch.Location = new Point(10, 223);
            TextSearch.Name = "TextSearch";
            TextSearch.PlaceholderText = "Введите текст для поиска...";
            TextSearch.Size = new Size(157, 23);
            TextSearch.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 188);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 8;
            label1.Text = "Поиск по полю:";
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 263);
            Controls.Add(label1);
            Controls.Add(TextSearch);
            Controls.Add(buttonClose);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonSearch);
            Controls.Add(comboBoxSearchField);
            Controls.Add(labelSearchField);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "SearchForm";
            Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSearchField;
        private ComboBox comboBoxSearchField;
        private Button buttonSearch;
        private DataGridView dataGridViewResults;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn DiscountType;
        private DataGridViewTextBoxColumn OriginPrice;
        private DataGridViewTextBoxColumn DiscountValue;
        private DataGridViewTextBoxColumn DiscountPrice;
        private Button buttonClose;
        private TextBox TextSearch;
        private Label label1;
    }
}