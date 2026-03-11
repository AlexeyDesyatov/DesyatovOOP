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
    public partial class AddDiscountForm : Form
    {
        private void labelPrice_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        /// <summary>
        /// Свойство для возврата скидки
        /// </summary>
        public IDiscount NewDiscount { get; private set; }

        public AddDiscountForm()
        {
            InitializeComponent();
            SetupForm();
        #if !DEBUG
            buttonRandomData.Visible = false;
        #endif
        }

        private void SetupForm()
        {
            radioButtonPercent.Checked = false;
            radioButtonCertificate.Checked = false;
            panelPercent.Visible = false;
            panelCertificate.Visible = false;

            radioButtonPercent.CheckedChanged += (sender, e) =>
            {
                panelPercent.Visible = radioButtonPercent.Checked;
                panelCertificate.Visible = radioButtonCertificate.Checked;
            };

            radioButtonCertificate.CheckedChanged += (sender, e) =>
            {
                panelPercent.Visible = radioButtonPercent.Checked;
                panelCertificate.Visible = radioButtonCertificate.Checked;
            };
        }

        /// <summary>
        /// Проверка введенных полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!radioButtonPercent.Checked && !radioButtonCertificate.Checked)
                {
                    MessageBox.Show("Выберите тип скидки.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textName.Text))
                {
                    MessageBox.Show("Название скидки не может быть пустым.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textName.Focus();
                    return;
                }

                if (!double.TryParse(textOriginPrice.Text, out double price))
                {
                    MessageBox.Show("Введите корректную цену (число).",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textOriginPrice.Focus();
                    return;
                }

                if (price < 0)
                {
                    MessageBox.Show("Цена не может быть отрицательной.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textOriginPrice.Focus();
                    return;
                }

                if (radioButtonPercent.Checked)
                {
                    if (!double.TryParse(textPercent.Text, out double percent))
                    {
                        MessageBox.Show("Введите корректный процент (число).",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textPercent.Focus();
                        return;
                    }

                    if (percent < 0 || percent > 100)
                    {
                        MessageBox.Show("Процент должен быть от 0 до 100.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textPercent.Focus();
                        return;
                    }

                    NewDiscount = new PercentDiscount
                    {
                        Name = textName.Text,
                        OriginPrice = price,
                        Percent = percent
                    };
                }
                else
                {
                    if (!double.TryParse(textAmount.Text, out double amount))
                    {
                        MessageBox.Show("Введите корректную сумму (число).",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textAmount.Focus();
                        return;
                    }

                    if (amount <= 0)
                    {
                        MessageBox.Show("Сумма сертификата должна быть положительной.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textAmount.Focus();
                        return;
                    }

                    NewDiscount = new CertificateDiscount
                    {
                        Name = textName.Text,
                        OriginPrice = price,
                        CertificateAmount = amount
                    };
                }

                DialogResult = DialogResult.OK;
            }
            catch (IncorrectArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRandomData_Click(object sender, EventArgs e)
        {
            var random = new Random();

            string[] names = {
                "Летняя распродажа",
                "Новогодняя скидка",
                "Черная пятница",
                "Сезонная скидка",
                "Праздничная акция"
            };
            textName.Text = names[random.Next(names.Length)];

            textOriginPrice.Text = random.Next(100, 10001).ToString();

            if (random.Next(2) == 0)
            {
                radioButtonPercent.Checked = true;
                textPercent.Text = random.Next(0, 101).ToString();
            }
            else
            {
                radioButtonCertificate.Checked = true;
                textAmount.Text = random.Next(50, 5001).ToString(); // 50-5000 руб.
            }
        }
    }
}
