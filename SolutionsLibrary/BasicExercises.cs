






namespace SolutionsLibrary
{
    public static class BasicExercises
    {
        /// <summary>
        /// Solution for basic exercise number 1.
        /// </summary>
        /// <param name="name">The name to print.</param>
        /// <returns>The text to output.</returns>
        public static string GetHelloAndName(string name) => $"Hello: {name}";

        /// <summary>
        /// Solution for basic exercise number 2.
        /// </summary>
        /// <param name="summand1">The first summand.</param>
        /// <param name="summand2">The second summand.</param>
        /// <returns>The sum of the given summands.</returns>
        public static double SumOfTwoNumbers(double summand1, double summand2) => summand1 + summand2;

        /// <summary>
        /// Solution for basic exercise number 3.
        /// </summary>
        /// <param name="dividend">The dividend for the division.</param>
        /// <param name="divisor">The divisor for the division.</param>
        /// <returns>The quotient for the division.</returns>
        public static double DivideTwoNumbers(double dividend, double divisor) => dividend / divisor;

        /// <summary>
        /// Solution for basic exercise number 4.
        /// </summary>
        /// <returns>The four results for the fix operations.</returns>
        public static (int, int, int, int) SpecifiedOperationsResults()
            => (-1 + 4 * 6, (35 + 5) % 7, 14 + -4 * 6 / 11, 2 + 15 / 6 * 1 - 7 % 2);

        /// <summary>
        /// Solution for basic exercise number 5.
        /// </summary>
        /// <param name="first">First number to swap.</param>
        /// <param name="second">Second number to swap.</param>
        /// <returns>Swapped numbers -> first second and second first.</returns>
        public static (double, double) SwapTwoNumbers(double first, double second) => (second, first);

        /// <summary>
        /// Solution for basic exercise number 6.
        /// </summary>
        /// <param name="factor1">First factor for multiplication.</param>
        /// <param name="factor2">Second factor for multiplication.</param>
        /// <param name="factor3">Third factor for multiplication.</param>
        /// <returns>The Product for the multiplication.</returns>
        public static double MultiplyThreeNumbers(double factor1, double factor2, double factor3) => factor1 * factor2 * factor3;

        /// <summary>
        /// Solution for basic exercise number 7.
        /// </summary>
        /// <param name="first">First number for operations.</param>
        /// <param name="second">Second number for operations.</param>
        /// <returns>The five results for the operations - addition, subtraction, multiplication, division and modulo.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static (int result1, int result2, int result3, int result4, int result5) ArithmeticOperations(int first, int second)
        {
            if (second == 0)
            {
                throw new ArgumentException("The second number must not be zero because of the division.");
            }

            return (first + second, first - second, first * second, first / second, first % second);
        }

        /// <summary>
        /// Solution for basic exercise number 8.
        /// </summary>
        /// <param name="number">The number to return the multiplication table for.</param>
        /// <returns>The multiplication table for the given number</returns>
        public static string MultiplicationTable(int number)
            => string.Join("\n", Enumerable.Range(0, 11).Select(i => $"{number} x {i} = {number * i}"));
    }
}