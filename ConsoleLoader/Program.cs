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
        /// Класс конструктора
        /// </summary>
        public class Constructor
        {
            /// <summary>
            /// Делегат для выполнения ввода свойства
            /// </summary>
            public Action<IDiscount> ConstructorAction { get; }

            /// <summary>
            /// Название свойства для вывода пользователю
            /// </summary>
            public string ConstructorName { get; }

            /// <summary>
            /// Конструктор
            /// </summary>
            public Constructor(
                string constructorName,
                Action<IDiscount> constructorAction)
            {
                ConstructorName = constructorName;
                ConstructorAction = constructorAction;
            }
        }

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
        /// Создаёт объект, отображает результат и возвращает объект
        /// </summary>
        private static T CreateAndShowDiscount<T>(List<Constructor> handlers)
            where T : DiscountBase, new()
        {
            var discount = new T();
            foreach (var handler in handlers)
            {
                Console.Write($"{handler.ConstructorName}: ");
                handler.ConstructorAction(discount);
            }
            ShowDiscountResult(discount);
            return (T)discount;
        }

        /// <summary>
        /// Общие обработчики для всех типов скидок
        /// </summary>
        private static List<Constructor> GetCommonHandlers()
        {
            return new List<Constructor>
            {
                new Constructor("Название скидки",
                    d =>
                    {
                        var input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                            throw new IncorrectArgumentException("Название не может быть пустым.");
                        d.Name = input;
                    }),

                new Constructor("Исходная цена (руб.)",
                    d =>
                    {
                        if (!double.TryParse(Console.ReadLine(), out double price))
                            throw new FormatException();
                        d.OriginPrice = price;
                    })
            };
        }

        /// <summary>
        /// Обработчики для процентной скидки
        /// </summary>
        private static List<Constructor> GetPropertyHandlersForPercent()
        {
            var handlers = GetCommonHandlers();

            handlers.Add(new Constructor("Процент скидки (0–100)",
                d =>
                {
                    if (d is PercentDiscount percentDiscount)
                    {
                        if (!double.TryParse(Console.ReadLine(), out double percent))
                            throw new FormatException();
                        percentDiscount.Percent = percent;
                    }
                }));

            return handlers;
        }

        /// <summary>
        /// Обработчики для скидки по сертификату
        /// </summary>
        private static List<Constructor> GetPropertyHandlersForCertificate()
        {
            var handlers = GetCommonHandlers();

            handlers.Add(new Constructor("Сумма сертификата (руб.)",
                d =>
                {
                    if (d is CertificateDiscount certDiscount)
                    {
                        if (!double.TryParse(Console.ReadLine(), out double amount))
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
                Console.Write("\nВаш выбор: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice is >= 1 and <= 3)
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
            Console.WriteLine($" Скидка: {discount.Name}");
            Console.WriteLine($" Размер скидки: {discount.GetDiscountValue():F2} руб.");
            Console.WriteLine($" Итоговая цена: {discount.GetDiscountPrice():F2} руб.");
        }
    }
}