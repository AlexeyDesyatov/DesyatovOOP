using System.Globalization;
using System.Text.RegularExpressions;
using Var5;

namespace ConsoleLoader
{
    /// <summary>
    /// Основной класс программы для тестирования системы скидок
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("=== Система расчёта скидок (Вариант 5) ===\n");

            var discountList = new List<IDiscount>();

            while (true)
            {
                IDiscount discount;

                switch (SelectDiscountType())
                {
                    //TODO: отступы +
                    case 1:
                    {
                        discount = CreateAndShowDiscount<PercentDiscount>
                            (HandlersForPercent());
                        discountList.Add(discount);
                        break;
                    }
                    case 2:
                    {
                        discount = CreateAndShowDiscount<CertificateDiscount>
                            (HandlersForCertificate());
                        discountList.Add(discount);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Завершение работы...");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Создаёт объект, отображает результат и возвращает объект
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="handlers">Список</param>
        /// <returns>Экземпляр скидки с данными</returns>
        private static T CreateAndShowDiscount<T>(List<PropertyHandler>
                handlers)
            where T : DiscountBase, new()
        {
            var discount = new T();
            foreach (var handler in handlers)
            {
                handler.SetAction(discount);
            }
            ShowDiscountResult(discount);
            return (T)discount;
        }

        /// <summary>
        /// Метод для обработки чисел
        /// </summary>
        /// <param name="propertyName">Название</param>
        /// <param name="setter">Установка значения</param>
        /// <returns>Новый экземпляр PropertyHandler</returns>
        private static PropertyHandler CreateHandler(
            string propertyName,
            Action<IDiscount, double> setter)
        {
            return new PropertyHandler(
                propertyName,
                discount =>
                {
                    while (true)
                    { 
                        Console.Write($"{propertyName}: ");
                        if (double.TryParse(Console.ReadLine(),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out double value))
                        {
                            try
                            {
                                setter(discount, value);
                                break;
                            }
                            catch (IncorrectArgumentException ex)
                            {
                                Console.Write($" Ошибка! " +
                                    $"{ex.Message} Повторите ввод: ");
                            }
                        }
                        else
                        {
                            Console.Write(" Ошибка!" +
                                " Введите корректное число: ");
                        }
                    }
                });
        }

        /// <summary>
        /// Метод для обработки строки
        /// </summary>
        /// <param name="propertyName">Название</param>
        /// <param name="setter">Установка значения</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        /// <returns>Новый экземпляр PropertyHandler</returns>
        private static PropertyHandler CreateStringHandler(
            string propertyName,
            Action<IDiscount, string> setter,
            string? errorMessage = null)
        {
            return new PropertyHandler(
                propertyName,
                discount =>
                {
                    while (true)
                    {
                        Console.Write($"{propertyName}: ");
                        var input = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            setter(discount, input);
                            break;
                        }
                        Console.Write(errorMessage ?? " Ошибка!" +
                            " Введите корректное значение: ");
                    }
                });
        }

        /// //TODO: XML +
        /// <summary>
        /// Список обработчиков
        /// </summary>
        /// <returns>Список PropertyHandler</returns>
        private static List<PropertyHandler> GetCommonHandlers()
        {
            return new List<PropertyHandler>
            {
                //TODO: duplication +
                CreateStringHandler("Название скидки",
                (d, value) => d.Name = value, errorMessage: " Ошибка! " +
                    "Название не может быть пустым. "),
                //TODO: duplication +
                CreateHandler("Исходная цена (руб.)",
                    (d, value) => d.OriginPrice = value)
            };
        }

        /// <summary>
        /// Обработчики для процентной скидки
        /// </summary>
        /// <returns>Список PropertyHandler</returns>
        private static List<PropertyHandler> HandlersForPercent()
        {
            var handlers = GetCommonHandlers();

            handlers.Add(CreateHandler("Процент скидки (0–100)",
                (d, value) =>
                {
                    if (d is PercentDiscount percentDiscount)
                        percentDiscount.Percent = value;
                }));

            return handlers;
        }

        /// <summary>
        /// Обработчики для скидки по сертификату
        /// </summary>
        /// <returns>Список PropertyHandler</returns>
        private static List<PropertyHandler> HandlersForCertificate()
        {
            var handlers = GetCommonHandlers();

            handlers.Add(CreateHandler("Сумма сертификата (руб.)",
                (d, value) =>
                {
                    if (d is CertificateDiscount certDiscount)
                        certDiscount.CertificateAmount = value;
                }));
            return handlers;
        }

        /// <summary>
        /// Выбор типа скидки пользователем
        /// </summary>
        private static int SelectDiscountType()
        {
            Console.WriteLine("\n Выберите тип скидки:");
            Console.WriteLine("1 — Процентная скидка");
            Console.WriteLine("2 — Скидка по сертификату");
            Console.WriteLine("3 — Выход");

            while (true)
            {
                Console.Write("\nВаш выбор: ");
                if (int.TryParse(Console.ReadLine(), out int choice)
                    && choice is >= 1 and <= 3)
                {
                    return choice;
                }
                Console.WriteLine(" Введите число от 1 до 3");
            }
        }

        /// <summary>
        /// Отображение результата расчёта скидки
        /// </summary>
        private static void ShowDiscountResult(IDiscount discount)
        {
            Console.WriteLine($" Скидка: " +
                $"{discount.Name}");
            Console.WriteLine($" Размер скидки:" +
                $" {discount.GetDiscountValue():F2} руб.");
            Console.WriteLine($" Итоговая цена:" +
                $" {discount.GetDiscountPrice():F2} руб.");
        }
    }
}