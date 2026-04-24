using NUnit.Framework;
using Var5;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса CertificateDiscount
    /// </summary>
    [TestFixture]
    public class CertificateDiscountTest
    {
        /// <summary>
		/// Отклонение для double
		/// </summary>
		private const double Deviation = 0.01;

        /// <summary>
        /// Тестирование свойства CertificateAmount
        /// </summary>
        [Test]
        [TestCase(
            1, 
            TestName = 
                "Тестирование CertificateAmount: " +
                "при присваивании небольшой суммы сертификата 1."
        )]
        [TestCase(
            100, 
            TestName = 
                "Тестирование CertificateAmount: " +
                "при присваивании суммы сертификата 100."
        )]
        [TestCase(
            5000, 
            TestName = 
                "Тестирование CertificateAmount: " +
                "при присваивании суммы сертификата 5000."
        )]
        [TestCase(
            0.01, 
            TestName =
                "Тестирование CertificateAmount: " +
                "при присваивании дробной суммы сертификата 0.01."
        )]
        [TestCase(
            999999, 
            TestName = 
                "Тестирование CertificateAmount:" +
                " при присваивании большой суммы сертификата 999999."
        )]
        public void CertificateAmountTest(double amount)
        {
            var discount = new CertificateDiscount();
            discount.CertificateAmount = amount;
            Assert.AreEqual(amount, discount.CertificateAmount);
        }

        [Test]
        [TestCase(
            0, 
            TestName = 
                "Тестирование CertificateAmount: " +
                "при присваивании суммы сертификата 0."
        )]
        [TestCase(
            -1, 
            TestName =
                "Тестирование CertificateAmount: " +
                "при присваивании отрицательной суммы сертификата -1."
        )]
        [TestCase(
            -100, 
            TestName =
                "Тестирование CertificateAmount: " +
                "при присваивании отрицательной суммы сертификата -100."
        )]
        [TestCase(
            -0.01, 
            TestName =
                "Тестирование CertificateAmount: " +
                "при присваивании отцрицательной " +
                "дробной суммы сертификата -0.01."
        )]
        [TestCase(
            double.NaN, 
            TestName = 
                "Тестирование CertificateAmount: " +
                "при присваивании NaN."
        )]
        public void CertificateAmountNegativeTest(double amount)
        {
            var discount = new CertificateDiscount();
            Assert.Throws<IncorrectArgumentException>(
                () => discount.CertificateAmount = amount);
        }

        /// <summary>
        /// Тестирование свойства DiscountType
        /// </summary>
        [Test]
        public void DiscountTypeTest()
        {
            var discount = new CertificateDiscount();
            Assert.AreEqual("Сертификат", discount.DiscountType);
        }

        /// <summary>
        /// Тестирование свойства DiscountValue
        /// </summary>
        [Test]
        [TestCase(
            1000, 100, 100, 
            TestName = 
                "DiscountValue: сертификат 100 < цена 1000"
        )]
        [TestCase(
            5000, 500, 500, 
            TestName = 
                "DiscountValue: сертификат 500 < цена 5000"
        )]
        [TestCase(
            100, 50, 50, 
            TestName = 
                "DiscountValue: сертификат 50 < цена 100"
        )]
        [TestCase(
            2000, 1000, 1000, 
            TestName = 
                "DiscountValue: сертификат 1000 < цена 2000"
        )]
        [TestCase(
            750, 250, 250, 
            TestName = 
                "DiscountValue: сертификат 250 < цена 750"
        )]
        public void DiscountValueTest(
            double originPrice, double certAmount, double expected)
        {
            var discount = new CertificateDiscount
            {
                OriginPrice = originPrice,
                CertificateAmount = certAmount
            };
            Assert.AreEqual(expected, discount.DiscountValue, Deviation);
        }
        [Test]
        [TestCase(
            100, 500, 100, 
            TestName = 
                "DiscountValue: сертификат 500 > цена 100"
        )]
        [TestCase(
            1000, 2000, 1000, 
            TestName = 
                "DiscountValue: сертификат 2000 > цена 1000"
        )]
        [TestCase(
            500, 1000, 500, 
            TestName = 
                "DiscountValue: сертификат 1000 > цена 500"
        )]
        public void DiscountValueCertificateGreaterThanPriceTest(
            double originPrice, double certAmount, double expected)
        {
            var discount = new CertificateDiscount
            {
                OriginPrice = originPrice,
                CertificateAmount = certAmount
            };
            Assert.AreEqual(expected, discount.DiscountValue, Deviation);
        }

        /// <summary>
        /// Тестирование свойства DiscountPrice
        /// </summary>
        [Test]
        [TestCase(
            1000, 100, 900, 
            TestName = 
                "DiscountPrice: 1000 - 100 = 900"
        )]
        [TestCase(
            5000, 500, 4500, 
            TestName = 
                "DiscountPrice: 5000 - 500 = 4500"
        )]
        [TestCase(
            100, 100, 0, 
            TestName = 
                "DiscountPrice: 100 - 100 = 0"
        )]
        [TestCase(
            1000, 1500, 0, 
            TestName = 
                "DiscountPrice: сертификат больше цены = 0"
        )]
        [TestCase(
            2000, 300, 1700, 
            TestName = 
                "DiscountPrice: 2000 - 300 = 1700"
        )]
        public void DiscountPriceTest(
            double originPrice, double certAmount, double expected)
        {
            var discount = new CertificateDiscount
            {
                OriginPrice = originPrice,
                CertificateAmount = certAmount
            };
            Assert.AreEqual(expected, discount.DiscountPrice, Deviation);
        }
    }
}