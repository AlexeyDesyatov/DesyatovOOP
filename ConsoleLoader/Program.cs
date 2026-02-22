using System;
using Var5;

namespace ConsoleLoader
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Система расчета скидок");

            while (true)
            {
                Console.WriteLine("\nВыберите тип скидки:");
                Console.WriteLine("1 - Процентная скидка");
                Console.WriteLine("2 - Скидка по сертификату");
                Console.WriteLine("3 - Выход");

                string choice = Console.ReadLine();

                try
                {
                    IDiscount discount = choice switch
                    {
                        "1" => CreatePercentDiscount(),
                        "2" => CreateCertificateDiscount()
                    };

                    ShowDiscountInfo(discount);
                }

                catch (IncorrectArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
        private static IDiscount CreatePercentDiscount()
        {
            Console.Write("Введите исходную цену: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите процент скидки (0-100): ");
            double percent = Convert.ToDouble(Console.ReadLine());

            var discount = new PercentDiscount
            {
                Name = "Процентная скидка",
                Priority = 10,
                OriginPrice = price,
                Percent = percent
            };

            return discount;
        }

        private static IDiscount CreateCertificateDiscount()
        {
            Console.Write("Введите исходную цену: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите сумму сертификата: ");
            double certificateAmount = Convert.ToDouble(Console.ReadLine());

            var discount = new CertificateDiscount
            {
                Name = "Скидка по сертификату",
                Priority = 5,
                OriginalPrice = price,
                CertificateAmount = certificateAmount
            };

            return discount;
        }

        private static void ShowDiscountInfo(IDiscount discount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nТип скидки: {discount.Name}");
            Console.WriteLine($"Приоритет: {discount.Priority}");
            Console.WriteLine($"Сумма скидки: {discount.GetDiscountValue():F2} руб.");
            Console.WriteLine($"Итоговая цена: {discount.GetDiscountPrice():F2} руб.");
            Console.ResetColor();
        }
    }
}