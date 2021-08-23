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
    public partial class TermPage : ContentPage
    {
        public static IList<Models.TermClass> termList = SqlLiteDatabaseService.GetTermsList();
        public static IList<Models.CourseClass> courseList = SqlLiteDatabaseService.GetCoursesList();
        public static CourseClass SelectedCourse;
        public static TermClass SelectedTerm;

       

       
        
        public TermPage()
        {
            
            InitializeComponent();
            OnAppearing();


        }
        protected override void OnAppearing()
        {
            courseList.Clear();
            termList.Clear();
            courseList = SqlLiteDatabaseService.GetCoursesList();
            termList = SqlLiteDatabaseService.GetTermsList();
            TermSelection.ItemsSource = (System.Collections.IList)termList;
            TermSelection.ItemDisplayBinding = new Binding("TermTitle");
            CourseSelection.ItemsSource = (System.Collections.IList)courseList;
            CourseSelection.ItemDisplayBinding = new Binding("CourseTitle");
        }


        public void UpdateTermPicker()
        {
            termList.Clear();
            termList = SqlLiteDatabaseService.GetTermsList();
            TermSelection.ItemsSource = (System.Collections.IList)termList;           
            TermSelection.ItemDisplayBinding = new Binding("TermTitle");


        }
        private  void TermSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTerm = (TermClass)TermSelection.SelectedItem;
        }
        private void CourseSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCourse = (CourseClass)CourseSelection.SelectedItem;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (TermSelection.SelectedIndex == -1)
            {
                DisplayAlert("Term Delete", " Please Select term to delete", "ok");
                return;
            }

            else
            {
                TermClass selectedTerm = (TermClass)TermSelection.SelectedItem;
                SqlLiteDatabaseService.DeleteTerm(selectedTerm);
                TermSelection.SelectedIndex = -1;
                UpdateTermPicker();

                

            }
         
           
        }
    }

    //System.Threading.Tasks.Task<IEnumerable<Models.TermClass>> termList = DataClass.GetTermList();
    //term picker list
    //var TermList = dataService.GetTerms();
    //var CourseList = dataService.GetCourses();
    //TermSelection.ItemsSource = TermList;
    //CourseSelection.ItemsSource = (System.Collections.IList)dataService.GetCourse();
    //TermSelection.SetBinding(Picker.ItemsSourceProperty, "TermClass");
    //SqlLiteDatabaseService dataService = new SqlLiteDatabaseService();
}