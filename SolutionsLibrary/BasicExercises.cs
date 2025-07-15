



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
        /// Solution for basic exercise number 5.
        /// </summary>
        /// <param name="first">First number to swap.</param>
        /// <param name="second">Second number to swap.</param>
        /// <returns>Swapped numbers -> first second and second first.</returns>
        public static (double, double) SwapTwoNumbers(double first, double second) => (second, first);
    }
}