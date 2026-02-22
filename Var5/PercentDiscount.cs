using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    /// <summary>
    /// Процентная скидка
    /// </summary>
    public class PercentDiscount : DiscountBase
    {
        /// <summary>
        /// Поле для процента скидки
        /// </summary>
        private double _percent;

        /// <summary>
        /// Поле для исходной цены
        /// </summary>
        private double _originPrice;
        
        /// <summary>
        /// Минимально допустимое значение процента скидки
        /// </summary>
        int MinPercent = 0;

        /// <summary>
        /// Максимально допустимое значение процента скидки
        /// </summary>
        int MaxPercent = 100;

        /// <summary>
        /// Получение и валидация процента скидки
        /// </summary>
        public double Percent
        {
            get => _percent;
            set
            {
                if (value < MinPercent || value > MaxPercent)
                {
                    throw new IncorrectArgumentException(
                        "Процент скидки должен быть от 0 до 100.");
                }
                _percent = value;
            }
        }

        /// <summary>
        /// Получение и валидация исходной цены
        /// </summary>
        public double OriginPrice
        {
            get => _originPrice;
            set
            {
                if (value <= 0)
                {
                    throw new IncorrectArgumentException(
                        "Цена должна быть положительной.");
                }
                _originPrice = value;
            }
        }

        /// <summary>
        /// Расчет стоимости
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountValue()
        {
            return _originPrice * _percent / 100;
        }

        /// <summary>
        /// Расчет скидки
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountPrice()
        {
            return _originPrice - GetDiscountValue();
        }
    }
}
