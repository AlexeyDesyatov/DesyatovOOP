using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Var5;

namespace ConsoleLoader
{
    /// <summary>
    /// Логика обработки свойств
    /// </summary>
    public class PropertyHandler
    {
        /// <summary>
        /// Делегат для выполнения ввода свойства
        /// </summary>
        public Action<IDiscount> SetAction { get; }

        /// <summary>
        /// Название свойства для вывода пользователю
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public PropertyHandler(
            string propertyName,
            Action<IDiscount> setAction)
        {
            PropertyName = propertyName;
            SetAction = setAction;
        }
    }
}
