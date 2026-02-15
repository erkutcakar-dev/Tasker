using System.Threading.Tasks;
using Tasker.MVVM.Models;
using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class NewTaskView : ContentPage
{
    public NewTaskView()
    {
        InitializeComponent();
    }

    private async void AddTaskClick(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        var selectedCategory =
            vm.Categories.Where(c => c.IsSelected).FirstOrDefault();

        if (selectedCategory != null)
        {
            var task = new MyTask
            {
                TaskName = vm.Task,
                CategoryId = selectedCategory.Id,
            };

            vm.Tasks.Add(task);
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Please select a category for the task.", "OK");
        }
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string category = await DisplayPromptAsync(
            "New Category",
            "Enter the name of the new category:",
            "OK",
            "Cancel",
            placeholder: "Category name",
            maxLength: 15,
            keyboard: Keyboard.Text);
        

        var r = new Random();
        if (!string.IsNullOrWhiteSpace(category))
        {
           vm.Categories.Add(new Category
            {
                Id = vm.Categories.Max(c => c.Id) + 1,
                Color = Color.FromRgb(r.Next(256), r.Next(256), r.Next(256)).ToHex(),
                CategoryName = category,
               IsSelected = false
            });
        }

    }

}

