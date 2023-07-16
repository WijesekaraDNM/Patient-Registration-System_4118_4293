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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupProject.views
{
    /// <summary>
    /// Interaction logic for Menu5.xaml
    /// </summary>
    public partial class Menu5 : UserControl
    {
        public Menu5VM vm { get; set; }
        public Menu5()
        {
            InitializeComponent();
            vm = new Menu5VM();
            DataContext = vm;
            vm.clearAction = () => clearText();
        }

      
        public void clearText() 
        {
            PAge.Clear();
            PAddress.Clear();
            PGender.SelectedItem = null;
            PDate.Clear();
            PWNo.Clear();
            PDoctor.Clear();
            PTNum.Clear();
            PName.Clear();
            PID.Clear();
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

        private void PAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text.StartsWith("0"))
            {
                textBox.Text = textBox.Text.TrimStart('0');
            }
        }

        private void PAge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
