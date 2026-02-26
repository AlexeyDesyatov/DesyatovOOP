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
        
        //TODO: RSDN
        /// <summary>
        /// Минимально допустимое значение процента скидки
        /// </summary>
        int MinPercent = 0;

        //TODO: RSDN
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
        /// Расчет стоимости
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountValue()
        {
            return OriginPrice * _percent / 100;
        }

        //TODO: refactor
        /// <summary>
        /// Расчет скидки
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountPrice()
        {
            return OriginPrice - GetDiscountValue();
        }
    }
}
