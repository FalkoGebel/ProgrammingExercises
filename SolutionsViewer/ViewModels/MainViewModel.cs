using CommunityToolkit.Mvvm.ComponentModel;

namespace SolutionsViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly List<(string, int)> _tasksBasicExercises = [(Properties.Literals.Tasks_01_BasicExercises_01,0),
                                                                    (Properties.Literals.Tasks_01_BasicExercises_02,1)];

        [ObservableProperty]
        private string _selectedCategory = string.Empty;

        partial void OnSelectedCategoryChanged(string? oldValue, string newValue)
        {
            if (oldValue == null || newValue != oldValue)
                EvaluateSelectedCategory();
        }

        [ObservableProperty]
        private List<string> _categories = [Properties.Literals.Categories_01_BasicExercises, "Second Category"];

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

        private void EvaluateSelectedCategory()
        {
            if (SelectedCategory == Properties.Literals.Categories_01_BasicExercises)
                Tasks = [.. _tasksBasicExercises.Select(t => t.Item1)];
            else
                Tasks = [];
        }

        private void EvaluateSelectedTask()
        {
            // Input types
            // 0: one string

            InputType0Visible = false;

            if (SelectedCategory == Properties.Literals.Categories_01_BasicExercises)
            {
                if (_tasksBasicExercises.Where(t => t.Item1 == SelectedTask).First().Item2 == 0)
                {
                    InputType0Visible = true;
                }
            }
        }
    }
}