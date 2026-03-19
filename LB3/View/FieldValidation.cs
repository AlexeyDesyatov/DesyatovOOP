using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Var5;

namespace View
{
    /// <summary>
    /// Класс для валидации полей
    /// </summary>
    public static class FieldValidation
    {
        /// <summary>
        /// Выполняет действие с обработкой исключений и повтором ввода
        /// </summary>
        public static bool TryValidate(Action action,
            string fieldName, Control targetControl)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (IncorrectArgumentException ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                targetControl.Focus();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка ввода {fieldName}: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                targetControl.Focus();
                return false;
            }    
        }

        /// <summary>
        /// Валидация строки
        /// </summary>
        public static bool ValidateString(TextBoxBase textBox,
            string fieldName, Action<string> setter)
        {
            return TryValidate(
                action: () =>
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        throw new IncorrectArgumentException(
                            $"{fieldName} не может быть пустым.");
                    }
                    setter(textBox.Text);
                }, 
                fieldName, 
                textBox
            );
        }

        /// <summary>
        /// Валидация числа
        /// </summary>
        public static bool ValidateDouble(TextBoxBase textBox,
            string fieldName, Action<double> setter)
        {
           return TryValidate(
                action: () =>
                {
                    if (!double.TryParse(textBox.Text, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out double value))
                    {
                        throw new IncorrectArgumentException(
                            "Введите корректное число.");
                    }

                    if (value < 0)
                    {
                        throw new IncorrectArgumentException(
                            $"{fieldName} не может быть отрицательным.");
                    }

                    setter(value);
                },
                fieldName,
                textBox
            );
        }

        /// <summary>
        /// Валидация числа в диапазоне
        /// </summary>
        public static bool ValidateDoubleRange(TextBoxBase textBox,
            string fieldName, Action<double> setter)
        {
            /// <summary>
            /// Максимально допустимое значение процента скидки
            /// </summary>
            const int Max = 100;

            /// <summary>
            /// Минимально допустимое значение процента скидки
            /// </summary>
            const int Min = 0;

            return TryValidate(
                action: () =>
                {
                    
                    if (!double.TryParse(textBox.Text, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out double value))
                    {
                        throw new IncorrectArgumentException(
                            $"Введите корректное число.");
                    }
                    if (value < Min|| value > Max)
                    {
                        throw new IncorrectArgumentException(
                            $"{fieldName} должен быть от {Min} до {Max}.");
                    }
                    setter(value);
                }, 
                fieldName, 
                textBox
            );
        }
    }
}