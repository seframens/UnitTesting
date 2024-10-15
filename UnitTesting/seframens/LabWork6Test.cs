using TestingLib.Math;

namespace UnitTesting.seframens
{
    public class LabWork6Test
    {
        private readonly BasicCalc _calculator;

        public LabWork6Test()
        {
            _calculator = new BasicCalc();
        }

        //Тестирование метода Factorial() (проверка работы тестов)
        [Fact]
        public void TestFactorial()
        {
            int result = (int)_calculator.Factorial(3);
            Assert.Equal(6, result);
        }


        //Тесты НОК
        [Fact]
        public void LCM_ShouldReturnCorrectValue()
        {
            int result = (int)_calculator.LCM(6, 12);
            Assert.Equal(12, result);
        }

        [Theory]
        [InlineData(6, 12, 12)]
        [InlineData(12, 36, 36)]
        [InlineData(6, 6, 6)]
        public void LCM_Theory(int a, int b, int expectedResult)
        {
            int result = (int)_calculator.LCM(a, b);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LCM_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.LCM(-1, 10));
        }

        // Тесты нахождения корней квадратного уравнения
        [Fact]
        public void SolveQuadraticEquation_ShouldReturnCorrectValue()
        {
            (double?, double?) result = _calculator.SolveQuadraticEquation(-1, 7, 8);
            Assert.Equal((-1, 8), result);
        }

        [Theory]
        [InlineData(-1d, 7d, 8d, -1d, 8d)]
        public void SolveQuadraticEquation_Theory(double a, double b, double c, double? x1, double? x2)
        {
            (double?, double?) result = _calculator.SolveQuadraticEquation(a, b, c);
            Assert.Equal(x1, result.Item1);
            Assert.Equal(x2, result.Item2);
        }

        [Fact]
        public void SolveQuadraticEquation_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.SolveQuadraticEquation(0, 9, 5));
        }
    }
}
