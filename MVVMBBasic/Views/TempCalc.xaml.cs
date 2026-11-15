using ViewModels;

namespace Views;

public partial class TempCalc : ContentPage
{
    

        public TempCalc() : this(new TempCalcViewModel())
    {
    }
    

    // קבלת ה-ViewModel ישירות דרך Dependency Injection וחיבור ה-Binding Context
    public TempCalc(TempCalcViewModel viewModel)
    {
        InitializeComponent();
       
        BindingContext = viewModel;
    }

}
