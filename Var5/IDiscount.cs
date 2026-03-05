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
        /// Исходная цена
        /// </summary>
        double OriginPrice { get; set; }

        /// <summary>
        /// Cтоимость
        /// </summary>
        double DiscountPrice { get; }

        /// <summary>
        /// Cкидка
        /// </summary>
        double DiscountValue { get; }
    }
}
