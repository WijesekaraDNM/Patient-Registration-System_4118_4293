using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroupProject.viewModels;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowVM();
            this.DataContext = vm;
            vm.VisibleOption = "Hidden";
            if (vm.closeAction == null)
            {
                vm.closeAction = new Action(this.Close);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindowAdd = new addUserWindow();
            newWindowAdd.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newWindow = new SecondWindow();
            newWindow.Show();
            this.Close();
        }

        private void adminOption_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            adminOption.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           // adminOption.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textpsswrd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
            {
                ((dynamic)this.DataContext).password = ((PasswordBox)sender).Password.ToString();
            }
        }
    }
}
