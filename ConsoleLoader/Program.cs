using System;
using Var5;

namespace ConsoleLoader
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Цена: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Процент скидки: ");
            double percent = double.Parse(Console.ReadLine());

            var discount = new PercentDiscount
            {
                Name = "Скидка",
                Priority = 1,
                OriginPrice = price,
                Percent = percent
            };

            Console.WriteLine($"\nСкидка: {discount.GetDiscountValue()} руб.");
            Console.WriteLine($"Итого: {discount.GetDiscountPrice()} руб.");
        }
    }
}