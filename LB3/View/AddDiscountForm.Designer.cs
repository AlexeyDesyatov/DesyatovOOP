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
            textOriginPrice = new TextBox();
            label1 = new Label();
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
            groupBoxCommon.Controls.Add(label1);
            groupBoxCommon.Controls.Add(textName);
            groupBoxCommon.Controls.Add(labelPrice);
            groupBoxCommon.Controls.Add(labelName);
            groupBoxCommon.Location = new Point(12, 11);
            groupBoxCommon.Margin = new Padding(3, 2, 3, 2);
            groupBoxCommon.Name = "groupBoxCommon";
            groupBoxCommon.Padding = new Padding(3, 2, 3, 2);
            groupBoxCommon.Size = new Size(250, 97);
            groupBoxCommon.TabIndex = 0;
            groupBoxCommon.TabStop = false;
            groupBoxCommon.Text = "Общие параметры";
            // 
            // textOriginPrice
            // 
            textOriginPrice.Location = new Point(134, 63);
            textOriginPrice.MaxLength = 10;
            textOriginPrice.Name = "textOriginPrice";
            textOriginPrice.Size = new Size(39, 23);
            textOriginPrice.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 66);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 6;
            label1.Text = "Исходная цена:";
            // 
            // textName
            // 
            textName.Location = new Point(134, 22);
            textName.Name = "textName";
            textName.Size = new Size(110, 23);
            textName.TabIndex = 1;
            // 
            // labelPrice
            // 
            labelPrice.Location = new Point(7, 44);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(145, 50);
            labelPrice.TabIndex = 5;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(11, 27);
            labelName.Name = "labelName";
            labelName.Size = new Size(103, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название скидки:";
            // 
            // groupBoxType
            // 
            groupBoxType.Controls.Add(radioButtonCertificate);
            groupBoxType.Controls.Add(radioButtonPercent);
            groupBoxType.Location = new Point(12, 111);
            groupBoxType.Margin = new Padding(3, 2, 3, 2);
            groupBoxType.Name = "groupBoxType";
            groupBoxType.Padding = new Padding(3, 2, 3, 2);
            groupBoxType.Size = new Size(250, 75);
            groupBoxType.TabIndex = 1;
            groupBoxType.TabStop = false;
            groupBoxType.Text = "Тип скидки";
            // 
            // radioButtonCertificate
            // 
            radioButtonCertificate.AutoSize = true;
            radioButtonCertificate.Location = new Point(9, 43);
            radioButtonCertificate.Margin = new Padding(3, 2, 3, 2);
            radioButtonCertificate.Name = "radioButtonCertificate";
            radioButtonCertificate.Size = new Size(114, 19);
            radioButtonCertificate.TabIndex = 4;
            radioButtonCertificate.TabStop = true;
            radioButtonCertificate.Text = "По сертификату";
            radioButtonCertificate.UseVisualStyleBackColor = true;
            // 
            // radioButtonPercent
            // 
            radioButtonPercent.AutoSize = true;
            radioButtonPercent.Location = new Point(9, 20);
            radioButtonPercent.Margin = new Padding(3, 2, 3, 2);
            radioButtonPercent.Name = "radioButtonPercent";
            radioButtonPercent.Size = new Size(92, 19);
            radioButtonPercent.TabIndex = 3;
            radioButtonPercent.Text = "Процентная";
            radioButtonPercent.UseVisualStyleBackColor = true;
            // 
            // panelPercent
            // 
            panelPercent.Controls.Add(textPercent);
            panelPercent.Controls.Add(labelPercent);
            panelPercent.Location = new Point(12, 187);
            panelPercent.Margin = new Padding(3, 2, 3, 2);
            panelPercent.Name = "panelPercent";
            panelPercent.Size = new Size(250, 51);
            panelPercent.TabIndex = 2;
            panelPercent.Visible = false;
            // 
            // textPercent
            // 
            textPercent.AllowPromptAsInput = false;
            textPercent.Location = new Point(135, 13);
            textPercent.Margin = new Padding(3, 2, 3, 2);
            textPercent.Mask = "99";
            textPercent.Name = "textPercent";
            textPercent.Size = new Size(38, 23);
            textPercent.TabIndex = 1;
            // 
            // labelPercent
            // 
            labelPercent.AutoSize = true;
            labelPercent.Location = new Point(11, 16);
            labelPercent.Name = "labelPercent";
            labelPercent.Size = new Size(98, 15);
            labelPercent.TabIndex = 0;
            labelPercent.Text = "Процент (0-100):";
            // 
            // panelCertificate
            // 
            panelCertificate.Controls.Add(textAmount);
            panelCertificate.Controls.Add(labelAmount);
            panelCertificate.Location = new Point(12, 187);
            panelCertificate.Margin = new Padding(3, 2, 3, 2);
            panelCertificate.Name = "panelCertificate";
            panelCertificate.Size = new Size(250, 51);
            panelCertificate.TabIndex = 3;
            panelCertificate.Visible = false;
            // 
            // textAmount
            // 
            textAmount.AllowPromptAsInput = false;
            textAmount.Location = new Point(135, 13);
            textAmount.Margin = new Padding(3, 2, 3, 2);
            textAmount.Mask = "9999999999999999999";
            textAmount.Name = "textAmount";
            textAmount.Size = new Size(38, 23);
            textAmount.TabIndex = 5;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(12, 16);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(121, 15);
            labelAmount.TabIndex = 0;
            labelAmount.Text = "Сумма сертификата:";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(12, 245);
            buttonOK.Margin = new Padding(3, 2, 3, 2);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(82, 22);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(180, 245);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonRandomData
            // 
            buttonRandomData.Location = new Point(12, 276);
            buttonRandomData.Margin = new Padding(3, 2, 3, 2);
            buttonRandomData.Name = "buttonRandomData";
            buttonRandomData.Size = new Size(250, 22);
            buttonRandomData.TabIndex = 6;
            buttonRandomData.Text = "Случайные данные";
            buttonRandomData.UseVisualStyleBackColor = true;
            buttonRandomData.Click += ButtonRandomData_Click;
            // 
            // AddDiscountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 305);
            Controls.Add(buttonRandomData);
            Controls.Add(buttonCancel);
            Controls.Add(panelCertificate);
            Controls.Add(buttonOK);
            Controls.Add(panelPercent);
            Controls.Add(groupBoxType);
            Controls.Add(groupBoxCommon);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "AddDiscountForm";
            Text = "Добавление скидки";
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
        private Label label1;
        private TextBox textOriginPrice;
    }
}