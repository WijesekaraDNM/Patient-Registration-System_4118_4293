using GroupProject.viewModels;
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
using GroupProject.views;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {       
            InitializeComponent();
            this.Contentctrl.Content = new Menu1();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Contentctrl.Content = new Menu1();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Contentctrl.Content = new Menu3();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Contentctrl.Content = new Menu2();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Contentctrl.Content = new Menu4();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Contentctrl.Content = new Menu5();
        }

        private void menu3ReIntitiate()
        {
            this.Contentctrl.Content = new Menu3();
        }
    }
}
