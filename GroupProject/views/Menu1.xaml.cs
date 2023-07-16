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
    /// Interaction logic for Menu1.xaml
    /// </summary>
    public partial class Menu1 : UserControl
    {
        public Menu1VM vm { get; set; }

        public Menu1()
        {
            InitializeComponent();
            vm =new Menu1VM();
            DataContext = vm;
            PDate.DisplayDate = DateTime.Now;
            vm.clearAction=()=>clearText();
        }

        public void clearText()
        {
            PName.Clear();
            PAge.Clear();
            PGTeleNum.Clear();
            PGender.SelectedItem = null;
            PDate.SelectedDate = null;
            PTNum.Clear();
            PAddress.Clear();
            PGuard.Clear();
            PGTeleNum.Clear();
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
