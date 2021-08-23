using System;
using C971FrankHaltom.Views;
using C971FrankHaltom.Models;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssessmentPage : ContentPage
    {
        public AddAssessmentPage()
        {
            InitializeComponent();
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AssessmentName.Text) || type.SelectedIndex == -1)
            {
                DisplayAlert("AssesmentAdd", " Please Select fill in all sections", "ok");
                return;
            }

            else
            {
                if (Duedateswitch.IsToggled)
                {
                    //CrossLocalNotifications.Current.Show(AssessmentName.Text, "Due Date", 101, DueDate.Date);
                    SqlLiteDatabaseService.CreatePersistantNotification(AssessmentName.Text, "Due Date", DueDate.Date);
                }
                AssessmentClass assessment = new AssessmentClass();
                assessment.Name = AssessmentName.Text;
                assessment.Type = type.SelectedItem.ToString();
                assessment.DueDate = DueDate.Date;
                SqlLiteDatabaseService.CreateAssess(assessment);
                DisplayAlert("Assessment Creation", " Created successfully Please return to the MainPage", "ok");
            }
        }
    }
}