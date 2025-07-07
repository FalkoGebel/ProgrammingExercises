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
    }
}