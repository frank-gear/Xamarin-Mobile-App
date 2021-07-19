using C971FrankHaltom.Services;
using C971FrankHaltom.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
