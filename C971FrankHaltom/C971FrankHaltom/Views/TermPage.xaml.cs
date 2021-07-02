using System;
using C971FrankHaltom.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971FrankHaltom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPage : ContentPage
    {
        public TermPage()
        {
            SqlLiteDatabaseService dataService = new SqlLiteDatabaseService();
            InitializeComponent();

            //term picker list
            var TermList = dataService.GetTerms();
            var CourseList = dataService.GetCourses();
            TermSelection.ItemsSource = TermList;
            CourseSelection.ItemsSource = (System.Collections.IList)dataService.GetCourse();
            AppShell.SelectedTerm = TermSelection.SelectedIndex;
            AppShell.SelectedCourse = CourseSelection.SelectedIndex;


            //class picker list


        }

    }
}