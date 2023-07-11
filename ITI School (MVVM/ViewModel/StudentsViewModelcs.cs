using ITI_School__MVVM.Command;
using ITI_School__MVVM.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ITI_School__MVVM.ViewModel
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        #region fields
        private bool flag = false;
        #endregion
        #region Implentation INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));

        }
        #endregion
        #region Constructor
        public StudentsViewModel()
        {
            StudentsList = new ObservableCollection<Students>()
            { new Students() { Id=1 , Name="Zizo Ahmed" , Image="/Resources/Students/BLPOS.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + English + Math"  },
              new Students() { Id=2 , Name="gaser sameh" , Image="/Resources/Students/02.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=3 , Name="lolo mohamed" , Image="/Resources/Students/03.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  },
              new Students() { Id=4 , Name="lyly maher" , Image="/Resources/Students/04.jpg" , Gendar=Gendar.Female, Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=5 , Name="Rana  yehia" , Image="/Resources/Students/05.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  }
            };
            GendarListst = new ObservableCollection<Gendar>() { Gendar.Male, Gendar.Female };
            AddNewst = new MyCommand(AddNewStudent, CanAddNewStudent);
            SaveNewst = new MyCommand(SaveNewStudent, CanSaveNewStudent);
            Remove = new MyCommand(RemoveStudent, CanRemoveSyudent);
            UploadPhotost = new MyCommand(UploadPhotoStudent, CanUploadPhotoStudent);
            BackToMainst = new MyCommand(BackToMainStudent, CanBackToMainStudent);
        }
        #endregion
        #region Property
        public ObservableCollection<Students> StudentsList { get; set; }
        public ObservableCollection<Gendar> GendarListst { get; set; }

        public MyCommand AddNewst { get; set; }
        public MyCommand SaveNewst { get; set; }
        public MyCommand UploadPhotost { get; set; }
        public MyCommand BackToMainst { get; set; }
        public MyCommand Remove { get; set; }
        public Action CloseActionst { get; set; }
        private Students _selectedItemst;
        public string StudentNamest { get; set; }
        public string StudentSubjectsst { get; set; }
        public Gendar StudentGenderst { get; set; }
        public int StudentIdst { get; set; }
        public string StudentImagest{ get; set; }

        public Students SelectedItemst
        {
            get { return _selectedItemst; }
            set
            {
                try
                {
                _selectedItemst = value;
                StudentNamest = value.Name;
                StudentGenderst = value.Gendar;
                StudentIdst = value.Id;
                StudentSubjectsst = value.Subjlist;
                StudentImagest = value.Image;
                OnPropertyChanged("StudentNamest");
                OnPropertyChanged("StudentGenderst");
                OnPropertyChanged("StudentIdst");
                OnPropertyChanged("StudentSubjectsst");
                OnPropertyChanged("StudentImagest");
                }
                catch (NullReferenceException)
                {
                }
            }
        }


        #endregion
        #region Methods
        public void AddNewStudent(Object parameter)
        {
            SelectedItemst = null;
            StudentNamest = "";
            StudentGenderst = Gendar.Male;
            StudentIdst = 0;
            StudentImagest = "";
            StudentSubjectsst = "";
            OnPropertyChanged("SelectedItemst");
            OnPropertyChanged("StudentNamest");
            OnPropertyChanged("StudentGenderst");
            OnPropertyChanged("StudentIdst");
            OnPropertyChanged("StudentSubjectsst");
            OnPropertyChanged("StudentImagest");
            flag = true;
        }
        public bool CanAddNewStudent(Object parameter)

        {
            return true;
        }
        public void SaveNewStudent(Object parameter)
        {
            if (flag == true)
            {
                Students Student = new Students();
                Student.Name = StudentNamest;
                Student.Gendar = (Gendar)StudentGenderst;
                Student.Id = StudentIdst;
                Student.Image = StudentImagest;
                Student.Subjlist = StudentSubjectsst;
                StudentsList.Add(Student);
                SelectedItemst = Student;
                OnPropertyChanged("SelectedItemst");
                OnPropertyChanged("StudentNamest");
                OnPropertyChanged("StudentGenderst");
                OnPropertyChanged("StudentIdst");
                OnPropertyChanged("StudentSubjectsst");
                OnPropertyChanged("StudentImagest");
                MessageBox.Show($" {Student.Name} added successfully");
                flag = false;
            }
        }
        public bool CanSaveNewStudent(Object parameter)

        {
            return true;
        }
        public void RemoveStudent(Object parameter)
        {
            StudentsList.Remove((Students)SelectedItemst);
            string temp = StudentNamest ;
            StudentNamest = "";
            StudentGenderst = Gendar.Male;
            StudentIdst = 0;
            StudentImagest = "";
            StudentSubjectsst = "";
            OnPropertyChanged("StudentNamest");
            OnPropertyChanged("StudentGenderst");
            OnPropertyChanged("StudentIdst");
            OnPropertyChanged("StudentSubjectsst");
            OnPropertyChanged("StudentImagest");
            SelectedItemst =null;
            OnPropertyChanged("SelectedItemst");
            MessageBox.Show($" {temp} removed successfully");
        }
        public bool CanRemoveSyudent(Object parameter)

        {
            return true;
        }
        public void UploadPhotoStudent(Object parameter)
        {
            if (flag == true)
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
                if (op.ShowDialog() == true)
                {
                    StudentImagest = (new BitmapImage(new Uri(op.FileName))).ToString();
                    OnPropertyChanged("StudentImagest");
                }
            }
        }
        public bool CanUploadPhotoStudent(Object parameter)

        {
            return true;
        }
        public void BackToMainStudent(Object parameter)
        {
            MainWindow mainWindow = new MainWindow();
            CloseActionst();
            mainWindow.ShowDialog();
        }
        public bool CanBackToMainStudent(Object parameter)

        {
            return true;
        }
        #endregion


    }
}
