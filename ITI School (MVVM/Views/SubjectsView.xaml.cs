using ITI_School__MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class SubjectsView : Window
    {
        public SubjectsView()
        {
            InitializeComponent();
            SubjectsViewModel subjectsViewModel = new SubjectsViewModel();
            this.DataContext = subjectsViewModel;
            if (subjectsViewModel.CloseActionsu == null)
                subjectsViewModel.CloseActionsu = new Action(this.Close);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hs.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hs.Visibility = Visibility.Hidden;
        }
    }
}
