using ViewModels;

namespace Views;

public partial class TaskPage : ContentPage
{


    public TaskPage() : this(new TaskItemViewModel())
    {
    }


    // קבלת ה-ViewModel ישירות דרך Dependency Injection וחיבור ה-Binding Context
    public TaskPage(TaskItemViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

}
