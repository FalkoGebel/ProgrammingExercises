using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SolutionsLibrary;

namespace SolutionsViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly List<(string, int, string[])> _tasksBasicExercises = [
            (Properties.Literals.BasicExercises_01,0,[Properties.Literals.FieldCaption_Name]),
            (Properties.Literals.BasicExercises_02,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_03,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_04,2,[]),
            (Properties.Literals.BasicExercises_05,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2]),
            (Properties.Literals.BasicExercises_06,3,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2, Properties.Literals.FieldCaption_Number3]),
            (Properties.Literals.BasicExercises_07,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2])
        ];

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
        private string _selectedTask = string.Empty;

        [ObservableProperty]
        private List<string> _tasks = [];

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
        private string _result = string.Empty;

        [RelayCommand]
        private void ProcessInputType0()
        {
            if (SelectedTask == Properties.Literals.BasicExercises_01)
            {
                Result = BasicExercises.GetHelloAndName(InputField1Value);
            }
        }

        [RelayCommand]
        private void ProcessInputType1()
        {
            if (!double.TryParse(InputField1Value, out double number1) || !double.TryParse(InputField2Value, out double number2))
            {
                Result = Properties.Literals.Error_InvalidNumbers;
                return;
            }

            if (SelectedTask == Properties.Literals.BasicExercises_02)
            {
                Result = $"{number1} {(number2 >= 0 ? '+' : '-')} {Math.Abs(number2)} = {BasicExercises.SumOfTwoNumbers(number1, number2)}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_03)
            {
                Result = $"{number1} / {number2} = {BasicExercises.DivideTwoNumbers(number1, number2)}";
            }
            else if (SelectedTask == Properties.Literals.BasicExercises_05)
            {
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
                    (int result1, int result2, int result3, int result4, int result5) = BasicExercises.ArithmeticOperations((int)number1, (int)number2);

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
        }

        private void EvaluateSelectedCategory()
        {
            if (SelectedCategory == Properties.Literals.Categories_01)
                Tasks = [.. _tasksBasicExercises.Select(t => t.Item1)];
            else
                Tasks = [];
        }

        private void EvaluateSelectedTask()
        {
            // Input types
            // 0: one string
            // 1: two numbers
            // 2: no input
            // 3: three numbers

            InputType0Visible = false;
            InputType1Visible = false;
            InputType2Visible = false;
            InputType3Visible = false;
            InputField1Value = string.Empty;
            InputField2Value = string.Empty;
            InputField3Value = string.Empty;

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
            }
        }
    }
}