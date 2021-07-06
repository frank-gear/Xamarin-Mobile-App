﻿using System;
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
    public partial class TermPage : ContentPage
    {
        public static IList<Models.TermClass> termList;
        public static IList<Models.CourseClass> courseList;
        public static CourseClass SelectedCourse;
        public static TermClass SelectedTerm;

        public void UpdateCourseList()
        {
            courseList = SqlLiteDatabaseService.GetCoursesList();
            CourseSelection.ItemsSource = (System.Collections.IList)courseList;
            AddTermPage.addCourseList = SqlLiteDatabaseService.GetCoursesList();
            

        }

         public  void UpdateTermPicker()
        {
            termList = SqlLiteDatabaseService.GetTermsList();
            TermSelection.ItemsSource = (System.Collections.IList)termList;
            TermSelection.SelectedIndex = -1;

        }
        public TermPage()
        {
            
            InitializeComponent();
            
            //term list setup
            UpdateTermPicker();

            //course list setup
            UpdateCourseList();
            
           SelectedTerm = (TermClass)TermSelection.SelectedItem;
           SelectedCourse = (CourseClass)CourseSelection.SelectedItem;

            



            //class picker list


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