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
                    //TODO: {} +
                    case 1:
                        {
                            discount = CreateAndShowDiscount<PercentDiscount>
                            (GetPropertyHandlersForPercent());
                            discountList.Add(discount);
                            break;
                        }
                    case 2:
                        {
                            discount = CreateAndShowDiscount<CertificateDiscount>
                            (GetPropertyHandlersForCertificate());
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
        private static T CreateAndShowDiscount<T>(List<PropertyHandler> handlers)
            where T : DiscountBase, new()
        {
            var discount = new T();
            foreach (var handler in handlers)
            {
                Console.Write($"{handler.PropertyName}: ");
                handler.SetAction(discount);
            }
            ShowDiscountResult(discount);
            return (T)discount;
        }

        /// <summary>
        /// Общие обработчики для всех типов скидок
        /// </summary>
        private static List<PropertyHandler> GetCommonHandlers()
        {
            return new List<PropertyHandler>
            {
                new PropertyHandler("Название скидки",
                    d =>
                    {
                        while (true)
                        {   
                            var input = Console.ReadLine();
                            //TODO: {} +
                            if (!string.IsNullOrWhiteSpace(input))
                            {
                                d.Name = input;
                                break;
                            }
                            Console.Write(" Ошибка!" +
                                " Название не может быть пустым. ");
                        }
                    }),

                new PropertyHandler("Исходная цена (руб.)",
                    d =>
                    {
                        while (true)
                        {
                            //TODO: {} +
                            if (double.TryParse(Console.ReadLine(),
                                out double price))
                            {
                                try
                                {
                                    d.OriginPrice = price;
                                    break;
                                }
                                catch (IncorrectArgumentException ex)
                                {
                                    Console.Write($" Ошибка!" +
                                        $" {ex.Message} Повторите ввод: ");
                                }
                            }
                            else
                            {
                                Console.Write(" Ошибка!" +
                                    " Введите корректное число: ");
                            }
                        }
                    })
            };
        }

        /// <summary>
        /// Обработчики для процентной скидки
        /// </summary>
        private static List<PropertyHandler> GetPropertyHandlersForPercent()
        {
            var handlers = GetCommonHandlers();

            handlers.Add(new PropertyHandler("Процент скидки (0–100)",
                d =>
                {
                    if (d is PercentDiscount percentDiscount)
                    {
                        while (true)
                        {
                            //TODO: {} +
                            if (double.TryParse(Console.ReadLine(),
                                out double percent))
                            {
                                try
                                {
                                    percentDiscount.Percent = percent; 
                                    break; 
                                }
                                catch (IncorrectArgumentException ex)
                                {
                                    Console.Write($" Ошибка!" +
                                        $" {ex.Message} Повторите ввод: ");
                                }
                            }
                            else
                            {
                                Console.Write(" Ошибка!" +
                                    " Введите корректное число: ");
                            }
                        }
                    }
                }));

            return handlers;
        }

        /// <summary>
        /// Обработчики для скидки по сертификату
        /// </summary>
        private static List<PropertyHandler> GetPropertyHandlersForCertificate()
        {
            var handlers = GetCommonHandlers();

            handlers.Add(new PropertyHandler("Сумма сертификата (руб.)",
                d =>
                {
                    if (d is CertificateDiscount certDiscount)
                    {
                        while (true)
                        {
                            //TODO: {} +
                            if (double.TryParse(Console.ReadLine(),
                                out double amount))
                            {
                                try
                                {
                                    certDiscount.CertificateAmount = amount;
                                    break; 
                                }
                                catch (IncorrectArgumentException ex)
                                {
                                    Console.Write($" Ошибка!" +
                                        $" {ex.Message} Повторите ввод: ");
                                }
                            }
                            else
                            {
                                Console.Write(" Ошибка!" +
                                    " Введите корректное число: ");
                            }
                        }
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
        //TODO: remove +
    }
}