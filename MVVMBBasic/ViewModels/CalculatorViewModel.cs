
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        private string _number1 = "";
        private string _number2 = "";
        private string _result = "0";

        public string Number1
        {
            get => _number1;
            set
            {
                if (_number1 != value)
                {
                    _number1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Number2
        {
            get => _number2;
            set
            {
                if (_number2 != value)
                {
                    _number2 = value;
                    OnPropertyChanged();
                }
            }
        }



        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        public CalculatorViewModel()
        {
            Title = "מחשבון";

            AddCommand = new Command(() => Calculate("+"));
            SubtractCommand = new Command(() => Calculate("-"));
            MultiplyCommand = new Command(() => Calculate("*"));
            DivideCommand = new Command(() => Calculate("/"));
        }

        private async void Calculate(string operation)
        {
            bool isNum1Valid = double.TryParse(Number1, out double num1);
            bool isNum2Valid = double.TryParse(Number2, out double num2);

            if (!isNum1Valid || !isNum2Valid)
            {
                await Shell.Current.DisplayAlertAsync(
                    "קלט לא תקין",
                    "אנא הכנס מספרים תקינים בשתי התיבות",
                    "אישור");

                return;
            }

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;

                case "-":
                    result = num1 - num2;
                    break;

                case "*":
                    result = num1 * num2;
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        await Shell.Current.DisplayAlertAsync(
                            "שגיאה",
                            "לא ניתן לחלק באפס!",
                            "אישור");

                        Result = "שגיאה";
                        return;
                    }

                    result = num1 / num2;
                    break;
            }

            Result = result.ToString();
        }
    }
}
