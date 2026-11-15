
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;


namespace ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public ICommand NavigateToCalculatorCommand { get; }

        public ICommand NavigateToSecondCalculatorCommand { get; }

        public WelcomeViewModel()
        {
            NavigateToCalculatorCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//CalculatorPage");
            });

            NavigateToSecondCalculatorCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//SecondCalculatorPage");
            });

            Title = "Welcome Page";
        }
    }
}
