using ITI_School__MVVM.Command;
using ITI_School__MVVM.Models;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ITI_School__MVVM.ViewModel
{
    public class TeachersViewModel : INotifyPropertyChanged
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
        public TeachersViewModel()
        {
            TeachersList = new ObservableCollection<Teachers>()
            { new Teachers() { Id=1 , Name="Ahmed Sayed" , Subject=Subject.Math , Image="/Resources/Teachers/01.png" , Gendar=Gendar.Male  },
              new Teachers() { Id=2 , Name="Sayed Khaled" , Subject=Subject.Arabic , Image="/Resources/Teachers/02.jpg" , Gendar=Gendar.Male  },
              new Teachers() { Id=3 , Name="Sally Saeed" , Subject=Subject.English , Image="/Resources/Teachers/03.jpg" , Gendar=Gendar.Female  },
              new Teachers() { Id=4 , Name="Rana Ahmed" , Subject=Subject.Physics , Image="/Resources/Teachers/04.jpeg" , Gendar=Gendar.Female  }
            };
            GendarList = new ObservableCollection<Gendar>() { Gendar.Male, Gendar.Female };
            SubjectList = new ObservableCollection<Subject>() { Subject.Arabic, Subject.Chemistry, Subject.English, Subject.Math , Subject.Physics };
            AddNew = new MyCommand(AddNewTeacher, CanAddNewTeacher);
            SaveNew = new MyCommand(SaveNewTeacher, CanSaveNewTeacher);
            Remove = new MyCommand(RemoveTeacher, CanRemoveTeacher);
            UploadPhoto = new MyCommand(UploadPhotoTeacher, CanUploadPhotoTeacher);
            BackToMain = new MyCommand(BackToMainTeacher, CanBackToMainTeacher);
        }
        #endregion
        #region Property
        public ObservableCollection<Teachers> TeachersList { get; set; }
        public ObservableCollection<Gendar> GendarList { get; set; }
        public ObservableCollection<Subject> SubjectList { get; set; }
        public MyCommand AddNew { get; set; }
        public MyCommand SaveNew { get; set; }
        public MyCommand Remove { get; set; }
        public MyCommand UploadPhoto { get; set; }
        public MyCommand BackToMain { get; set; }
        public Action CloseAction { get; set; }
        private Teachers _selectedItem;
        public string TeacherName { get; set; }
        public Gendar TeacherGender { get; set; }
        public int TeacherId { get; set; }
        public string TeacherImage { get; set; }
        public Subject TeacherSubject { get; set; }

        public Teachers SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                try
                {
                    _selectedItem = value;
                    TeacherName = value.Name;
                    TeacherGender = value.Gendar;
                    TeacherId = value.Id;
                    TeacherImage = value.Image;
                    TeacherSubject = value.Subject;
                    OnPropertyChanged("TeacherName");
                    OnPropertyChanged("TeacherGender");
                    OnPropertyChanged("TeacherId");
                    OnPropertyChanged("TeacherImage");
                    OnPropertyChanged("TeacherSubject");

                }
                catch (NullReferenceException)
                {
                }
                
            }
        }
        #endregion
        #region Methods
        public void AddNewTeacher(Object parameter)
        {
            SelectedItem = null;
            TeacherName = "";
            TeacherGender = Gendar.Male;
            TeacherId = 0;
            TeacherImage = "";
            TeacherSubject = Subject.Arabic;
            OnPropertyChanged("SelectedItem");
            OnPropertyChanged("TeacherName");
            OnPropertyChanged("TeacherGender");
            OnPropertyChanged("TeacherId");
            OnPropertyChanged("TeacherImage");
            OnPropertyChanged("TeacherSubject");
            flag = true;
        }
        public bool CanAddNewTeacher(Object parameter)

        {
            return true;
        }
        public void SaveNewTeacher(Object parameter)
        {
            if (flag == true)
            {
                Teachers teacher = new Teachers();
                teacher.Name = TeacherName;
                teacher.Subject = (Subject)TeacherSubject;
                teacher.Gendar = (Gendar)TeacherGender;
                teacher.Id = TeacherId;
                teacher.Image = TeacherImage;
                TeachersList.Add(teacher);
                TeacherName = "";
                TeacherGender = Gendar.Male;
                TeacherId = 0;
                TeacherImage = "";
                TeacherSubject = Subject.Arabic;
                SelectedItem=teacher;
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("TeacherName");
                OnPropertyChanged("TeacherGender");
                OnPropertyChanged("TeacherId");
                OnPropertyChanged("TeacherImage");
                OnPropertyChanged("TeacherSubject");
                MessageBox.Show($" {teacher.Name} added successfully");

                flag = false;
            }
        }
        public bool CanSaveNewTeacher(Object parameter)

        {
            return true;
        }
        public void RemoveTeacher(Object parameter)
        {
            TeachersList.Remove((Teachers)SelectedItem);
            string temp = TeacherName;
            TeacherName = "";
            TeacherGender = Gendar.Male;
            TeacherId = 0;
            TeacherImage = "";
            TeacherSubject = Subject.Arabic;
            OnPropertyChanged("TeacherName");
            OnPropertyChanged("TeacherGender");
            OnPropertyChanged("TeacherId");
            OnPropertyChanged("TeacherImage");
            OnPropertyChanged("TeacherSubject");
            SelectedItem = null;
            OnPropertyChanged("SelectedItemst");
            MessageBox.Show($" {temp} removed successfully");
        }
        public bool CanRemoveTeacher(Object parameter)

        {
            return true;
        }
        public void UploadPhotoTeacher(Object parameter)
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
                    TeacherImage = (new BitmapImage(new Uri(op.FileName))).ToString();
                    OnPropertyChanged("TeacherImage");
                }
            }
        }
        public bool CanUploadPhotoTeacher(Object parameter)

        {
            return true;
        }
        public void BackToMainTeacher(Object parameter)
        {
            MainWindow mainWindow = new MainWindow();
            CloseAction();
            mainWindow.ShowDialog();
        }
        public bool CanBackToMainTeacher(Object parameter)

        {
            return true;
        }
        #endregion
    }
}