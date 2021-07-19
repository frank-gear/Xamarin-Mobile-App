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
        public static IList<Models.TermClass> termList;
        public static IList<Models.CourseClass> courseList;
        public static CourseClass SelectedCourse;
        public static TermClass SelectedTerm;

       

       
        
        public TermPage()
        {
            
            InitializeComponent();
            
            //term list setup
            UpdateTermPicker();

            //course list setup
            UpdateCourseList();
                    
            //class picker list


        }
        public void UpdateCourseList()
        {
            courseList = SqlLiteDatabaseService.GetCoursesList();
            CourseSelection.ItemsSource = (System.Collections.IList)courseList;
            AddTermPage.addCourseList = SqlLiteDatabaseService.GetCoursesList();
            CourseSelection.ItemDisplayBinding = new Binding("CourseTitle");


        }

        public void UpdateTermPicker()
        {
            termList = SqlLiteDatabaseService.GetTermsList();
            TermSelection.ItemsSource = (System.Collections.IList)termList;
            TermSelection.SelectedIndex = -1;
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

        private async void Delete_Clicked(object sender, EventArgs e)
        {

            TermClass selectedTerm = (TermClass)TermSelection.SelectedItem;

            bool answer = await (DisplayAlert("DeleteTerm", " delete this term?", "Yes", "No"));

            if (answer == true)
            {
                //var termid = selectedTerm.TermId;
                SqlLiteDatabaseService.DeleteTerm(selectedTerm);

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