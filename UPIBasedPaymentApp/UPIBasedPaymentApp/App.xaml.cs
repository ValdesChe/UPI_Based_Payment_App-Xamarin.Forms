using Prism.Unity;
using Prism.Ioc;
using Prism;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UPIBasedPaymentApp.ViewModel;
using UPIBasedPaymentApp.Services.Abstractions;
using UPIBasedPaymentApp.Services;
using UPIBasedPaymentApp.Views.Authentication;
using UPIBasedPaymentApp.Views;
using UPIBasedPaymentApp.Views.Page;

namespace UPIBasedPaymentApp
{

    /**
     * Application starting point
     **/
    public partial class App : PrismApplication
    {
        IStorageService _PreferencesService;
        public App() : base(null) { }
        public App(IPlatformInitializer initializer = null) : base(initializer, setFormsDependencyResolver: true)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Services
            containerRegistry.RegisterSingleton<IStorageService, PreferencesService>();

            // Register Navigation Pages + ViewModels
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<GenerateCodePage, GenerateCodePageViewModel>();
            containerRegistry.RegisterForNavigation<MainHomePageView, MainHomePageViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await SetMainPageAsync();
        }

        /**
         * Set the main page depending on if the user logged in before | not
         **/
        private async Task SetMainPageAsync()
        {
            // Resolve storage service
            _PreferencesService = Container.Resolve<IStorageService>();

            // Get if first time App launched
            var isFirstTimeLaunched = await _PreferencesService.GetAsync<bool>(AppSettings.IsFirstTimeAppLaunched, AppSettings.IsFirstTimeAppLaunchedDefaultValue);
            
            INavigationResult result = null;
            if (isFirstTimeLaunched)
            {
                await _PreferencesService.SaveAsync(AppSettings.IsFirstTimeAppLaunched, false);
                result = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(LoginPage)}");
            }
            else
            {
                result = await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(HomePage)}");
            }


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
