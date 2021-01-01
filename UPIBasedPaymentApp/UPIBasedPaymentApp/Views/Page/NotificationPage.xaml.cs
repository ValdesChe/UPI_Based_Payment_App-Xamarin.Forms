using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UPIBasedPaymentApp.Views.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : BaseContentPage
    {
        private TabbedMainPage _tabPage;
        public NotificationPage()
        {
            InitializeComponent();
        }

        public TabbedMainPage TabPage { get => _tabPage; set => _tabPage = value; }

        protected override bool OnBackButtonPressed()
        {
            if (Device.RuntimePlatform == Device.Android && TabPage != null)
            {
                TabPage.ResetToHomePage();
                return true;
            }
            return base.OnBackButtonPressed();
        }

    }
}