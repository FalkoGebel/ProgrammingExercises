using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SolutionsLibrary;

namespace SolutionsViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly int tasksPerPage = 10;
        private readonly List<(string, int, string[])> _tasksBasicExercises = [
            (Properties.Literals.BasicExercises_01,0,[Properties.Literals.FieldCaption_Name]),
            (Properties.Literals.BasicExercises_02,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_03,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_04,2,[]),
            (Properties.Literals.BasicExercises_05,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_06,3,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2, Properties.Literals.FieldCaption_Number3]),
            (Properties.Literals.BasicExercises_07,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_08,0,[Properties.Literals.FieldCaption_Number]),
            (Properties.Literals.BasicExercises_09,4,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2, Properties.Literals.FieldCaption_Number3, Properties.Literals.FieldCaption_Number4]),
            (Properties.Literals.BasicExercises_10,3,[Properties.Literals.FieldCaption_NumberX, Properties.Literals.FieldCaption_NumberY, Properties.Literals.FieldCaption_NumberZ]),
            (Properties.Literals.BasicExercises_11,0,[Properties.Literals.FieldCaption_Age]),
            (Properties.Literals.BasicExercises_12,0,[Properties.Literals.FieldCaption_Number]),
            (Properties.Literals.BasicExercises_13,0,[Properties.Literals.FieldCaption_Number]),
            (Properties.Literals.BasicExercises_14,0,[Properties.Literals.FieldCaption_Celsius]),
            (Properties.Literals.BasicExercises_15,1,[Properties.Literals.FieldCaption_InputString, Properties.Literals.FieldCaption_Index]),
            (Properties.Literals.BasicExercises_16,0,[Properties.Literals.FieldCaption_InputString]),
            (Properties.Literals.BasicExercises_17,0,[Properties.Literals.FieldCaption_InputString]),
            (Properties.Literals.BasicExercises_18,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_19,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_20,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_21,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_22,0,[Properties.Literals.FieldCaption_Number]),
            (Properties.Literals.BasicExercises_23,0,[Properties.Literals.FieldCaption_InputString]),
            (Properties.Literals.BasicExercises_24,0,[Properties.Literals.FieldCaption_InputString]),
            (Properties.Literals.BasicExercises_25,2,[]),
        ];

        private int currentPage;
        private List<string> _tasks = [];

        [ObservableProperty]
        private string _selectedCategory = string.Empty;

        partial void OnSelectedCategoryChanged(string? oldValue, string newValue)
        {
            if (oldValue == null || newValue != oldValue)
                EvaluateSelectedCategory();
        }

        [ObservableProperty]
        private List<string> _categories = [Properties.Literals.Categories_01];

        [ObservableProperty]
        private string _currentPageInfoText = string.Empty;

        [ObservableProperty]
        private List<string> _tasksCurrentPage = [];

        [ObservableProperty]
        private string _selectedTask = string.Empty;

        partial void OnSelectedTaskChanged(string? oldValue, string newValue)
        {
            if (oldValue == null || newValue != oldValue)
                EvaluateSelectedTask();
        }

        [ObservableProperty]
        private bool _inputType0Visible;

        [ObservableProperty]
        private bool _inputType1Visible;

        [ObservableProperty]
        private bool _inputType2Visible;

        [ObservableProperty]
        private bool _inputType3Visible;

        [ObservableProperty]
        private bool _inputType4Visible;

        [ObservableProperty]
        private string _inputField1Caption = string.Empty;

        [ObservableProperty]
        private string _inputField1Value = string.Empty;

        [ObservableProperty]
        private string _inputField2Caption = string.Empty;

        [ObservableProperty]
        private string _inputField2Value = string.Empty;

        [ObservableProperty]
        private string _inputField3Caption = string.Empty;

        [ObservableProperty]
        private string _inputField3Value = string.Empty;

        [ObservableProperty]
        private string _inputField4Caption = string.Empty;

        [ObservableProperty]
        private string _inputField4Value = string.Empty;

        [ObservableProperty]
        private string _result = string.Empty;

        [RelayCommand]
        private void PreviousPage()
        {
            currentPage--;
            UpdateTasksForCurrentPage();
        }

        [RelayCommand]
        private void NextPage()
        {
            currentPage++;
            UpdateTasksForCurrentPage();
        }

        [RelayCommand]
        private void ProcessInputType0()
        {
            if (SelectedTask == Properties.Literals.BasicExercises_01)
            {
                Result = BasicExercises.GetHelloAndName(InputField1Value);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_08)
            {
                if (!int.TryParse(InputField1Value, out int number))
                {
                    Result = Properties.Literals.Error_InvalidNumbers;
                    return;
                }
                Result = BasicExercises.MultiplicationTable(number);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_11)
            {
                if (!int.TryParse(InputField1Value, out int age))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }
                try
                {
                    Result = BasicExercises.PrintAgeMessage(age);
                }
                catch (ArgumentException ae)
                {
                    Result = ae.Message;
                }
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_12)
            {
                if (!int.TryParse(InputField1Value, out int number))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }
                Result = BasicExercises.RepeatNumberInRows(number);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_13)
            {
                if (!int.TryParse(InputField1Value, out int number))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }
                Result = BasicExercises.RectanglePatternWithNumber(number);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_14)
            {
                if (!int.TryParse(InputField1Value, out int celsius))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }
                (int kelvin, int fahrenheit) = BasicExercises.CelsiusToKelvinAndFahrenheit(celsius);
                Result = $"{celsius}° Celsius corresponds to {kelvin}° Kelvin and {fahrenheit}° Fahrenheit.";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_16)
            {
                Result = BasicExercises.SwapFirstAndLastCharacters(InputField1Value);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_17)
            {
                Result = BasicExercises.AddFirstCharacterToFrontAndBack(InputField1Value);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_22)
            {
                if (!int.TryParse(InputField1Value, out int number))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }

                Result = $"{number} is number is in the twenties of 100 or in the twenties of 200: " +
                    $"{BasicExercises.CheckWithin20Of100Or200(number)}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_23)
            {
                Result = BasicExercises.ConvertStringToLowercase(InputField1Value);
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_24)
            {
                Result = BasicExercises.FindLongestWordInString(InputField1Value);
            }
        }

        [RelayCommand]
        private void ProcessInputType1()
        {
            if (SelectedTask == Properties.Literals.BasicExercises_02)
            {
                if (!double.TryParse(InputField1Value, out double number1) || !double.TryParse(InputField2Value, out double number2))
                {
                    Result = Properties.Literals.Error_InvalidNumbers;
                    return;
                }

                Result = $"{number1} {(number2 >= 0 ? '+' : '-')} {Math.Abs(number2)} = {BasicExercises.SumOfTwoNumbers(number1, number2)}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_03)
            {
                if (!double.TryParse(InputField1Value, out double number1) || !double.TryParse(InputField2Value, out double number2))
                {
                    Result = Properties.Literals.Error_InvalidNumbers;
                    return;
                }

                Result = $"{number1} / {number2} = {BasicExercises.DivideTwoNumbers(number1, number2)}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_05)
            {
                if (!double.TryParse(InputField1Value, out double number1) || !double.TryParse(InputField2Value, out double number2))
                {
                    Result = Properties.Literals.Error_InvalidNumbers;
                    return;
                }

                (double first, double second) = BasicExercises.SwapTwoNumbers(number1, number2);
                Result = $"Number 1: {first}\nNumber 2: {second}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_07)
            {
                if (!int.TryParse(InputField1Value, out int numberInteger1) || !int.TryParse(InputField2Value, out int numberInteger2))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }

                try
                {
                    (int result1, int result2, int result3, int result4, int result5) = BasicExercises.ArithmeticOperations((int)numberInteger1, (int)numberInteger2);

                    Result = $"{numberInteger1} + {numberInteger2} = {result1}\n" +
                             $"{numberInteger1} - {numberInteger2} = {result2}\n" +
                             $"{numberInteger1} x {numberInteger2} = {result3}\n" +
                             $"{numberInteger1} / {numberInteger2} = {result4}\n" +
                             $"{numberInteger1} % {numberInteger2} = {result5}";
                }
                catch (ArgumentException ae)
                {
                    Result = $"{ae.Message}";
                }
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_15)
            {
                if (!int.TryParse(InputField2Value, out int index))
                {
                    Result = $"{Properties.Literals.Error_InvalidIndex} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }

                try
                {
                    Result = BasicExercises.RemoveCharacterByIndex(InputField1Value, index);
                }
                catch (ArgumentException ae)
                {
                    Result = $"{ae.Message}";
                }
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_18)
            {
                if (!double.TryParse(InputField1Value, out double number1) || !double.TryParse(InputField2Value, out double number2))
                {
                    Result = Properties.Literals.Error_InvalidNumbers;
                    return;
                }

                Result = $"The numbers {number1} and {number2} are " +
                    $"{(BasicExercises.CheckPositiveAndNegativePair(number1, number2) ? "" : "NOT ")}a positive and negative pair.";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_19)
            {
                if (!int.TryParse(InputField1Value, out int numberInteger1) || !int.TryParse(InputField2Value, out int numberInteger2))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }

                Result = $"The sum or triple sum of {numberInteger1} and {numberInteger2} is " +
                    $"{BasicExercises.SumOrTripleSumOfIntegers(numberInteger1, numberInteger2)}.";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_20)
            {
                if (!int.TryParse(InputField1Value, out int numberInteger1) || !int.TryParse(InputField2Value, out int numberInteger2))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }

                Result = $"The absolute difference or doubled of {numberInteger1} and {numberInteger2} is " +
                    $"{BasicExercises.AbsoluteDifferenceOrDoubleIt(numberInteger1, numberInteger2)}.";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_21)
            {
                if (!int.TryParse(InputField1Value, out int numberInteger1) || !int.TryParse(InputField2Value, out int numberInteger2))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }

                Result = $"{numberInteger1} and {numberInteger2} => " +
                    $"{BasicExercises.CheckFor20OrSumEquals20(numberInteger1, numberInteger2)}";
            }
        }

        [RelayCommand]
        private void ProcessInputType2()
        {
            if (SelectedTask == Properties.Literals.BasicExercises_04)
            {
                (int result1, int result2, int result3, int result4) = BasicExercises.SpecifiedOperationsResults();

                Result = $"-1 + 4 * 6\t\t=\t{result1}\n" +
                         $"(35 + 5) % 7\t\t=\t{result2}\n" +
                         $"14 + -4 * 6 / 11\t\t=\t{result3}\n" +
                         $"2 + 15 / 6 * 1 - 7 % 2\t=\t{result4}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_25)
            {
                Result = BasicExercises.PrintOddNumbers1To99();
            }
        }

        [RelayCommand]
        private void ProcessInputType3()
        {
            if (!double.TryParse(InputField1Value, out double number1) ||
                !double.TryParse(InputField2Value, out double number2) ||
                !double.TryParse(InputField3Value, out double number3))
            {
                Result = Properties.Literals.Error_InvalidNumbers;
                return;
            }

            if (SelectedTask == Properties.Literals.BasicExercises_06)
            {
                Result = $"{number1} x {number2} x {number3} = {BasicExercises.MultiplyThreeNumbers(number1, number2, number3)}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_10)
            {
                if (!int.TryParse(InputField1Value, out int x) ||
                    !int.TryParse(InputField2Value, out int y) ||
                    !int.TryParse(InputField3Value, out int z))
                {
                    Result = $"{Properties.Literals.Error_InvalidNumbers} {Properties.Literals.Error_IntegersOnly}";
                    return;
                }
                (int result1, int result2) = BasicExercises.SpecifiedFormulaWithThreeNumbers(x, y, z);
                Result = $"({x} + {y}) * {z} = {result1}\n{x} * {y} + {y} * {z} = {result2}";
            }
        }

        [RelayCommand]
        private void ProcessInputType4()
        {
            if (!int.TryParse(InputField1Value, out int number1) ||
                !int.TryParse(InputField2Value, out int number2) ||
                !int.TryParse(InputField3Value, out int number3) ||
                !int.TryParse(InputField4Value, out int number4))
            {
                Result = Properties.Literals.Error_InvalidNumbers;
                return;
            }

            if (SelectedTask == Properties.Literals.BasicExercises_09)
                Result = $"Average of {number1}, {number2}, {number3} and {number4} = {BasicExercises.AverageOfFourNumbers(number1, number2, number3, number4)}";
        }

        private void EvaluateSelectedCategory()
        {
            if (SelectedCategory == Properties.Literals.Categories_01)
                _tasks = [.. _tasksBasicExercises.Select(t => t.Item1)];
            else
                _tasks = [];

            currentPage = 1;
            UpdateTasksForCurrentPage();
        }

        private void UpdateTasksForCurrentPage()
        {
            if (currentPage <= 0)
            {
                currentPage = 1;
                return;
            }

            int maxNumberOfPages = (int)Math.Ceiling((double)_tasks.Count / tasksPerPage);

            if (currentPage > maxNumberOfPages)
            {
                currentPage = maxNumberOfPages;
                return;
            }

            int startIndex = (currentPage - 1) * tasksPerPage;
            TasksCurrentPage = [.. _tasks.Skip(startIndex).Take(tasksPerPage)];
            CurrentPageInfoText = $"{startIndex + 1} {Properties.Literals.PageInfoText_To} " +
                $"{(startIndex + tasksPerPage < _tasks.Count ? startIndex + tasksPerPage : _tasks.Count)} " +
                $"{Properties.Literals.PageInfoText_Of} {_tasks.Count}";
        }

        private void EvaluateSelectedTask()
        {
            // Input types
            // 0: one field
            // 1: two fields
            // 2: no input
            // 3: three fields
            // 4: four fields

            InputType0Visible = false;
            InputType1Visible = false;
            InputType2Visible = false;
            InputType3Visible = false;
            InputType4Visible = false;
            InputField1Value = string.Empty;
            InputField2Value = string.Empty;
            InputField3Value = string.Empty;
            InputField4Value = string.Empty;
            Result = string.Empty;

            if (string.IsNullOrEmpty(SelectedTask))
                return;

            if (SelectedCategory == Properties.Literals.Categories_01)
            {
                var task = _tasksBasicExercises.Where(t => t.Item1 == SelectedTask).FirstOrDefault();

                if (task.Item2 == 0)
                {
                    InputField1Caption = task.Item3[0];
                    InputType0Visible = true;
                }
                else if (task.Item2 == 1)
                {
                    InputField1Caption = task.Item3[0];
                    InputField2Caption = task.Item3[1];
                    InputType1Visible = true;
                }
                else if (task.Item2 == 2)
                {
                    InputType2Visible = true;
                }
                else if (task.Item2 == 3)
                {
                    InputField1Caption = task.Item3[0];
                    InputField2Caption = task.Item3[1];
                    InputField3Caption = task.Item3[2];
                    InputType3Visible = true;
                }
                else if (task.Item2 == 4)
                {
                    InputField1Caption = task.Item3[0];
                    InputField2Caption = task.Item3[1];
                    InputField3Caption = task.Item3[2];
                    InputField4Caption = task.Item3[3];
                    InputType4Visible = true;
                }
            }
        }
    }
}