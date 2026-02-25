using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    /// <summary>
    /// Класс скидки по сертификату
    /// </summary>
    public class CertificateDiscount : DiscountBase
    {
        /// <summary>
        /// Поле для скидки по сертификату
        /// </summary>
        private double _certificateAmount;

        /// <summary>
        /// Получение и валидация скидки по сертификату
        /// </summary>
        public double CertificateAmount
        {
            get => _certificateAmount;
            set
            {
                if (value <= 0)
                {
                    throw new IncorrectArgumentException(
                        "Сумма сертификата должна быть положительной.");
                }
                _certificateAmount = value;
            }
        }

        /// <summary>
        /// Расчет стоимости
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountValue()
        {
            return _certificateAmount;
        }

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