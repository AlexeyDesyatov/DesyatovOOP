using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    public class CertificateDiscount : DiscountBase
    {
        /// <summary>
        /// Поле для скидки по сертификату
        /// </summary>
        private double _certificateAmount;

        /// <summary>
        /// Поле для исходной цены
        /// </summary>
        private double _originalPrice;

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
        /// Получение и валидация исходной цены
        /// </summary>
        public double OriginalPrice
        {
            get => _originalPrice;
            set
            {
                if (value <= 0)
                {
                    throw new IncorrectArgumentException(
                        "Цена должна быть положительной.");
                }
                _originalPrice = value;
            }
        }

        /// <summary>
        /// Расчет стоимости
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountValue()
        {
            return _originalPrice - _certificateAmount;
        }

        /// <summary>
        /// Расчет скидки
        /// </summary>
        /// <returns></returns>
        public override double GetDiscountPrice()
        {
            return _originalPrice - GetDiscountValue();
        }
    }
}