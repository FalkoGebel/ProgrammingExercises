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
    }
}