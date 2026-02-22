using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    /// <summary>
    /// Исключение
    /// </summary>
    public class IncorrectArgumentException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"></param>
        public IncorrectArgumentException(string message) : base(message) { }
    }
}

