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
            groupBoxDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDiscounts).BeginInit();
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
            panelButtons.Location = new Point(272, 313);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(250, 125);
            panelButtons.TabIndex = 1;
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
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxDiscounts;
        private DataGridView dataGridViewDiscounts;
        private Panel panelButtons;
    }
}