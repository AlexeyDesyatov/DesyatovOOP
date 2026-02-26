using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    /// <summary>
    /// Хранение и обработка данных
    /// </summary>
    public abstract class DiscountBase : IDiscount
    {
        /// <summary>
        /// Наименование скидки
        /// </summary>
        private string _name;

        /// <summary>
        /// Исходная цена
        /// </summary>
        private double _originPrice;

        /// <summary>
        /// Данные о скидках
        /// </summary>
        public static readonly Dictionary<int, 
            (string Name, int Priority)> Discount = new()
        {
            { 1, ("Процентная", 10) },
            { 2, ("Сертификат", 5) }
        };

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetName(value);
        }

        /// <summary>
        /// Исходная цена
        /// </summary>
        public double OriginPrice
        {
            get => _originPrice;
            set => SetPrice(value);
        }

        /// <summary>
        /// Получение и валидация наименования
        /// </summary>
        /// <param name="value"></param>
        private void SetName(string value)
        {
            ValidateString(value, "Наименование скидки");
            _name = value;
        }

        /// <summary>
        /// Валидация цены
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="IncorrectArgumentException"></exception>
        private void SetPrice(double value)
        {
            if (value < 0)
            {
                throw new IncorrectArgumentException(
                    "Цена не может быть отрицательной.");
            }
            _originPrice = value;
        }

        /// <summary>
        /// Валидация строки
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <exception cref="IncorrectArgumentException"></exception>
        private static void ValidateString(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new IncorrectArgumentException(
                    $"{fieldName} не может быть пустым.");
            }
        }

        /// <summary>
        /// Расчет стоимости
        /// </summary>
        /// <returns></returns>
        public abstract double GetDiscountPrice();

        /// <summary>
        /// Расчет скидки
        /// </summary>
        /// <returns></returns>
        public abstract double GetDiscountValue();

    }
}
