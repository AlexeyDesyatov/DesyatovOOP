using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var5
{
    public abstract class DiscountBase : IDiscount
    {

        private string _name;

        private int _priority;


        public static readonly Dictionary<int, 
            (string Name, int Priority)> Discount = new()
        {
            { 1, ("Процентная", 10) },
            { 2, ("Сертификат", 5) }
        };

        public string Name
        {
            get => _name;
            set => SetName(value);
        }

        public int Priority
        {
            get => _priority;
            set => SetPriority(value);
        }

        private void SetName(string value)
        {
            ValidateString(value, "Наименование скидки");
            _name = value;
        }

        private void SetPriority(int value)
        {
            if (value < 0)
            {
                throw new IncorrectArgumentException(
                    "Приоритет скидки не может быть отрицательным.");
            }
            _priority = value;
        }


        private static void ValidateString(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new IncorrectArgumentException(
                    $"{fieldName} не может быть пустым.");
            }
        }

        public abstract double GetDiscountPrice();

        public abstract double GetDiscountValue();

    }
}
