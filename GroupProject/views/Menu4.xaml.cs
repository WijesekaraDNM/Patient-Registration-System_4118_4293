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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroupProject.viewModels;

namespace GroupProject.views
{
    /// <summary>
    /// Interaction logic for Menu4.xaml
    /// </summary>
    public partial class Menu4 : UserControl
    {
        public Menu4()
        {
            DataContext = new Menu4VM();
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            typeBox.Clear();
            amountBox.Clear();
            totalAmountBox.Clear();

        }

        private void PID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text.StartsWith("0"))
            {
                textBox.Text = textBox.Text.TrimStart('0');
            }
        }

        private void PID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        private void totalAmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text.StartsWith("0"))
            {
                textBox.Text = textBox.Text.TrimStart('0');
            }
        }

        private void totalAmountBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

        private void amountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text.StartsWith("0"))
            {
                textBox.Text = textBox.Text.TrimStart('0');
            }
        }

        private void amountBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
