using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace GroupProject.viewModels
{
    public partial class Menu3VM:ObservableObject
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
        public DateTime? admittedDate;

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

        [ObservableProperty]
        public string? pInComName;

        [ObservableProperty]
        public string? pInComNum;

        [ObservableProperty]
        public string? pInPolicy;

        [ObservableProperty]
        public string? pInGroup;

        [ObservableProperty]
        public string? pInRelation;

        [ObservableProperty]
        public string? pInName;

        public ObservableCollection<string> pGenders = new ObservableCollection<string>();

        public ObservableCollection<string> PGenders
        {
            get { return pGenders; }
            set { pGenders = value; }
        }

        public Menu3VM()
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
                    PTNum = pat.TeleNumber;
                    PAge =pat.Age;
                    PAddress = pat.Address;
                    PGuard = pat.Guardian;
                    PGTeleNum = pat.GuardianTeleNum;
                    PDate = pat.AdmittedDate;
                    PGender = pat.Gender;
                    PWNo = pat.WardNo;
                    PDoctor = pat.Doctor;
                    PInName = pat.InsuredName;
                    PInComName = pat.InsuaranceCom;
                    PInComNum = pat.InsuranceComeNum;
                    PInGroup = pat.InsuranceGroup;
                    PInPolicy = pat.InsurancePolicy;
                    PInRelation = pat.InsuranceRelation;
                }
                else
                {
                    if(!globalClass.IsRunningTest())
                    {
                        MessageBoxResult searchResult = MessageBox.Show("Patient ID not found", "Update Patient", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }

            }
        }

        public Action clearAction { get; internal set; }

        [RelayCommand]
        public void changeDetails()
        {
            using (var db = new patientContext())
            {
                PDate = AdmittedDate.ToString().Substring(0, 10);

                var pat = db.Patients.Where(p => p.Id == PID).FirstOrDefault();

                if (pat != null)
                {
                    pat.Name = PName;
                    pat.TeleNumber = PTNum;
                    pat.Age = PAge;
                    pat.Address = PAddress;
                    pat.Guardian = PGuard;
                    pat.GuardianTeleNum = PGTeleNum;
                    pat.AdmittedDate = PDate;
                    pat.Gender = PGender;
                    pat.WardNo = PWNo;
                    pat.Doctor = PDoctor;
                    pat.InsuredName = PInName;
                    pat.InsuaranceCom = PInComName;
                    pat.InsuranceComeNum = PInComNum;
                    pat.InsuranceGroup = PInGroup;
                    pat.InsurancePolicy = PInPolicy;
                    pat.InsuranceRelation = PInRelation;

                    db.SaveChanges();
                    if(!globalClass.IsRunningTest())
                    {
                        clearAction();
                        MessageBoxResult searchResult = MessageBox.Show("Change completed", "Update Patient", MessageBoxButton.OK, MessageBoxImage.Information);
                    }             
                }
                else
                {
                    if(!globalClass.IsRunningTest())
                    {
                        MessageBoxResult searchResult = MessageBox.Show("Patient ID not found", "Update Patient", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }


            }
        }
    }
}
