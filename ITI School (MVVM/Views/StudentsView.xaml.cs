using ITI_School__MVVM.Models;
using ITI_School__MVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ITI_School__MVVM.Views
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class StudentsView : Window
    {
        public StudentsView()
        {
            InitializeComponent();
            StudentsViewModel studentsViewModel = new StudentsViewModel();
            this.DataContext = studentsViewModel;
            if (studentsViewModel.CloseActionst == null)
                studentsViewModel.CloseActionst = new Action(this.Close);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            STSAVE.Visibility = Visibility.Visible;
            Subjects.Visibility = Visibility.Hidden;
            Upload.Visibility = Visibility.Visible;
            chkboxs.Visibility = Visibility.Visible;
        }

        private void STSAVE_Click(object sender, RoutedEventArgs e)
        {
            Subjects.Visibility = Visibility.Visible;
            Upload.Visibility = Visibility.Hidden;
            chkboxs.Visibility = Visibility.Hidden;
            STSAVE.Visibility = Visibility.Hidden;
        }
        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            string oldcontent = Subjects.Text;
            string content = (string)(((CheckBox)sender).Content);
            if (oldcontent =="")
            {
                Subjects.Text=content;
            }
            else
            {
            Subjects.Text = oldcontent + " + " + content;
            }
        }
        private void CheckBox1_notChecked(object sender, RoutedEventArgs e)
        {
            string oldcontent = Subjects.Text;
            string content = (string)(((CheckBox)sender).Content);
            Subjects.Text = oldcontent.Replace(" + " + content, "");
        }
    }
}
