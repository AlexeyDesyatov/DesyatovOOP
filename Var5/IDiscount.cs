using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    /// <summary>
    /// Интерфейс для расчета скидки
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// Название типа скидки
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Приоритет скидки
        /// </summary>
        int Priority { get; set; }

        /// <summary>
        /// Расчет стоимости
        /// </summary>
        /// <returns></returns>
        double GetDiscountPrice();

        /// <summary>
        /// Расчет скидки
        /// </summary>
        /// <returns></returns>
        double GetDiscountValue();
    }
}
