using System;
using UPIBasedPaymentApp.Enum;
using UPIBasedPaymentApp.Views.Page;
using Xamarin.Forms;

namespace UPIBasedPaymentApp
{

    public partial class TabbedMainPage : TabbedPage
    {

        private bool _isTabPageVisible;
        private bool _isFirstTimeAppearance =  true;

        public static readonly BindableProperty SelectedTabIndexProperty =
            BindableProperty.Create(
                nameof(SelectedTabIndex),
                typeof(int),
                typeof(TabbedMainPage), (int) TabType.HOME_PAGE,
                BindingMode.TwoWay, null,
                propertyChanged: OnSelectedTabIndexChanged);


        public TabbedMainPage()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.Android)
            {
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetToolbarPlacement(this,
                    Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
            }
        }

        static void OnSelectedTabIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (((TabbedMainPage)bindable)._isTabPageVisible)
            {
                // update the Selected Child-Tab page only if Tabbed Page is visible..
                ((TabbedMainPage)bindable).CurrentPage = ((TabbedMainPage)bindable).Children[(int)newValue];
            }
        }


        public int SelectedTabIndex
        {
            get { return (int)GetValue(SelectedTabIndexProperty); }
            set { SetValue(SelectedTabIndexProperty, value); }
        }



        internal void ResetToHomePage()
        {
            CurrentPage = homePage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // The tabbed page is now visible...
            _isTabPageVisible = true;
            if(_isFirstTimeAppearance)
                _isFirstTimeAppearance = false;
            else
                this.CurrentPage = this.Children[SelectedTabIndex];
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // the Tabbed Page is not visible anymore...
            _isTabPageVisible = false;
        }

        protected override void OnCurrentPageChanged()
        {

            base.OnCurrentPageChanged();
            if (CurrentPage is HomePage homePage)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, true);
            }

            SelectedTabIndex = this.Children.IndexOf(this.CurrentPage);
        }
    }
}
