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
        TermClass addTerm;
        CourseClass selectCourse;
        public static IList<Models.CourseClass> addCourseList;


        public AddTermPage()
        {
            addCourseList = SqlLiteDatabaseService.GetCoursesList();
            InitializeComponent();
            SetPickers();
        }

        public void SetPickers()
        {
            Course1.ItemsSource = (System.Collections.IList)addCourseList;
            Course2.ItemsSource = (System.Collections.IList)addCourseList;
            Course3.ItemsSource = (System.Collections.IList)addCourseList;
            Course4.ItemsSource = (System.Collections.IList)addCourseList;
            Course5.ItemsSource = (System.Collections.IList)addCourseList;
        }
        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            if (Termtitle.Text == null || Course1.SelectedIndex == -1 || Course2.SelectedIndex == -1 || Course3.SelectedIndex == -1 || Course4.SelectedIndex == -1 || Course5.SelectedIndex == -1 || Course6.SelectedIndex == -1)
            {
                DisplayAlert("Fill", " Please enter all sections", "ok");
            }

            else
                    {
                        addTerm.TermTitle = Termtitle.Text;
                        addTerm.TermStartDate = StartDate.Date;
                        addTerm.TermEndtDate = EndDate.Date;
                        selectCourse = (CourseClass)Course1.SelectedItem;
                        addTerm.Course1 = selectCourse.CourseId;
                        selectCourse = (CourseClass)Course2.SelectedItem;
                        addTerm.Course2 = selectCourse.CourseId;
                        selectCourse = (CourseClass)Course3.SelectedItem;
                        addTerm.Course3 = selectCourse.CourseId;
                        selectCourse = (CourseClass)Course4.SelectedItem;
                        addTerm.Course4 = selectCourse.CourseId;
                        selectCourse = (CourseClass)Course5.SelectedItem;
                        addTerm.Course5 = selectCourse.CourseId;
                        selectCourse = (CourseClass)Course6.SelectedItem;
                        addTerm.Course6 = selectCourse.CourseId;
                        SqlLiteDatabaseService.CreateTerm(addTerm);
                        TermPage.termList = SqlLiteDatabaseService.GetTermsList();
            }
            
        }
    }
}