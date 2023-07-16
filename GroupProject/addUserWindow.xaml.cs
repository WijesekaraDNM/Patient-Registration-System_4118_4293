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
using GroupProject.viewModels;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for addUserWindow.xaml
    /// </summary>
    public partial class addUserWindow : Window
    {
        public addUserWindow()
        {
            InitializeComponent();
            var vm = new addUserVM();
            this.DataContext = vm;
            if (vm.closeAction == null)
            {
                vm.closeAction = new Action(this.Close);
            }
            vm.clearAction = () => clearText();
        }

        private void clearText()
        {
            Pname.Clear();
            usPass.Clear();
            AccessLvlBox.SelectedItem = null;
        }
    }
}
