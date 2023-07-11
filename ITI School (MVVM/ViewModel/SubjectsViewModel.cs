using ITI_School__MVVM.Command;
using ITI_School__MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ITI_School__MVVM.ViewModel
{
    public class SubjectsViewModel : INotifyPropertyChanged
    {
        #region Fields
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
        public SubjectsViewModel()
        {
            studentsar = new List<Students>() { new Students() { Id=1 , Name="Zizo Ahmed" , Image="/Resources/Students/01.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + English + Math"  },
              new Students() { Id=2 , Name="gaser sameh" , Image="/Resources/Students/02.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=4 , Name="lyly maher" , Image="/Resources/Students/04.jpg" , Gendar=Gendar.Female, Subjlist="Arabic + Physics + Chemstry"  }
            };
            studentsch = new List<Students>() {
              new Students() { Id=2 , Name="gaser sameh" , Image="/Resources/Students/02.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=3 , Name="lolo mohamed" , Image="/Resources/Students/03.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  },
              new Students() { Id=4 , Name="lyly maher" , Image="/Resources/Students/04.jpg" , Gendar=Gendar.Female, Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=5 , Name="Rana  yehia" , Image="/Resources/Students/05.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  }
            };
            studentsen = new List<Students>() { new Students() { Id=1 , Name="Zizo Ahmed" , Image="/Resources/Students/01.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + English + Math"  }
            };
            studentsma = new List<Students>() { new Students() { Id=1 , Name="Zizo Ahmed" , Image="/Resources/Students/01.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + English + Math"  },
              new Students() { Id=3 , Name="lolo mohamed" , Image="/Resources/Students/03.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  },
              new Students() { Id=5 , Name="Rana  yehia" , Image="/Resources/Students/05.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  }
            };
            studentsph = new List<Students>() {
              new Students() { Id=2 , Name="gaser sameh" , Image="/Resources/Students/02.jpg" , Gendar=Gendar.Male , Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=3 , Name="lolo mohamed" , Image="/Resources/Students/03.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  },
              new Students() { Id=4 , Name="lyly maher" , Image="/Resources/Students/04.jpg" , Gendar=Gendar.Female, Subjlist="Arabic + Physics + Chemstry"  },
              new Students() { Id=5 , Name="Rana  yehia" , Image="/Resources/Students/05.jpg" , Gendar=Gendar.Female, Subjlist="Chemstry + Physics + Math"  }
            };
            SubjectsList = new ObservableCollection<Subjects>()
            { new Subjects("Arabic"),
              new Subjects("Chemistry"),
              new Subjects("English"),
              new Subjects("Math"),
              new Subjects("Physics")
            };
            AddNewsu = new MyCommand(AddNewSubject, CanAddNewSubject);
            SaveNewsu = new MyCommand(SaveNewSubject, CanSaveNewSubject);
            BackToMain = new MyCommand(BackToMainSubject, CanBackToMainSubject);
            Removesu = new MyCommand(RemoveSubject, CanRemoveSubject);

        }
        #endregion
        #region Parametars
        public ObservableCollection<Subjects> SubjectsList { get; set; }
        public MyCommand BackToMain { get; set; }
        public MyCommand AddNewsu { get; set; }
        public MyCommand SaveNewsu { get; set; }
        public MyCommand Removesu { get; set; }

        public List<Students> studentsar { get; set; }
        public List<Students> studentsch { get; set; }
        public List<Students> studentsen { get; set; }
        public List<Students> studentsma { get; set; }
        public Action CloseActionsu { get; set; }
        public string NewSubjectName { get; set; }

        public List<Students> studentsph { get; set; }
        public List<Students> DatagridData { get; set; }
        private Subjects _selectedSubject;
        public Subjects SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                try
                {
                    _selectedSubject = value;
                    if (value.Name == "Arabic")
                    {
                        DatagridData = studentsar;
                    }
                    else if (value.Name == "Chemistry")
                    {
                        DatagridData = studentsch;
                    }
                    else if (value.Name == "English")
                    {
                        DatagridData = studentsen;
                    }
                    else if (value.Name == "Math")
                    {
                        DatagridData = studentsma;

                    }
                    else if (value.Name == "Physics")
                    {
                        DatagridData = studentsph;
                    }
                    else
                    {
                        DatagridData = new List<Students>();
                    }
                    OnPropertyChanged("DatagridData");
                }
                catch (NullReferenceException)
                {
                }

            }
        }
        #endregion
        #region Methods
        public void BackToMainSubject(Object parameter)
        {
            MainWindow mainWindow = new MainWindow();
            CloseActionsu();
            mainWindow.ShowDialog();
        }
        public bool CanBackToMainSubject(Object parameter)

        {
            return true;
        }
        public void AddNewSubject(Object parameter)
        {
            NewSubjectName = "";
            OnPropertyChanged("NewSubjectName");
            SelectedSubject = null;
            DatagridData = new List<Students>();
            OnPropertyChanged("SelectedSubject");
            OnPropertyChanged("DatagridData");
            flag = true;
        }
        public bool CanAddNewSubject(Object parameter)

        {
            return true;
        }
        public void SaveNewSubject(Object parameter)
        {
            if (flag == true)
            {
                Subjects subject = new Subjects();
                subject.Name = NewSubjectName;
                SubjectsList.Add(subject);
                NewSubjectName = "";
                OnPropertyChanged("NewSubjectName");
                SelectedSubject = subject;
                OnPropertyChanged("SelectedSubject");
                MessageBox.Show($" {subject.Name} added successfully");
                flag = false;
            }
        }
        public bool CanSaveNewSubject(Object parameter)

        {
            return true;
        }
        public void RemoveSubject(Object parameter)
        {
            SubjectsList.Remove((Subjects)SelectedSubject);
            OnPropertyChanged("SelectedSubject");
            SelectedSubject = null;
            DatagridData = new List<Students>();
            NewSubjectName = "";
            OnPropertyChanged("NewSubjectName");
            OnPropertyChanged("SelectedSubject");
            OnPropertyChanged("DatagridData");
        }
        public bool CanRemoveSubject(Object parameter)

        {
            return true;
        }
        #endregion


    }
}
