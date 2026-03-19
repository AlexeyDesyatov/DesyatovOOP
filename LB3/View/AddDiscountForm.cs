using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Var5;

namespace View
{
    /// <summary>
    /// Форма для добавления скидки
    /// </summary>
    public partial class AddDiscountForm : Form
    {
        /// <summary>
        /// Свойство для возврата скидки
        /// </summary>
        public IDiscount NewDiscount { get; private set; }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AddDiscountForm()
        {
            InitializeComponent();
            SetupForm();
        #if !DEBUG
            buttonRandomData.Visible = false;
        #endif
        }

        /// <summary>
        /// Настройка формы
        /// </summary>
        private void SetupForm()
        {
            radioButtonPercent.Checked = false;
            radioButtonCertificate.Checked = false;
            panelPercent.Visible = false;
            panelCertificate.Visible = false;

            void TogglePanels(object? sender, EventArgs e)
            {
                panelPercent.Visible = radioButtonPercent.Checked;
                panelCertificate.Visible = radioButtonCertificate.Checked;
            }

            radioButtonPercent.CheckedChanged += TogglePanels;
            radioButtonCertificate.CheckedChanged += TogglePanels;
        }

        /// <summary>
        /// Создание и валидация объектов по процентной скидке
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        /// <exception cref="IncorrectArgumentException"></exception>
        private IDiscount CreatePercentDiscount(string name, double price)
        {
            double percent = 0;

            if (!FieldValidation.ValidateDoubleRange(textPercent, "Процент",
                 value => percent = value))
            {
                throw new IncorrectArgumentException("Некорректный процент.");
            }

            return new PercentDiscount { Name = name, OriginPrice = price,
                Percent = percent };
        }

        /// <summary>
        /// Создание и валидация объектов по сертификату
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        /// <exception cref="IncorrectArgumentException"></exception>
        private IDiscount CreateCertificateDiscount(string name, double price)
        {
            double amount = 0;

            if (!FieldValidation.ValidateDouble(textAmount, "Сумма сертификата",
                value => amount = value))
            {
                throw new IncorrectArgumentException("Некорректная сумма.");
            }

            return new CertificateDiscount { Name = name, OriginPrice = price,
                CertificateAmount = amount };
        }

        /// <summary>
        /// Проверка введенных полей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!radioButtonPercent.Checked && !radioButtonCertificate.Checked)
                {
                    throw new IncorrectArgumentException("Выберите тип скидки.");
                }

                var validators = new Dictionary<string, Func<bool>>
                {
                    { "Название", () => FieldValidation.ValidateString(textName,
                        "Название скидки", _ => {}) },
                    { "Цена", () => FieldValidation.ValidateDouble(textOriginPrice,
                        "Исходная цена", _ => {}) }
                };

                foreach (var validator in validators)
                {
                    if (!validator.Value())
                    {
                        return;
                    }
                }

                var name = textName.Text;
                var price = double.Parse(textOriginPrice.Text,
                    CultureInfo.InvariantCulture);

                NewDiscount = radioButtonPercent.Checked
                    ? CreatePercentDiscount(name, price)
                    : CreateCertificateDiscount(name, price);

                DialogResult = DialogResult.OK;
            }
            catch (IncorrectArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка создания случайного списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRandomData_Click(object sender, EventArgs e)
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
                textAmount.Text = random.Next(50, 5001).ToString();
            }
        }
    }
}
