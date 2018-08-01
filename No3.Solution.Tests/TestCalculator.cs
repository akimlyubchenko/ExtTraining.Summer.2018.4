using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;

namespace No3.Solution.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            Calculator calculator = new Calculator();

            double expected = 8.3636363;

            double actual = calculator.CalculateAverage(values, calculator.Mean);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageWidthSomeAlgorithm()
        {
            Calculator calculator = new Calculator();

            double expected = 8.3636363;

            double actual = calculator.CalculateAverage(values, delegate (List<double> values) { return values.Sum() / values.Count; });

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            Calculator calculator = new Calculator();

            double expected = 8.0;

            double actual = calculator.CalculateAverage(values, calculator.Median);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        // Аналогично разбирался, но мозг уже не работает...
        //[Test]
        public void MoqTest()
        {
            Calculator calculator = new Calculator();
            var mock = new Mock<Calculator>();

            calculator.CalculateAverage(values, calculator.Mean);

            // Понимаю, что нужно связать calculator и mock, но не знаю как
            mock.Verify(ca => ca.Mean(It.IsAny<List<double>>()));
        }
    }
}