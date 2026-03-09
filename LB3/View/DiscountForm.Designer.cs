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
            buttonAddDiscount = new Button();
            buttonRemoveDiscount = new Button();
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
            groupBoxDiscounts.Name = "groupBoxDiscounts";
            groupBoxDiscounts.Size = new Size(800, 200);
            groupBoxDiscounts.TabIndex = 0;
            groupBoxDiscounts.TabStop = false;
            groupBoxDiscounts.Text = "Список скидок";
            // 
            // dataGridViewDiscounts
            // 
            dataGridViewDiscounts.AllowUserToAddRows = false;
            dataGridViewDiscounts.AllowUserToDeleteRows = false;
            dataGridViewDiscounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDiscounts.Dock = DockStyle.Fill;
            dataGridViewDiscounts.Location = new Point(3, 23);
            dataGridViewDiscounts.Name = "dataGridViewDiscounts";
            dataGridViewDiscounts.ReadOnly = true;
            dataGridViewDiscounts.RowHeadersWidth = 51;
            dataGridViewDiscounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDiscounts.Size = new Size(794, 174);
            dataGridViewDiscounts.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonRemoveDiscount);
            panelButtons.Controls.Add(buttonAddDiscount);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 325);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(800, 125);
            panelButtons.TabIndex = 1;
            // 
            // buttonAddDiscount
            // 
            buttonAddDiscount.Location = new Point(68, 58);
            buttonAddDiscount.Name = "buttonAddDiscount";
            buttonAddDiscount.Size = new Size(150, 30);
            buttonAddDiscount.TabIndex = 0;
            buttonAddDiscount.Text = "Добавить скидку";
            buttonAddDiscount.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveDiscount
            // 
            buttonRemoveDiscount.Location = new Point(476, 58);
            buttonRemoveDiscount.Name = "buttonRemoveDiscount";
            buttonRemoveDiscount.Size = new Size(150, 30);
            buttonRemoveDiscount.TabIndex = 1;
            buttonRemoveDiscount.Text = "Удалить скидку";
            buttonRemoveDiscount.UseVisualStyleBackColor = true;
            // 
            // DiscountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxDiscounts);
            Name = "DiscountForm";
            Text = "DiscountForm";
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
    }
}