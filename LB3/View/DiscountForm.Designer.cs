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
            this.groupBoxDiscounts = new System.Windows.Forms.GroupBox();
            this.dataGridViewDiscounts = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.AddDiscount = new System.Windows.Forms.Button();
            this.RemoveDiscount = new System.Windows.Forms.Button();
            this.groupBoxDiscounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscounts)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDiscounts
            // 
            this.groupBoxDiscounts.Controls.Add(this.dataGridViewDiscounts);
            this.groupBoxDiscounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDiscounts.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDiscounts.Name = "groupBoxDiscounts";
            this.groupBoxDiscounts.Size = new System.Drawing.Size(800, 100);
            this.groupBoxDiscounts.TabIndex = 0;
            this.groupBoxDiscounts.TabStop = false;
            this.groupBoxDiscounts.Text = "Список скидок";
            this.groupBoxDiscounts.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridViewDiscounts
            // 
            this.dataGridViewDiscounts.AllowUserToAddRows = false;
            this.dataGridViewDiscounts.AllowUserToDeleteRows = false;
            this.dataGridViewDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDiscounts.Location = new System.Drawing.Point(3, 18);
            this.dataGridViewDiscounts.Name = "dataGridViewDiscounts";
            this.dataGridViewDiscounts.ReadOnly = true;
            this.dataGridViewDiscounts.RowHeadersWidth = 51;
            this.dataGridViewDiscounts.RowTemplate.Height = 24;
            this.dataGridViewDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDiscounts.Size = new System.Drawing.Size(794, 79);
            this.dataGridViewDiscounts.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.RemoveDiscount);
            this.panelButtons.Controls.Add(this.AddDiscount);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 350);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 100);
            this.panelButtons.TabIndex = 1;
            // 
            // AddDiscount
            // 
            this.AddDiscount.Location = new System.Drawing.Point(75, 35);
            this.AddDiscount.Name = "AddDiscount";
            this.AddDiscount.Size = new System.Drawing.Size(150, 30);
            this.AddDiscount.TabIndex = 0;
            this.AddDiscount.Text = "Добавить скидку";
            this.AddDiscount.UseVisualStyleBackColor = true;
            // 
            // RemoveDiscount
            // 
            this.RemoveDiscount.Location = new System.Drawing.Point(490, 35);
            this.RemoveDiscount.Name = "RemoveDiscount";
            this.RemoveDiscount.Size = new System.Drawing.Size(150, 30);
            this.RemoveDiscount.TabIndex = 1;
            this.RemoveDiscount.Text = "Удалить скидку";
            this.RemoveDiscount.UseVisualStyleBackColor = true;
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxDiscounts);
            this.Name = "DiscountForm";
            this.Text = "DiscountForm";
            this.groupBoxDiscounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscounts)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDiscounts;
        private System.Windows.Forms.DataGridView dataGridViewDiscounts;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button RemoveDiscount;
        private System.Windows.Forms.Button AddDiscount;
    }
}