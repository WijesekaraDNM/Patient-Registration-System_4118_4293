using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GroupProject.viewModels
{
    public partial class Menu2VM:ObservableObject
    {
        [ObservableProperty]
        public int pID;

        [ObservableProperty]
        public string? pName;

        [ObservableProperty]
        public int pAge;

        [ObservableProperty]
        public string? pTNum;

        [ObservableProperty]
        public string? pDate;

        [ObservableProperty]
        public string? pAddress;

        [ObservableProperty]
        public string? pGuard;

        [ObservableProperty]
        public string? pGTeleNum;

        [ObservableProperty]
        public string? pGender;

        [ObservableProperty]
        public string? pWNo;

        [ObservableProperty]
        public string? pDoctor;

        public ObservableCollection<string> pGenders = new ObservableCollection<string>();

        public ObservableCollection<string> PGenders
        {
            get { return pGenders; }
            set { pGenders = value; }
        }

        public Menu2VM()
        {
            PGenders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female"),
                new string("None")
            };
        }

        [RelayCommand]
        public void searchPaient()
        {
            using (var db = new patientContext())
            {
                var pat = db.Patients.Find(PID);

                if (pat != null)
                {
                    PName = pat.Name;
                    PAge = pat.Age;
                    PTNum = pat.TeleNumber;
                    PDate = pat.AdmittedDate;                   
                    PAddress = pat.Address;
                    PGuard = pat.Guardian;
                    PGTeleNum = pat.GuardianTeleNum;
                    PGender = pat.Gender;               
                    PWNo = pat.WardNo;
                    PDoctor = pat.Doctor;
                }
                else
                {

                    if (!globalClass.IsRunningTest())
                    {
                        MessageBoxResult searchResult = MessageBox.Show("Patient ID not found","Read Patient",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }

            }
        }
    }
}
