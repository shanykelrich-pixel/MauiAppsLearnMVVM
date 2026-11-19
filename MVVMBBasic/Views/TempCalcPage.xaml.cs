using ViewModels;

namespace Views;

public partial class TempCalcPage : ContentPage
{
    

        public TempCalcPage() : this(new TempCalcViewModel())
    {
    }
    

    // קבלת ה-ViewModel ישירות דרך Dependency Injection וחיבור ה-Binding Context
    public TempCalcPage(TempCalcViewModel viewModel)
    {
        InitializeComponent();
       
        BindingContext = viewModel;
    }

}
