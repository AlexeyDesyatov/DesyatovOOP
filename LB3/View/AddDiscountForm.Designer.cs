namespace View
{
    partial class AddDiscountForm
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
            groupBoxCommon = new GroupBox();
            textOriginPrice = new MaskedTextBox();
            textName = new MaskedTextBox();
            labelPrice = new Label();
            labelName = new Label();
            groupBoxType = new GroupBox();
            radioButtonCertificate = new RadioButton();
            radioButtonPercent = new RadioButton();
            panelPercent = new Panel();
            textPercent = new MaskedTextBox();
            labelPercent = new Label();
            panelCertificate = new Panel();
            textAmount = new MaskedTextBox();
            labelAmount = new Label();
            buttonOK = new Button();
            buttonCancel = new Button();
            buttonRandomData = new Button();
            groupBoxCommon.SuspendLayout();
            groupBoxType.SuspendLayout();
            panelPercent.SuspendLayout();
            panelCertificate.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxCommon
            // 
            groupBoxCommon.Controls.Add(textOriginPrice);
            groupBoxCommon.Controls.Add(textName);
            groupBoxCommon.Controls.Add(labelPrice);
            groupBoxCommon.Controls.Add(labelName);
            groupBoxCommon.Location = new Point(148, 12);
            groupBoxCommon.Name = "groupBoxCommon";
            groupBoxCommon.Size = new Size(485, 125);
            groupBoxCommon.TabIndex = 0;
            groupBoxCommon.TabStop = false;
            groupBoxCommon.Text = "Общие параметры";
            // 
            // textOriginPrice
            // 
            textOriginPrice.AllowPromptAsInput = false;
            textOriginPrice.Location = new Point(314, 82);
            textOriginPrice.Mask = "99999999999999999999";
            textOriginPrice.Name = "textOriginPrice";
            textOriginPrice.Size = new Size(125, 27);
            textOriginPrice.TabIndex = 3;
            // 
            // textName
            // 
            textName.CutCopyMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            textName.Location = new Point(87, 79);
            textName.Mask = "LLLLLLLLLLLLLLLLLLL";
            textName.Name = "textName";
            textName.Size = new Size(125, 27);
            textName.TabIndex = 2;
            textName.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(334, 36);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(114, 20);
            labelPrice.TabIndex = 1;
            labelPrice.Text = "Исходная цена";
            labelPrice.Click += labelPrice_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(44, 36);
            labelName.Name = "labelName";
            labelName.Size = new Size(128, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Название скидки";
            // 
            // groupBoxType
            // 
            groupBoxType.Controls.Add(radioButtonCertificate);
            groupBoxType.Controls.Add(radioButtonPercent);
            groupBoxType.Location = new Point(148, 143);
            groupBoxType.Name = "groupBoxType";
            groupBoxType.Size = new Size(485, 100);
            groupBoxType.TabIndex = 1;
            groupBoxType.TabStop = false;
            groupBoxType.Text = "Тип скидки";
            // 
            // radioButtonCertificate
            // 
            radioButtonCertificate.AutoSize = true;
            radioButtonCertificate.Location = new Point(314, 50);
            radioButtonCertificate.Name = "radioButtonCertificate";
            radioButtonCertificate.Size = new Size(140, 24);
            radioButtonCertificate.TabIndex = 1;
            radioButtonCertificate.TabStop = true;
            radioButtonCertificate.Text = "По сертификату";
            radioButtonCertificate.UseVisualStyleBackColor = true;
            // 
            // radioButtonPercent
            // 
            radioButtonPercent.AutoSize = true;
            radioButtonPercent.Location = new Point(87, 50);
            radioButtonPercent.Name = "radioButtonPercent";
            radioButtonPercent.Size = new Size(116, 24);
            radioButtonPercent.TabIndex = 0;
            radioButtonPercent.Text = "Процентная";
            radioButtonPercent.UseVisualStyleBackColor = true;
            // 
            // panelPercent
            // 
            panelPercent.Controls.Add(textPercent);
            panelPercent.Controls.Add(labelPercent);
            panelPercent.Location = new Point(148, 245);
            panelPercent.Name = "panelPercent";
            panelPercent.Size = new Size(225, 125);
            panelPercent.TabIndex = 2;
            panelPercent.Visible = false;
            // 
            // textPercent
            // 
            textPercent.AllowPromptAsInput = false;
            textPercent.Location = new Point(72, 69);
            textPercent.Mask = "99";
            textPercent.Name = "textPercent";
            textPercent.Size = new Size(125, 27);
            textPercent.TabIndex = 1;
            // 
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Location = new Point(53, 30);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(125, 20);
            labelPercent.TabIndex = 0;
            labelPercent.Text = "Процент (0-100):";
            // 
            // panelCertificate
            // 
            panelCertificate.Controls.Add(textAmount);
            panelCertificate.Controls.Add(labelAmount);
            panelCertificate.Location = new Point(392, 245);
            panelCertificate.Name = "panelCertificate";
            panelCertificate.Size = new Size(241, 125);
            panelCertificate.TabIndex = 3;
            panelCertificate.Visible = false;
            // 
            // textAmount
            // 
            textAmount.AllowPromptAsInput = false;
            textAmount.Location = new Point(55, 69);
            textAmount.Mask = "9999999999999999999";
            textAmount.Name = "textAmount";
            textAmount.Size = new Size(125, 27);
            textAmount.TabIndex = 1;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(46, 39);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(146, 20);
            labelAmount.TabIndex = 0;
            labelAmount.Text = "Сумма сертификата";
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(148, 376);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(94, 29);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(539, 376);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonRandomData
            // 
            buttonRandomData.Location = new Point(301, 409);
            buttonRandomData.Name = "buttonRandomData";
            buttonRandomData.Size = new Size(158, 29);
            buttonRandomData.TabIndex = 6;
            buttonRandomData.Text = "Случайные данные";
            buttonRandomData.UseVisualStyleBackColor = true;
            buttonRandomData.Click += buttonRandomData_Click;
            // 
            // AddDiscountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonRandomData);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(panelCertificate);
            Controls.Add(panelPercent);
            Controls.Add(groupBoxType);
            Controls.Add(groupBoxCommon);
            Name = "AddDiscountForm";
            Text = "AddDiscountForm";
            groupBoxCommon.ResumeLayout(false);
            groupBoxCommon.PerformLayout();
            groupBoxType.ResumeLayout(false);
            groupBoxType.PerformLayout();
            panelPercent.ResumeLayout(false);
            panelPercent.PerformLayout();
            panelCertificate.ResumeLayout(false);
            panelCertificate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxCommon;
        private Label labelName;
        private Label labelPrice;
        private GroupBox groupBoxType;
        private MaskedTextBox textName;
        private MaskedTextBox textOriginPrice;
        private RadioButton radioButtonCertificate;
        private RadioButton radioButtonPercent;
        private Panel panelPercent;
        private MaskedTextBox textPercent;
        private Label labelPercent;
        private Panel panelCertificate;
        private MaskedTextBox textAmount;
        private Label labelAmount;
        private Button buttonOK;
        private Button buttonCancel;
        private Button buttonRandomData;
    }
}