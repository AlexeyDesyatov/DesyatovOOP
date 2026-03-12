using System;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения
        /// </summary>
        /// <remarks>
        /// Инициализирует конфигурацию WinForms и запускает главную форму
        /// </remarks>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new DiscountForm());
        }
    }
}