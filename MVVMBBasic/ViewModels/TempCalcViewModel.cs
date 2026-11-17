
using System.Windows.Input;

namespace ViewModels
{
    public class TempCalcViewModel : BaseViewModel
    {
        private double temperature;
        private double result;

        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged();
            }
        }

        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateTemperatureCommand { get; }

        public TempCalcViewModel()
        {
            Title = "דף חישוב טמפרטורה";

            CalculateTemperatureCommand = new Command(ConvertTemp);
        }

        public void ConvertTemp()
        {
            double celsius = (Temperature - 32) * 5 / 9;
            Result = celsius;
        }
    }
}
