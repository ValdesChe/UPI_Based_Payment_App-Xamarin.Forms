using Prism.Unity;
using Prism.Ioc;
using Prism;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UPIBasedPaymentApp.ViewModel;

namespace UPIBasedPaymentApp
{
    public partial class App : PrismApplication
    {
        public App() : base(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer, setFormsDependencyResolver: true)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Services
            
            // Register Navigation Pages + ViewModels
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await SetMainPageAsync();
        }

        private async Task SetMainPageAsync()
        {
            var isFirstTimeLaunched = true;
            INavigationResult result = null;
            if (isFirstTimeLaunched)
            {
            }

            result = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");

            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }
        }


        private void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            MainPage = new ContentPage
            {
                Content = layout
            };
        }
    }
}
