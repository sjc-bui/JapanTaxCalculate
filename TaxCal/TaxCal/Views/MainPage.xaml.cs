using TaxCal.ViewModels;
using Xamarin.Forms;

namespace TaxCal {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }
    }
}
