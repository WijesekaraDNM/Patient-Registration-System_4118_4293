using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GroupProject.viewModels
{
    public partial class Menu1VM:ObservableObject
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
        public BitmapImage pImage;

        public ObservableCollection<string> pGenders = new ObservableCollection<string>();

        public ObservableCollection<string> PGenders
        {
            get { return pGenders; }
            set { pGenders = value; }
        }

        public DbContextOptions<patientContext> options = null;

        public Menu1VM()
        {
            PGenders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female"),
                new string("None")
            };
        }

        public Action clearAction { get; internal set; }

        [RelayCommand]
        public void insertPatient()
        {
            if((PName==null)&&(PGTeleNum==null)&&(PGender == null)&&(PDate == null)&&(PTNum == null)&&(PAddress == null)&&(PGuard == null)&&(PGTeleNum == null)&&(PAge==null))
            {
                MessageBoxResult result = MessageBox.Show("Give all neccessary details","Warnning",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else 
            {
                PDate = AdmittedDate.ToString().Substring(0, 10);

                Patient patient = new Patient()
                {
                    Id = PID,
                    Name = PName,
                    Age = PAge,
                    Address = PAddress,
                    TeleNumber = PTNum,
                    AdmittedDate = PDate,
                    Gender = PGender,
                    Guardian = PGuard,
                    PatientType = "Not Given",
                    WardNo = "Not Given",
                    payments = 0,
                    GuardianTeleNum = PGTeleNum,
                    Doctor = "Not Given",
                    InsuredName = "Not Given",
                    InsuaranceCom = "Not Given",
                    InsuranceComeNum = "Not Given",
                    InsurancePolicy = "Not Given",
                    InsuranceRelation = "Not Given",
                    InsuranceGroup = "Not Given",
                    //PatientImage = PImage
                };

                using (var dbP = new patientContext())
                {
                    dbP.Database.EnsureCreated();
                    dbP.Patients.Add(patient);
                    dbP.SaveChanges();
                }

                if (!globalClass.IsRunningTest())
                {
                    clearAction();

                    MessageBoxResult insertResult = MessageBox.Show("Resistration Successful","Registration",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
        }

        
        [RelayCommand]
        public void uploadImage() //just a function.Not used.
        { 
            OpenFileDialog dialog= new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if(dialog.ShowDialog()==true)
            {
                PImage= new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Image is successfully uploaded!","Successful",MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
