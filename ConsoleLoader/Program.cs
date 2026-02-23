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
        public class PropertyHandlerDTO
        {
            /// <summary>
            /// Делегат для выполнения ввода свойства
            /// </summary>
            public Action<IDiscount> PropertyHandlingAction { get; }

            /// <summary>
            /// Список ожидаемых типов исключений
            /// </summary>
            public List<Type> ExceptionTypes { get; }

            /// <summary>
            /// Название свойства для вывода пользователю
            /// </summary>
            public string PropertyName { get; }

            /// <summary>
            /// Конструктор
            /// </summary>
            public PropertyHandlerDTO(
                string propertyName,
                List<Type> exceptionTypes,
                Action<IDiscount> propertyHandlingAction)
            {
                PropertyName = propertyName;
                ExceptionTypes = exceptionTypes;
                PropertyHandlingAction = propertyHandlingAction;
            }
        }

        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Система расчёта скидок (Вариант 5) ===\n");

            var discountList = new List<IDiscount>();

            while (true)
            {
                IDiscount discount;

                switch (SelectDiscountType())
                {
                    case 1: 
                        discount = CreateAndShowDiscount<PercentDiscount>(
                            GetPropertyHandlersForPercent());
                        discountList.Add(discount);
                        break;

                    case 2: 
                        discount = CreateAndShowDiscount<CertificateDiscount>(
                            GetPropertyHandlersForCertificate());
                        discountList.Add(discount);
                        break;

                    case 3:
                        Console.WriteLine("Завершение работы...");
                        return;
                }
            }
        }

        /// <summary>
        /// Создаёт скидку, отображает результат и возвращает объект
        /// </summary>
        private static T CreateAndShowDiscount<T>(List<PropertyHandlerDTO> handlers)
            where T : DiscountBase, new()
        {
            var discount = CreateDiscount<T>(handlers);
            ShowDiscountResult(discount);
            return (T)discount;
        }

        /// <summary>
        /// Создание объекта скидки с обработчиками свойств
        /// </summary>
        private static T CreateDiscount<T>(List<PropertyHandlerDTO> handlers)
            where T : DiscountBase, new()
        {
            var discount = new T();
            foreach (var handler in handlers)
            {
                HandlePropertyWithRetry(discount, handler);
            }
            return (T)discount;
        }

        /// <summary>
        /// Обработчик ввода свойства с повтором при ошибке
        /// </summary>
        private static void HandlePropertyWithRetry(
            IDiscount discount,
            PropertyHandlerDTO handler)
        {
            while (true)
            {
                Console.Write($"\n{handler.PropertyName}: ");
                try
                {
                    handler.PropertyHandlingAction(discount);
                    return;
                }
                catch (Exception ex) when (handler.ExceptionTypes.Contains(ex.GetType()))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine(" Повторите ввод...");
                }
            }
        }

        /// <summary>
        /// Общие обработчики для всех типов скидок
        /// </summary>
        private static List<PropertyHandlerDTO> GetCommonHandlers()
        {
            var exceptionTypes = new List<Type> { typeof(IncorrectArgumentException) };

            return new List<PropertyHandlerDTO>
            {
                new PropertyHandlerDTO("Название скидки", exceptionTypes,
                    d =>
                    {
                        var input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                            throw new IncorrectArgumentException("Название не может быть пустым.");
                        d.Name = CapitalizeFirstLetter(input);
                    }),

                new PropertyHandlerDTO("Приоритет (целое число ≥ 0)",
                    new List<Type> { typeof(IncorrectArgumentException), typeof(FormatException) },
                    d =>
                    {
                        if (!int.TryParse(Console.ReadLine(), out int priority))
                            throw new FormatException();
                        d.Priority = priority;
                    })
            };
        }

        /// <summary>
        /// Обработчики для процентной скидки
        /// </summary>
        private static List<PropertyHandlerDTO> GetPropertyHandlersForPercent()
        {
            var handlers = GetCommonHandlers();
            var numericExceptions = new List<Type>
            {
                typeof(IncorrectArgumentException),
                typeof(FormatException)
            };

            handlers.Add(new PropertyHandlerDTO("Исходная цена (руб.)", numericExceptions,
                d =>
                {
                    if (d is PercentDiscount percentDiscount)
                    {
                        if (!double.TryParse(Console.ReadLine(),
                                NumberStyles.Number,
                                CultureInfo.InvariantCulture,
                                out double price))
                            throw new FormatException();
                        percentDiscount.OriginPrice = price;
                    }
                }));

            handlers.Add(new PropertyHandlerDTO("Процент скидки (0–100)", numericExceptions,
                d =>
                {
                    if (d is PercentDiscount percentDiscount)
                    {
                        if (!double.TryParse(Console.ReadLine(),
                                NumberStyles.Number,
                                CultureInfo.InvariantCulture,
                                out double percent))
                            throw new FormatException();
                        percentDiscount.Percent = percent;
                    }
                }));

            return handlers;
        }

        /// <summary>
        /// Обработчики для скидки по сертификату
        /// </summary>
        private static List<PropertyHandlerDTO> GetPropertyHandlersForCertificate()
        {
            var handlers = GetCommonHandlers();
            var numericExceptions = new List<Type>
            {
                typeof(IncorrectArgumentException),
                typeof(FormatException)
            };

            handlers.Add(new PropertyHandlerDTO("Исходная цена (руб.)", numericExceptions,
                d =>
                {
                    if (d is CertificateDiscount certDiscount)
                    {
                        if (!double.TryParse(Console.ReadLine(),
                                NumberStyles.Number,
                                CultureInfo.InvariantCulture,
                                out double price))
                            throw new FormatException();
                        certDiscount.OriginalPrice = price;
                    }
                }));

            handlers.Add(new PropertyHandlerDTO("Сумма сертификата (руб.)", numericExceptions,
                d =>
                {
                    if (d is CertificateDiscount certDiscount)
                    {
                        if (!double.TryParse(Console.ReadLine(),
                                NumberStyles.Number,
                                CultureInfo.InvariantCulture,
                                out double amount))
                            throw new FormatException();
                        certDiscount.CertificateAmount = amount;
                    }
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
                Console.Write("\nВаш выбор (1-3): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice is >= 1 and <= 3)
                {
                    return choice;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Введите число от 1 до 3");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Отображение результата расчёта скидки
        /// </summary>
        private static void ShowDiscountResult(IDiscount discount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('=', 40));
            Console.WriteLine($"  Скидка: {discount.Name} (приоритет: {discount.Priority})");
            Console.WriteLine($" Размер скидки: {discount.GetDiscountValue():F2} руб.");
            Console.WriteLine($" Итоговая цена: {discount.GetDiscountPrice():F2} руб.");
            Console.WriteLine(new string('=', 40));
            Console.ResetColor();
        }

        /// <summary>
        /// Показать все созданные скидки
        /// </summary>
        private static void ShowAllDiscounts(List<IDiscount> discounts)
        {
            if (discounts.Count == 0)
            {
                Console.WriteLine(" Список пуст. Создайте хотя бы одну скидку.");
                return;
            }

            Console.WriteLine("\n Все созданные скидки:");
            for (int i = 0; i < discounts.Count; i++)
            {
                var d = discounts[i];
                Console.WriteLine($"\n[{i + 1}] {d.Name} | Приоритет: {d.Priority}");
                Console.WriteLine($"    Скидка: {d.GetDiscountValue():F2} руб. | Итого: {d.GetDiscountPrice():F2} руб.");
            }
        }

        /// <summary>
        /// Преобразование первой буквы каждого слова в заглавную
        /// </summary>
        private static string CapitalizeFirstLetter(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;

            var culture = CultureInfo.CurrentCulture;
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();

            foreach (var word in words)
            {
                if (word.Length > 0)
                {
                    result.Add(char.ToUpper(word[0], culture) +
                              word.Substring(1).ToLower(culture));
                }
            }

            return string.Join(" ", result);
        }
    }
}