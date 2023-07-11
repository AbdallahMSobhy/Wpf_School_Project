using ITI_School__MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ITI_School__MVVM.Views
{
    /// <summary>
    /// Interaction logic for Teachers.xaml
    /// </summary>
    public partial class TeachersView : Window
    {
        public MainWindowViewModel temainWindow;
        public TeachersView()
        {
            InitializeComponent();
            TeachersViewModel teachersViewModel = new TeachersViewModel();
            this.DataContext = teachersViewModel;
            if (teachersViewModel.CloseAction == null)
                teachersViewModel.CloseAction = new Action(this.Close);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SAVE.Visibility = Visibility.Visible;
            Upload.Visibility= Visibility.Visible;

        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            Upload.Visibility = Visibility.Hidden;
            SAVE.Visibility = Visibility.Hidden;
        }
    }
}
