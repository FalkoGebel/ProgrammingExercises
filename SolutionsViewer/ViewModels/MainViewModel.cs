using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SolutionsLibrary;

namespace SolutionsViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly List<(string, int, string[])> _tasksBasicExercises = [
            (Properties.Literals.BasicExercises_01,0,[Properties.Literals.FieldCaption_Name]),
            (Properties.Literals.BasicExercises_02,1,[Properties.Literals.FieldCaption_Number1, Properties.Literals.FieldCaption_Number2])
        ];

        [ObservableProperty]
        private string _selectedCategory = string.Empty;

        partial void OnSelectedCategoryChanged(string? oldValue, string newValue)
        {
            if (oldValue == null || newValue != oldValue)
                EvaluateSelectedCategory();
        }

        [ObservableProperty]
        private List<string> _categories = [Properties.Literals.Categories_01, "Second Category"];

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
        private string _inputField1Caption = string.Empty;

        [ObservableProperty]
        private string _inputField1Value = string.Empty;

        [ObservableProperty]
        private string _inputField2Caption = string.Empty;

        [ObservableProperty]
        private string _inputField2Value = string.Empty;

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
            if (SelectedTask == Properties.Literals.BasicExercises_02)
            {
                if (double.TryParse(InputField1Value, out double number1) && double.TryParse(InputField2Value, out double number2))
                    Result = $"{number1} {(number2 >= 0 ? '+' : '-')} {Math.Abs(number2)} = {BasicExercises.SumOfTwoNumbers(number1, number2)}";
                else
                    Result = "Invalid input. Please enter valid numbers.";
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

            InputType0Visible = false;
            InputType1Visible = false;
            InputField1Value = string.Empty;
            InputField2Value = string.Empty;

            if (SelectedCategory == Properties.Literals.Categories_01)
            {
                var task = _tasksBasicExercises.Where(t => t.Item1 == SelectedTask).FirstOrDefault();
                InputField1Caption = task.Item3[0];

                if (task.Item2 == 0)
                {
                    InputType0Visible = true;
                }
                else if (task.Item2 == 1)
                {
                    InputField2Caption = task.Item3[1];
                    InputType1Visible = true;
                }
            }
        }
    }
}