using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace SolutionsViewer.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        public string selectedCategory = string.Empty;

        [ObservableProperty]
        public List<string> categories = ["Basic Exercises"];

        [RelayCommand]
        public void ProcessCategorySelection()
        {
            MessageBox.Show(SelectedCategory);
        }
    }
}