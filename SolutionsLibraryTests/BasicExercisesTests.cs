using FluentAssertions;
using SolutionsLibrary;

namespace SolutionsLibraryTests
{
    [TestClass]
    public sealed class BasicExercisesTests
    {
        [DataTestMethod]
        [DataRow("Alexandra Abramov")]
        [DataRow("Yolanda Walter Bennish")]
        [DataRow("Marius Cotandrum")]
        public void Exercise_01_input_name_return_correct_output(string name)
        {
            string expected = $"Hello: {name}";

            string result = BasicExercises.GetHelloAndName(name);

            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(5, 10, 15)]
        [DataRow(0.75, -0.01, 0.74)]
        [DataRow(101220, 1937.7752, 103157.7752)]
        public void Exercise_02_input_two_numbers_and_return_sum(double number1, double number2, double sum)
        {
            double result = BasicExercises.SumOfTwoNumbers(number1, number2);

            result.Should().Be(sum);
        }

        [DataTestMethod]
        [DataRow(5, 10, 0.5)]
        [DataRow(0.75, -0.01, -75)]
        [DataRow(20, 4, 5)]
        public void Exercise_03_input_two_numbers_and_return_quotient(double number1, double number2, double quotient)
        {
            double result = BasicExercises.DivideTwoNumbers(number1, number2);

            result.Should().Be(quotient);
        }

        [TestMethod]
        public void Exercise_04_return_correct_results()
        {
            int expectedResult1 = 23,
                expectedResult2 = 5,
                expectedResult3 = 12,
                expectedResult4 = 3;

            (int result1, int result2, int result3, int result4) = BasicExercises.SpecifiedOperationsResults();

            result1.Should().Be(expectedResult1);
            result2.Should().Be(expectedResult2);
            result3.Should().Be(expectedResult3);
            result4.Should().Be(expectedResult4);
        }

        [DataTestMethod]
        [DataRow(5, 10)]
        [DataRow(0.75, -0.01)]
        [DataRow(20, 4)]
        public void Exercise_05_input_two_numbers_and_return_them_swapped(double number1, double number2)
        {
            (double first, double second) = BasicExercises.SwapTwoNumbers(number1, number2);

            first.Should().Be(number2);
            second.Should().Be(number1);
        }

        [DataTestMethod]
        [DataRow(5, 10, 7)]
        [DataRow(0.75, -0.01, 0)]
        [DataRow(20, 4, -0.02)]
        public void Exercise_06_input_three_numbers_and_return_product(double number1, double number2, double number3)
        {
            double expected = number1 * number2 * number3;

            double result = BasicExercises.MultiplyThreeNumbers(number1, number2, number3);

            result.Should().Be(expected);
        }

        [TestMethod]
        public void Exercise_07_second_number_zero_and_throw_exception()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                BasicExercises.ArithmeticOperations(1, 0);
            });
        }

        [DataTestMethod]
        [DataRow(25, 4, 29, 21, 100, 6, 1)]
        [DataRow(2, 2, 4, 0, 4, 1, 0)]
        [DataRow(1, 5, 6, -4, 5, 0, 1)]
        public void Exercise_07_return_correct_results(int number1, int number2, int expected1, int expected2, int expected3, int expected4, int expected5)
        {
            (int result1, int result2, int result3, int result4, int result5) = BasicExercises.ArithmeticOperations(number1, number2);

            result1.Should().Be(expected1);
            result2.Should().Be(expected2);
            result3.Should().Be(expected3);
            result4.Should().Be(expected4);
            result5.Should().Be(expected5);
        }

        [DataTestMethod]
        [DataRow(0, "0 x 0 = 0\n0 x 1 = 0\n0 x 2 = 0\n0 x 3 = 0\n0 x 4 = 0\n0 x 5 = 0\n0 x 6 = 0\n0 x 7 = 0\n0 x 8 = 0\n0 x 9 = 0\n0 x 10 = 0")]
        [DataRow(5, "5 x 0 = 0\n5 x 1 = 5\n5 x 2 = 10\n5 x 3 = 15\n5 x 4 = 20\n5 x 5 = 25\n5 x 6 = 30\n5 x 7 = 35\n5 x 8 = 40\n5 x 9 = 45\n5 x 10 = 50")]
        public void Exercise_08_return_correct_result_string(int number, string expectedResult)
        {
            string result = BasicExercises.MultiplicationTable(number);

            result.Should().Be(expectedResult);
        }

        [DataTestMethod]
        [DataRow(10, 15, 20, 30, 18)]
        [DataRow(17, 23, 11, 99, 37)]
        [DataRow(17, 23, 11, -99, -12)]
        public void Exercise_09_return_correct_result(int number1, int number2, int number3, int number4, int expected)
        {
            int result = BasicExercises.AverageOfFourNumbers(number1, number2, number3, number4);

            result.Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(5, 6, 7, 77, 72)]
        [DataRow(17, 23, 11, 440, 644)]
        public void Exercise_10_return_correct_results(int number1, int number2, int number3, int expected1, int expected2)
        {
            (int result1, int result2) = BasicExercises.SpecifiedFormulaWithThreeNumbers(number1, number2, number3);

            result1.Should().Be(expected1);
            result2.Should().Be(expected2);
        }
    }
}