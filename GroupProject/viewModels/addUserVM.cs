using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject.viewModels
{
    public partial class addUserVM: ObservableObject
    {
        [ObservableProperty]
        public int userID;

        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string accessLevel;

        public Action closeAction { get; set; }

        public Action clearAction { get;internal set; } 

        public ObservableCollection<string> accessLevels = new ObservableCollection<string>();

        public ObservableCollection<string> AccessLevels
        {
            get { return accessLevels; }
            set { accessLevels = value;}
        }

        public addUserVM()
        {
            AccessLevels = new ObservableCollection<string>()
            {
                new string("Admin"),
                new string("Normal")
            };
        }

        [RelayCommand]
        public void createUser()
        {
            User newUser = new User()
            {
                userId = UserID,
                userName = UserName,
                password = Password,
                accessLevel = AccessLevel
            };

            using (var db = new UserContext())
            {
                //User newUser = new User(UserName, Password, AccessLevel);

                db.Users.Add(newUser);

                if ((userName!=null)&&(password!=null)&&(accessLevel!=null))
                {
                    db.SaveChanges();
                    clearAction();

                    MessageBoxResult messageBoxResult = MessageBox.Show("User created Successful","User Creation",MessageBoxButton.OK,MessageBoxImage.Information);

                    if (messageBoxResult.Equals(MessageBoxResult.OK))
                    {
                        closeAction();
                    }
                }
                else
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Invalid Input","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }

                
            }



         
        }
    }
}
