using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject.viewModels
{
    public partial class Menu5VM : ObservableObject
    {
        [ObservableProperty]
        public int pID;

        [ObservableProperty]
        public string? pName;

        [ObservableProperty]
        public int pAge;

        [ObservableProperty]
        public string? pGender;

        [ObservableProperty]
        public string? pAddress;

        [ObservableProperty]
        public string? pTNum;

        [ObservableProperty]
        public string? pDate;

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

        public Menu5VM()
        {
            PGenders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female"),
                new string("None")
            };
        }

        public Action clearAction { get;internal set; }

        [RelayCommand]
        public void deletePatient()
        {
            using(var db = new patientContext())
            {
                if(!globalClass.IsRunningTest())
                {
                    if (PName != null)
                    {
                        if (MessageBox.Show("Please Confirm the patient deletion?", "Pateint Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            var pat = db.Patients.Where(p => p.Id == PID).FirstOrDefault();
                            db.Patients.Remove(pat);
                            foreach (Payment pay in db.Payments)
                            {
                                if (pay.patientID == PID)
                                {
                                    db.Payments.Remove(pay);
                                }
                            }
                            db.SaveChanges();
                            clearAction();
                            MessageBoxResult result = MessageBox.Show("Patient details deleted", "Delete Patient", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Patient ID does not exist", "Delete Patient", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    if(PName != null) 
                    {
                        var pat = db.Patients.Where(p => p.Id == PID).FirstOrDefault();
                        db.Patients.Remove(pat);
                        db.SaveChanges();
                    }
                }
               
                
            }
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
                    PAge = pat.Age;
                    PAddress = pat.Address;
                    PDate = pat.AdmittedDate;
                    PGender = pat.Gender;
                    PWNo = pat.WardNo;
                    PDoctor = pat.Doctor;

                }
                else
                {
                    if(!globalClass.IsRunningTest())
                    {
                        MessageBoxResult searchResult = MessageBox.Show("Patient ID not found", "Delete Patient", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }

            }
        }

    }
}
