using ITI_School__MVVM.Command;
using ITI_School__MVVM.Views;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ITI_School__MVVM.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Implentation INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Constructor
        public MainWindowViewModel()
        {
            TeachersWin = new MyCommand(OpenTeachersWin, CanOpenTeachersWin);
            SubjectsWin = new MyCommand(OpenSubjectsWin, CanOpenSubjectsWin);
            StudentsWin = new MyCommand(OpenStudentsWin, CanOpenStudentsWin);
        }
        #endregion
        #region Property
        public MyCommand TeachersWin { get; set; }
        public MyCommand SubjectsWin { get; set; }
        public MyCommand StudentsWin { get; set; }
        public Action CloseAction { get; set; }


        #endregion
        #region Methods
        public void OpenTeachersWin(Object parameter)
        {
            TeachersView temainWindow = new TeachersView();
            CloseAction();
            temainWindow.ShowDialog();
        }

        public bool CanOpenTeachersWin(Object parameter)
        {
            return true;
        }
        public void OpenSubjectsWin(Object parameter)
        {
            SubjectsView sumainWindow = new SubjectsView();
            CloseAction();
            sumainWindow.ShowDialog();
        }

        public bool CanOpenSubjectsWin(Object parameter)

        {
            return true;
        }
        public void OpenStudentsWin(Object parameter)
        {
            StudentsView stmainWindow = new StudentsView();
            CloseAction();
            stmainWindow.ShowDialog();
        }

        public bool CanOpenStudentsWin(Object parameter)

        {
            return true;
        }
        #endregion
    }
}
