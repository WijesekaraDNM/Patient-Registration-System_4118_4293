using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GroupProject
{
    public partial class MainWindowVM:ObservableObject
    {

        [ObservableProperty]
        public string? usName;

        [ObservableProperty]
        public string? passWord;

        public SecureString? password { get;set; }

        [ObservableProperty]
        public string? visibleOption;

        [ObservableProperty]
        public bool notchangeable = false;

        [ObservableProperty]
        public string? confirm;

        public Action closeAction { get; set; }

        [RelayCommand]

        public void verifyUser()
        {
            using (var db = new UserContext())
            {
                bool userFound = db.Users.Any(User => User.userName == UsName && User.password == PassWord); // verify user and password exist

                if (userFound)
                {
                    Notchangeable = true;
                    bool adminAccess = db.Users.Any(User => User.userName == UsName && User.accessLevel == "Admin");

                    if(adminAccess)
                    {
                        Confirm = "Admin User Confirmed";
                        VisibleOption = "Visible";
                        //var newwindowAdmin = new adminWindow();
                        //newwindowAdmin.Show();
                    }
                    else
                    {
                        var newWindow = new SecondWindow();
                        newWindow.Show();
                        closeAction();
                    }
                    
                }
                else
                {
                    MessageBoxResult resultFind = MessageBox.Show("User Not Found","User Creation",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
        }
    }
}

