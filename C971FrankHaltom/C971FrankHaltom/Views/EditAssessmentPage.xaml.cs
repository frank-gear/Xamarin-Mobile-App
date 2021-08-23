using System;
using C971FrankHaltom.Services;
using C971FrankHaltom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAssessmentPage : ContentPage
    {
        public static List<AssessmentClass> assessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetAssessmentsList();
        public EditAssessmentPage()
        {
            InitializeComponent();
            OnAppearing();
        }
        protected override void OnAppearing()
        {

                assessments.Clear();           
                assessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetAssessmentsList();
                Asses.ItemsSource = assessments;
                Asses.ItemDisplayBinding = new Binding("Name");

        }

        private void Asses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AssessmentName.Text = assessments[Asses.SelectedIndex].Name;
            //DueDate.Date = assessments[Asses.SelectedIndex].DueDate;

        }

        private void save_Clicked(object sender, EventArgs e)
        {
            if (AssessmentName.Text == "" || DueDate.Date == null)
            {
                DisplayAlert("Assessment Edit", " Please  fill in all sections", "ok");
            }
            else
            {
                if (Duedateswitch.IsToggled)
                {
                    SqlLiteDatabaseService.CreatePersistantNotification(AssessmentName.Text, "Due Date", DueDate.Date);
                }
                AssessmentClass assessment = new AssessmentClass();
                assessment = assessments[Asses.SelectedIndex];
                assessment.Name = AssessmentName.Text;
                assessment.DueDate = DueDate.Date;
                SqlLiteDatabaseService.ModifyAssessment(assessment);
                DisplayAlert("Assessment Edit", " Modified successfully Please return to the MainPage", "ok");
                Asses.ItemsSource.Clear();
                Asses.SelectedIndex = -1;
                AssessmentName.Text = "";
                assessments = (List<AssessmentClass>)SqlLiteDatabaseService.GetAssessmentsList();
                Asses.ItemsSource = assessments;
                Asses.ItemDisplayBinding = new Binding("Name");
            }
        }
    }
}