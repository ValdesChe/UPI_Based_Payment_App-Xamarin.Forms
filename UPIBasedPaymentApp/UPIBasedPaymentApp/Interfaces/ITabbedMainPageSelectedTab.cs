
using UPIBasedPaymentApp.Enum;

namespace UPIBasedPaymentApp.Interfaces
{
    public interface ITabbedMainPageSelectedTab
    {
        int SelectedTab { get; set; }

        void SetSelectedTab(int tabIndex);
    }
}
