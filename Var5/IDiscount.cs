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
        /// Расчет скидки
        /// </summary>
        /// <returns></returns>
        double Calculate();
    }
}
