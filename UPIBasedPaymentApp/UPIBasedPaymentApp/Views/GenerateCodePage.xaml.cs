using UPIBasedPaymentApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UPIBasedPaymentApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateCodePage : ContentPage
    {
        public GenerateCodePage()
        {
            InitializeComponent();
        }


        protected override bool OnBackButtonPressed()
        {
            GenerateCodePageViewModel _vm = BindingContext as GenerateCodePageViewModel;
            if (_vm != null) {
                _vm.BackToCommand.Execute();
                return true;
            }
            return base.OnBackButtonPressed();
        }
    }
}