using NUnit.Framework;
using Var5;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса DiscountBase
    /// </summary>
    [TestFixture]
    public class DiscountBaseTest
    {
        /// <summary>
        /// Отклонение для double
        /// </summary>
        public const double Tolerance = 0.01;

        /// <summary>
        /// Тестирование свойства Name
        /// </summary>
        [Test]
        [TestCase(
            "Скидка", 
            TestName = 
                "Тестирование Name: " +
                "при присваивании названия в одно слово 'Скидка'."
        )]
        [TestCase(
            "Новогодняя акция", 
            TestName =
                "Тестирование Name: " +
                "при присваивании названия в два слова 'Новогодняя акция'."
        )]
        [TestCase(
            "A", 
            TestName =
                "Тестирование Name: " +
                "при присваивании короткого названия 'A'."
        )]
        [TestCase(
            "Скидка 123", 
            TestName =
                "Тестирование Name: " +
                "при присваивании названия с цифрами 'Скидка 123'."
        )]
        [TestCase(
            "Test Discount", 
            TestName =
                "Тестирование Name: " +
                "при присваивании названия на английском языке 'Test Discount'."
        )]
        public void NameTest(string name)
        {
            var discount = new PercentDiscount();
            discount.Name = name;
            Assert.AreEqual(name, discount.Name);
        }
        [Test]
        [TestCase(
            "", 
            TestName =
                "Тестирование Name при присваивании пустой строки."
        )]
        [TestCase(
            null, 
            TestName = 
                "Тестирование Name при присваивании null."
        )]
        [TestCase(
            "   ", 
            TestName = 
                "Тестирование Name при присваивании пробелов."
        )]
        [TestCase(
            "\t", 
            TestName = 
                "Тестирование Name при присваивании табуляции."
        )]
        [TestCase(
            "\n", 
            TestName = 
                "Тестирование Name при присваивании переноса строки."
        )]
        public void NameNegativeTest(string name)
        {
            var discount = new PercentDiscount();
            Assert.Throws<IncorrectArgumentException>(
                () => discount.Name = name);
        }

        /// <summary>
        /// Тестирование свойства OriginPrice
        /// </summary>
        [Test]
        [TestCase(
            0, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании минимального значения цены 0."
        )]
        [TestCase(
            1, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании цены 1."
        )]
        [TestCase(
            100, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании цены 100."
        )]
        [TestCase(
            999999, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании цены 999999."
        )]
        [TestCase(
            0.01, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании дробного значения цены 0.01."
        )]
        public void OriginPriceTest(double price)
        {
            var discount = new PercentDiscount();
            discount.OriginPrice = price;
            Assert.AreEqual(price, discount.OriginPrice);
        }
        [Test]
        [TestCase(
            -1, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании цены -1."
        )]
        [TestCase(
            -0.01, 
            TestName =
                "Тестирование OriginPrice: " +
                "при присваивании цены -0.01."
        )]
        [TestCase(
            -100, 
            TestName =
                "Тестирование OriginPrice: " +
                "при присваивании цены -100."
        )]
        [TestCase(
            -999999, 
            TestName =
                "Тестирование OriginPrice: " +
                "при присваивании цены -999999."
        )]
        [TestCase(
            double.NaN, 
            TestName = 
                "Тестирование OriginPrice: " +
                "при присваивании NaN."
        )]
        public void OriginPriceNegativeTest(double price)
        {
            var discount = new PercentDiscount();
            Assert.Throws<IncorrectArgumentException>(
                () => discount.OriginPrice = price);
        }
    }
}