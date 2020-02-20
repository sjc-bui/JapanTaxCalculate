using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxCal.Views;
using Xamarin.Forms;

namespace TaxCal.ViewModels {
    public class MainPageViewModel : BaseViewModel {
        public ICommand GoToNext { get; private set; }

        private INavigation _navigation;

        private string _title;

        public string Title {
            get { return _title; }
            set {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private double _price;

        public double Price {
            get { return _price; }
            set {
                if (_price != value) {
                    _price = value;
                    OnPropertyChanged("Price");
                    CalculateTax();
                }
            }
        }

        private double _percent;

        public double Percent {
            get { return _percent; }
            set {
                if (_percent != value) {
                    _percent = value;
                    OnPropertyChanged("Percent");
                    CalculateTax();
                }
            }
        }

        private double _total;

        public double Total {
            get { return _total; }
            set {
                if (_total != value) {
                    _total = value;
                    OnPropertyChanged("Total");
                }
            }
        }

        private void CalculateTax() {
            Percent = Math.Round(Percent*1);

            Total = Math.Round(Price + (Price * (Percent / 100)));
        }

        public MainPageViewModel(INavigation navigation) {
            _navigation = navigation;
            GoToNext = new Command(async () => { await GoToTaxView(); });
            Title = "Main Page";
        }

        private async Task GoToTaxView() {
            await _navigation.PushAsync(new TaxCalculateView());
        }
    }
}
