
using ViewModels;

namespace Views;

public partial class CurrCalcPage : ContentPage
{
    public CurrCalcPage() : this(new CurrCalcViewModel())
    {
    }

    public CurrCalcPage(CurrCalcViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}