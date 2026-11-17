using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Google.Crypto.Tink.Signature;

namespace ViewModels
{
    public class CurrCalcViewModel : BaseViewModel
    {
        private string _amount = "";
        private string result = "";

        private string _fromCurrency = "ILS";
        private string _toCurrency = "USD";
        public List<string> Currencis { get; set; } = new List<string> { "ILS", "USD", "EUR", "GBP" };
        private Dictionary<string, double> exchangeRates = new Dictionary<string, double>
        {
            { "ILS", 1.0 },
            { "USD", 0.29 },
            { "EUR", 0.25 },
            { "GBP", 0.21 }
        };
        public string Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Result
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FromCurrency
        {
            get => _fromCurrency;
            set
            {
                if (_fromCurrency != value)
                {
                    _fromCurrency = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ToCurrency
        {
            get => _toCurrency;
            set
            {
                if (_toCurrency != value)
                {
                    _toCurrency = value;
                    OnPropertyChanged();
                }
            }
            
        }
        public ICommand ConvertCommand { get; }
        public CurrCalcViewModel()
        {
            ConvertCommand= new Command(ConvertCurrency);
        }
        private void ConvertCurrency()
        {
            if (double.TryParse(Amount, out double amountValue))
            {
                double fromRate = exchangeRates[FromCurrency];
                double toRate = exchangeRates[ToCurrency];
                double convertedAmount = amountValue * (toRate / fromRate);
                Result = convertedAmount.ToString("F2");
            }
            else
            {
                Result = "Invalid input";
            }
        }
        public event PropertyChangingEventHandler? PropertyChanging;
        protected void OnPropertyChanging([CallerMemberName] string? propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }



    }

}

