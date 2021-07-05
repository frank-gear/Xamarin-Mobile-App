using System;
using C971FrankHaltom.Services;
using C971FrankHaltom.Models;
using C971FrankHaltom.Views;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTermPage : ContentPage
    {
        TermClass term;
        public AddTermPage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}