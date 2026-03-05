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
        /// Название типа скидки
        /// </summary>
        public override string DiscountType => "Процентная";

        /// <summary>
        /// Минимально допустимое значение процента скидки
        /// </summary>
        private const int MinPercent = 0;

        /// <summary>
        /// Максимально допустимое значение процента скидки
        /// </summary>
        private const int MaxPercent = 100;

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
                    //TODO: magic (to const)
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
    }
}
