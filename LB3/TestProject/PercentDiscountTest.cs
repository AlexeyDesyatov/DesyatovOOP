using NUnit.Framework;
using Var5;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса PercentDiscount
    /// </summary>
    [TestFixture]
    public class PercentDiscountTest
    {
        /// <summary>
        /// Тестирование свойства Percent
        /// </summary>
        [Test]
        [TestCase(
            0, 
            TestName = 
                "Тестирование Percent:" +
                "при присваивании минимально допустимого процента 0."
        )]
        [TestCase(
            1, 
            TestName = 
                "Тестирование Percent:" +
                "при присваивании минимального положительного процента 1."
        )]
        [TestCase(
            50, 
            TestName = 
                "Тестирование Percent: " +
                "при присваивании среднего процента 50."
        )]
        [TestCase(
            100, 
            TestName = 
                "Тестирование Percent:" +
                "при присваивании максимального процента 100."
        )]
        [TestCase(
            25.5, 
            TestName = 
                "Тестирование Percent: " +
                "при присваивании дробного процента 25.5."
        )]
        public void PercentTest(double percent)
        {
            var discount = new PercentDiscount();
            discount.Percent = percent;
            Assert.AreEqual(percent, discount.Percent);
        }

        [Test]
        [TestCase(
            -1, 
            TestName = 
                "Тестирование Percent:" +
                "при присваивании отрицательного процента -1."
        )]
        [TestCase(
            -0.1, 
            TestName = 
                "Тестирование Percent:" +
                "при присваивании дробного отрицательного процента -0.1."
        )]
        [TestCase(
            101, 
            TestName = 
                "Тестирование Percent: " +
                "при присваивании процента больше максимума 101."
        )]
        [TestCase(
            150, 
            TestName = 
                "Тестирование Percent:" +
                "при присваивании процента значительно больше максимума 150."
        )]
        [TestCase(
            double.NaN, 
            TestName = 
                "Тестирование Percent: " +
                "при присваивании NaN."
        )]
        public void PercentNegativeTest(double percent)
        {
            var discount = new PercentDiscount();
            Assert.Throws<IncorrectArgumentException>(
                () => discount.Percent = percent);
        }

        /// <summary>
        /// Тестирование свойства DiscountType
        /// </summary>
        [Test]
        public void DiscountTypeTest()
        {
            var discount = new PercentDiscount();
            Assert.AreEqual("Процентная", discount.DiscountType);
        }

        /// <summary>
        /// Тестирование свойства DiscountValue
        /// </summary>
        [Test]
        [TestCase(
            1000, 10, 100, 
            TestName = 
                "DiscountValue: 1000 * 10% = 100"
        )]
        [TestCase(
            5000, 20, 1000, 
            TestName = 
                "DiscountValue: 5000 * 20% = 1000"
        )]
        [TestCase(
            100, 0, 0, 
            TestName = 
                "DiscountValue: 100 * 0% = 0"
        )]
        [TestCase(
            100, 100, 100, 
            TestName = 
                "DiscountValue: 100 * 100% = 100"
        )]
        [TestCase(
            2500, 15, 375, 
            TestName = 
                "DiscountValue: 2500 * 15% = 375"
        )]
        public void DiscountValueTest(
            double originPrice, double percent, double expected)
        {
            var discount = new PercentDiscount
            {
                OriginPrice = originPrice,
                Percent = percent
            };
            Assert.AreEqual(expected, discount.DiscountValue, DiscountBaseTest.Tolerance);
        }

        /// <summary>
        /// Тестирование свойства DiscountPrice
        /// </summary>
        [Test]
        [TestCase(
            1000, 10, 900, 
            TestName = 
                "DiscountPrice: 1000 - 10% = 900"
        )]
        [TestCase(
            5000, 20, 4000, 
            TestName = 
                "DiscountPrice: 5000 - 20% = 4000"
        )]
        [TestCase(
            100, 0, 100, 
            TestName = 
                "DiscountPrice: 100 - 0% = 100"
        )]
        [TestCase(
            100, 100, 0, 
            TestName = 
                "DiscountPrice: 100 - 100% = 0"
        )]
        [TestCase(
            2000, 25, 1500, 
            TestName = 
                "DiscountPrice: 2000 - 25% = 1500"
        )]
        public void DiscountPriceTest(
            double originPrice, double percent, double expected)
        {
            var discount = new PercentDiscount
            {
                OriginPrice = originPrice,
                Percent = percent
            };
            Assert.AreEqual(expected, discount.DiscountPrice, DiscountBaseTest.Tolerance);
        }
    }
}