using AndroidX.Lifecycle;

namespace MVVMBBasic.Views;

public partial class CurrCalc : ContentPage
{
	public CurrCalc()
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}