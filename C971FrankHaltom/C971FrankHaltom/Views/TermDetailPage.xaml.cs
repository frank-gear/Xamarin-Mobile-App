using System;
using C971FrankHaltom.Views;
using C971FrankHaltom.Models;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C971FrankHaltom.ViewModels;
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
            Termtitle.Text = TermPage.SelectedTerm.TermTitle;
            StartDate.Text = TermPage.SelectedTerm.TermStartDate.ToString();
            EndDate.Text = TermPage.SelectedTerm.TermEndtDate.ToString();
            Course1.Text = SqlLiteDatabaseService.GetCourse(TermPage.SelectedTerm.Course1).CourseTitle;
            Course2.Text = SqlLiteDatabaseService.GetCourse(TermPage.SelectedTerm.Course2).CourseTitle;
            Course3.Text = SqlLiteDatabaseService.GetCourse(TermPage.SelectedTerm.Course3).CourseTitle;
            Course4.Text = SqlLiteDatabaseService.GetCourse(TermPage.SelectedTerm.Course4).CourseTitle;
            Course5.Text = SqlLiteDatabaseService.GetCourse(TermPage.SelectedTerm.Course5).CourseTitle;
            Course6.Text = SqlLiteDatabaseService.GetCourse(TermPage.SelectedTerm.Course6).CourseTitle;
        }

       
    }
}