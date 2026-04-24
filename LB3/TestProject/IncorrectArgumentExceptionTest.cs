using NUnit.Framework;
using Var5;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса IncorrectArgumentException
    /// </summary>
    [TestFixture]
    public class IncorrectArgumentExceptionTest
    {
        /// <summary>
        /// Тестирование конструктора
        /// </summary>
        [Test]
        [TestCase(
            "Тестовое сообщение об ошибке", 
            TestName = 
                "Тестирование сообщения при присваивании обычного текста."
        )]
        [TestCase(
            "Ошибка", 
            TestName = 
                "Тестирование сообщения при присваивании короткого текста."
            )]
        [TestCase(
            "Значение не может быть задано отрицательным.", 
            TestName = 
                "Тестирование сообщения при присваивании длинного текста."
        )]
        [TestCase(
            "", 
            TestName = 
                "Тестирование сообщения при присваивании пустой строки."
        )]
        [TestCase(
            "  ", 
            TestName = 
                "Тестирование сообщения при присваивании пробелов."
        )]
        public void ConstructorTest(string message)
        {
            var exception = new IncorrectArgumentException(message);
            Assert.AreEqual(message, exception.Message);
            Assert.IsInstanceOf<Exception>(exception);
        }
    }
}