using Tasker.MVVM.ViewModels;

namespace Tasker.MVVM.Views;

public partial class MainView : ContentPage
{
    private MainViewModel _viewModel = new MainViewModel();
    public MainView()
	{
		InitializeComponent();
		BindingContext = _viewModel;
    }

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

        _viewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel()
            {
                Tasks = _viewModel.Tasks,
                Categories = _viewModel.Categories
            }
        };
        Navigation.PushAsync(taskView);
    }
}