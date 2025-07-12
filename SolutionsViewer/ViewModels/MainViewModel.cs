using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SolutionsLibrary;

namespace SolutionsViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly List<(string, int, string[])> _tasksBasicExercises = [(Properties.Literals.BasicExercises_01,0,[Properties.Literals.FieldCaption_Name]),
                                                                    (Properties.Literals.BasicExercises_02,1,[])];

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
        private string _inputType0Field1Caption = string.Empty;

        [ObservableProperty]
        private string _inputType0Field1Value = string.Empty;

        [ObservableProperty]
        private string _result = string.Empty;

        [RelayCommand]
        private void ProcessInputType0()
        {
            if (SelectedTask == Properties.Literals.BasicExercises_01)
            {
                Result = BasicExercises.GetHelloAndName(InputType0Field1Value);
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

            InputType0Visible = false;

            if (SelectedCategory == Properties.Literals.Categories_01)
            {
                var task = _tasksBasicExercises.Where(t => t.Item1 == SelectedTask).FirstOrDefault();

                if (task.Item2 == 0)
                {
                    InputType0Field1Caption = task.Item3[0];
                    InputType0Visible = true;
                }
            }
        }
    }
}