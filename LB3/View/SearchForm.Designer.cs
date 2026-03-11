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
            TextSearch = new MaskedTextBox();
            buttonSearch = new Button();
            dataGridViewResults = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            DiscountType = new DataGridViewTextBoxColumn();
            OriginPrice = new DataGridViewTextBoxColumn();
            DiscountValue = new DataGridViewTextBoxColumn();
            DiscountPrice = new DataGridViewTextBoxColumn();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            // 
            // labelSearchField
            // 
            labelSearchField.AutoSize = true;
            labelSearchField.Location = new Point(142, 192);
            labelSearchField.Name = "labelSearchField";
            labelSearchField.Size = new Size(119, 20);
            labelSearchField.TabIndex = 0;
            labelSearchField.Text = "Поиск по полю:";
            // 
            // comboBoxSearchField
            // 
            comboBoxSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSearchField.FormattingEnabled = true;
            comboBoxSearchField.Items.AddRange(new object[] { "Название скидки", "Тип скидки", "Исходная цена" });
            comboBoxSearchField.Location = new Point(305, 189);
            comboBoxSearchField.Name = "comboBoxSearchField";
            comboBoxSearchField.Size = new Size(151, 28);
            comboBoxSearchField.TabIndex = 1;
            // 
            // TextSearch
            // 
            TextSearch.Location = new Point(142, 254);
            TextSearch.Name = "TextSearch";
            TextSearch.Size = new Size(199, 27);
            TextSearch.TabIndex = 2;
            TextSearch.Text = "Введите текст для поиска...";
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(362, 254);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 29);
            buttonSearch.TabIndex = 3;
            buttonSearch.Text = "Найти";
            buttonSearch.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResults
            // 
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { colName, DiscountType, OriginPrice, DiscountValue, DiscountPrice });
            dataGridViewResults.Location = new Point(40, 12);
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersWidth = 51;
            dataGridViewResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewResults.Size = new Size(719, 141);
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
            buttonClose.Location = new Point(665, 392);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 5;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonClose);
            Controls.Add(dataGridViewResults);
            Controls.Add(buttonSearch);
            Controls.Add(TextSearch);
            Controls.Add(comboBoxSearchField);
            Controls.Add(labelSearchField);
            Name = "SearchForm";
            Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSearchField;
        private ComboBox comboBoxSearchField;
        private MaskedTextBox TextSearch;
        private Button buttonSearch;
        private DataGridView dataGridViewResults;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn DiscountType;
        private DataGridViewTextBoxColumn OriginPrice;
        private DataGridViewTextBoxColumn DiscountValue;
        private DataGridViewTextBoxColumn DiscountPrice;
        private Button buttonClose;
    }
}