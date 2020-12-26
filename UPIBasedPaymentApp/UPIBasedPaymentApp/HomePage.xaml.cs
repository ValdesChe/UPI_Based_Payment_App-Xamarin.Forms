using System.ComponentModel;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace UPIBasedPaymentApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class HomePage : Xamarin.Forms.TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
