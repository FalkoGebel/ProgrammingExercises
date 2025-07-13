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
    }
}