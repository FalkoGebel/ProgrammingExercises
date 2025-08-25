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

        /// <summary>
        /// Solution for basic exercise number 9.
        /// </summary>
        /// <param name="first">First number for average of four.</param>
        /// <param name="second">Second number for average of four.</param>
        /// <param name="third">Third number for average of four.</param>
        /// <param name="fourth">Fourth number for average of four.</param>
        /// <returns>The average of the four given numbers.</returns>
        public static int AverageOfFourNumbers(int first, int second, int third, int fourth)
            => (first + second + third + fourth) / 4;

        /// <summary>
        /// Solution for basic exercise number 10.
        /// </summary>
        /// <param name="x">First number for the specified formulas.</param>
        /// <param name="y">Second number for the specified formulas.</param>
        /// <param name="z">Third number for the specified formulas.</param>
        /// <returns>The two results for the two specified formulas of the three given numbers.</returns>
        public static (int result1, int result2) SpecifiedFormulaWithThreeNumbers(int x, int y, int z)
            => ((x + y) * z, x * y + y * z);

        /// <summary>
        /// Solution for basic exercise number 11.
        /// </summary>
        /// <param name="age">The age to printe the message for.</param>
        /// <returns>The message according to the given age.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string PrintAgeMessage(int age)
        {
            if (age < 0 || age > 120)
            {
                throw new ArgumentException("Age must be between 0 and 120.");
            }

            return age switch
            {
                <= 25 => $"You look older than {age}.",
                <= 70 => $"You look younger than {age}.",
                _ => $"You are quite a good looking {age} old senior citizen."
            };
        }

        /// <summary>
        /// Solution for basic exercise number 12.
        /// </summary>
        /// <param name="number">The number to print repeatedly.</param>
        /// <returns>The printout.</returns>
        public static string RepeatNumberInRows(int number)
            => $"{number} {number} {number} {number}\n{number}{number}{number}{number}\n" +
               $"{number} {number} {number} {number}\n{number}{number}{number}{number}";

        /// <summary>
        /// Solution for basic exercise number 13.
        /// </summary>
        /// <param name="number">The number to print the pattern for.</param>
        /// <returns>The pattern printout.</returns>
        public static string RectanglePatternWithNumber(int number)
        {
            return $"{number}{number}{number}\n" +
                   $"{number}{new string(' ', number.ToString().Length)}{number}\n" +
                   $"{number}{new string(' ', number.ToString().Length)}{number}\n" +
                   $"{number}{new string(' ', number.ToString().Length)}{number}\n" +
                   $"{number}{number}{number}";
        }

        /// <summary>
        /// Solution for basic exercise number 14.
        /// </summary>
        /// <param name="celsius">Temperature in degrees Celsius.</param>
        /// <returns>Temperature in degrees Kelvin and degrees Fahrenheit.</returns>
        public static (int kelvin, int fahrenheit) CelsiusToKelvinAndFahrenheit(int celsius)
            => (celsius + 273, (int)(celsius * 9.0 / 5.0 + 32));

        /// <summary>
        /// Solution for basic exercise number 15.
        /// </summary>
        /// <param name="input">Input string to take the character from.</param>
        /// <param name="index">Index of the character to take from the input string.</param>
        /// <returns>Input string without the removed character.</returns>
        /// <exception cref="ArgumentException">Empty input string or index out of input string bounds.</exception>
        public static string RemoveCharacterByIndex(string input, int index)
        {
            if (input == string.Empty)
                throw new ArgumentException("Input string must not be empty.");

            if (index < 0 || index >= input.Length)
                throw new ArgumentException("Index must be within the bounds of the input string.");

            return $"{input[..index]}{input[(index + 1)..]}";
        }

        /// <summary>
        /// Solution for basic exercise number 16.
        /// </summary>
        /// <param name="input">Input string to swap first and last character for.</param>
        /// <returns>Input string with first and last character swapped.</returns>
        public static string SwapFirstAndLastCharacters(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length == 1)
                return input;

            return $"{input[^1]}{input[1..^1]}{input[0]}";
        }

        /// <summary>
        /// Solution for basic exercise number 17.
        /// </summary>
        /// <param name="input">Input string to add the first character to front and back.</param>
        /// <returns>Input string with first character added to front and back.</returns>
        public static string AddFirstCharacterToFrontAndBack(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return $"{input[0]}{input}{input[0]}";
        }

        /// <summary>
        /// Solution for basic exercise number 18.
        /// </summary>
        /// <param name="first">First number for check.</param>
        /// <param name="second">Second number for check.</param>
        /// <returns>True, if one number is positive and one number is negative. Else false.</returns>
        public static bool CheckPositiveAndNegativePair(double first, double second)
            => first > 0 && second < 0 || first < 0 && second > 0;

        /// <summary>
        /// Solution for basic exercise number 19.
        /// </summary>
        /// <param name="first">First number for operation.</param>
        /// <param name="second">Second number for operation.</param>
        /// <returns>Sum of the two numbers or triple sum, if both numbers are equal.</returns>
        public static int SumOrTripleSumOfIntegers(int first, int second)
            => (first + second) * (first == second ? 3 : 1);

        /// <summary>
        /// Solution for basic exercise number 20.
        /// </summary>
        /// <param name="first">First number for operation.</param>
        /// <param name="second">Second number for operation.</param>
        /// <returns>The absolute difference or doubled, if first number ist greater then the second one.</returns>
        public static int AbsoluteDifferenceOrDoubleIt(int first, int second)
            => Math.Abs(first - second) * (first > second ? 2 : 1);

        /// <summary>
        /// Solution for basic exercise number 21.
        /// </summary>
        /// <param name="first">First number to check.</param>
        /// <param name="second">Second number to check.</param>
        /// <returns><see langword="true"/> if one number or their sum equals 20; otherwise, <see langword="false"/>.</returns>
        public static bool CheckFor20OrSumEquals20(int first, int second)
            => first == 20 || second == 20 || (first + second) == 20;

        /// <summary>
        /// Solution for basic exercise number 22.
        /// </summary>
        /// <param name="number">Number to do the check for.</param>
        /// <returns><see langword="true"/> if the number is in the twenties of 100 or in the twenties of 200; otherwise, <see langword="false"/>.</returns>
        public static bool CheckWithin20Of100Or200(int number)
            => Math.Abs(100 - number) <= 20 || Math.Abs(200 - number) <= 20;

        /// <summary>
        /// Solution for basic exercise number 23.
        /// </summary>
        /// <param name="input">The string to convert to lowercase.</param>
        /// <returns>The lowercased input string.</returns>
        public static string ConvertStringToLowercase(string input) => input.ToLower();

        /// <summary>
        /// Solution for basic exercise number 24.
        /// </summary>
        /// <param name="input">The string to find the longest word in.</param>
        /// <returns>The longest word in the string - first appearence wins.</returns>
        public static string FindLongestWordInString(string input) =>
            input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(w => string.Concat(w.Where(c => char.IsLetter(c) || c == '-')).Trim('-'))
                 .OrderByDescending(w => w.Length)
                 .FirstOrDefault() ?? string.Empty;

        /// <summary>
        /// Solution for basic exercise number 25.
        /// </summary>
        /// <returns>Returns all odd numbers between 1 and 99 - one number per line.</returns>
        public static string PrintOddNumbers1To99() =>
            string.Join("\n", Enumerable.Range(1, 99).Where(n => n % 2 != 0));

        /// <summary>
        /// Solution for basic exercise number 26.
        /// </summary>
        /// <returns>Returns the sum of the first 500 primes.</returns>
        public static int SumOfFirst500Primes()
        {
            int count = 0;
            int number = 1;
            int sum = 0;

            while (count < 500)
            {
                number++;
                if (IsPrime(number))
                {
                    sum += number;
                    count++;
                }
            }

            return sum;
        }

        /// <summary>
        /// Determines whether the specified number is a prime number.
        /// </summary>
        /// <remarks>A prime number is a natural number greater than 1 that is not divisible by any number
        /// other than 1 and itself.</remarks>
        /// <param name="number">The number to evaluate. Must be greater than or equal to 1.</param>
        /// <returns><see langword="true"/> if the specified number is a prime number; otherwise, <see langword="false"/>.</returns>
        private static bool IsPrime(int number)
        {
            if (number == 2)
                return true;

            if (number < 2 || number % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Ceiling(Math.Sqrt(number)); i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Solution for basic exercise number 27.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int SumOfDigitsInInteger(int input)
            => Math.Abs(input).ToString().ToCharArray().Select(c => int.Parse(c.ToString())).Sum();
    }
}