using NUnit.Framework;
using Var5;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса DiscountBase (через наследников)
    /// </summary>
    [TestFixture]
    public class DiscountBaseTest
    {
        /// <summary>
        /// Тестирование свойства Name - позитивные сценарии
        /// </summary>
        [Test]
        [TestCase("Скидка", TestName = "Тестирование Name при присваивании 'Скидка'.")]
        [TestCase("Новогодняя акция", TestName = "Тестирование Name при присваивании 'Новогодняя акция'.")]
        [TestCase("A", TestName = "Тестирование Name при присваивании 'A'.")]
        [TestCase("Скидка 123", TestName = "Тестирование Name при присваивании 'Скидка 123'.")]
        [TestCase("Test Discount", TestName = "Тестирование Name при присваивании 'Test Discount'.")]
        public void NameTest_Positive(string name)
        {
            var discount = new PercentDiscount();
            discount.Name = name;
            Assert.AreEqual(name, discount.Name);
        }

        /// <summary>
        /// Тестирование свойства Name - негативные сценарии
        /// </summary>
        [Test]
        [TestCase("", TestName = "Тестирование Name при присваивании пустой строки.")]
        [TestCase(null, TestName = "Тестирование Name при присваивании null.")]
        [TestCase("   ", TestName = "Тестирование Name при присваивании пробелов.")]
        [TestCase("\t", TestName = "Тестирование Name при присваивании табуляции.")]
        [TestCase("\n", TestName = "Тестирование Name при присваивании переноса строки.")]
        public void NameTest_Negative(string name)
        {
            var discount = new PercentDiscount();
            Assert.Throws<IncorrectArgumentException>(() => discount.Name = name);
        }

        /// <summary>
        /// Тестирование свойства OriginPrice - позитивные сценарии
        /// </summary>
        [Test]
        [TestCase(0, TestName = "Тестирование OriginPrice при присваивании 0.")]
        [TestCase(1, TestName = "Тестирование OriginPrice при присваивании 1.")]
        [TestCase(100, TestName = "Тестирование OriginPrice при присваивании 100.")]
        [TestCase(999999, TestName = "Тестирование OriginPrice при присваивании 999999.")]
        [TestCase(0.01, TestName = "Тестирование OriginPrice при присваивании 0.01.")]
        public void OriginPriceTest_Positive(double price)
        {
            var discount = new PercentDiscount();
            discount.OriginPrice = price;
            Assert.AreEqual(price, discount.OriginPrice);
        }

        /// <summary>
        /// Тестирование свойства OriginPrice - негативные сценарии
        /// </summary>
        [Test]
        [TestCase(-1, TestName = "Тестирование OriginPrice при присваивании -1.")]
        [TestCase(-0.01, TestName = "Тестирование OriginPrice при присваивании -0.01.")]
        [TestCase(-100, TestName = "Тестирование OriginPrice при присваивании -100.")]
        [TestCase(-999999, TestName = "Тестирование OriginPrice при присваивании -999999.")]
        [TestCase(double.NaN, TestName = "Тестирование OriginPrice при присваивании NaN.")]
        public void OriginPriceTest_Negative(double price)
        {
            var discount = new PercentDiscount();
            Assert.Throws<IncorrectArgumentException>(() => discount.OriginPrice = price);
        }
    }
}