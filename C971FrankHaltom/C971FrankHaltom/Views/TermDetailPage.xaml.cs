using System;
using C971FrankHaltom.Views;
using C971FrankHaltom.Models;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetailPage : ContentPage
    {
        public TermDetailPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            
            if (TermPage.SelectedTerm == null)
            {
                DisplayAlert("term view", " Please Select a term to view", "ok");
            }
            else
            {
                 SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course1);
                Termtitle.Text = TermPage.SelectedTerm.TermTitle;
                StartDate.Text = TermPage.SelectedTerm.TermStartDate.ToString();
                EndDate.Text = TermPage.SelectedTerm.TermEndtDate.ToString();
                Course1.Text = SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course1);
                Course2.Text = SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course2);
                Course3.Text = SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course3);
                Course4.Text = SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course4);
                Course5.Text = SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course5);
                Course6.Text = SqlLiteDatabaseService.GetCourseTitle(TermPage.SelectedTerm.Course6);
            }


        }
    }
}
