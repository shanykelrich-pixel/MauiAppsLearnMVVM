
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public ICommand NavigateToCalculatorCommand { get; }
        public ICommand NavigateToSecondCalculatorCommand { get; }
        public ICommand NavigateToTempCalcCommand { get; }

        public WelcomeViewModel()
        {
            Title = "Welcome Page";

            NavigateToCalculatorCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//CalculatorPage");
            });

            NavigateToSecondCalculatorCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//SecondCalculatorPage");
            });
            NavigateToTempCalcCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//Calculators/TempCalcPage");
            });
        }
    }
}
