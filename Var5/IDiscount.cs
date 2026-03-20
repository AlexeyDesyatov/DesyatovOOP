using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Var5
{
    /// <summary>
    /// Интерфейс для расчета скидки
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(PercentDiscount), "percent")]
    [JsonDerivedType(typeof(CertificateDiscount), "certificate")]
    public interface IDiscount
    {
        /// <summary>
        /// Название скидки
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Исходная цена
        /// </summary>
        double OriginPrice { get; set; }

        /// <summary>
        /// Тип скидки
        /// </summary>
        string DiscountType { get; }

        /// <summary>
        /// Cтоимость
        /// </summary>
        double DiscountPrice { get; }

        /// <summary>
        /// Cкидка
        /// </summary>
        double DiscountValue { get; }

        /// <summary>
        /// Отображаемый размер скидки
        /// </summary>
        string DiscountValueDisplay { get; }
    }
}
