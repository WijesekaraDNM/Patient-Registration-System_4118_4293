using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GroupProject.viewModels
{
    public partial class Menu4VM:ObservableObject
    {
        [ObservableProperty]
        public int pID;

        [ObservableProperty]
        public string? pName;

        [ObservableProperty]
        public string? pType;

        [ObservableProperty]
        public int pAmount;

        [ObservableProperty]
        public int totalSum;

        public ObservableCollection<Payment> _pPayments = new ObservableCollection<Payment>();

        public ObservableCollection<Payment> pPayments { get { return _pPayments; } }
        //public List<Payment>? pPayments;

        [RelayCommand]
        public void displayPays()
        {
            pPayments.Clear();
            TotalSum = 0;
            PName = null;
            using (var db = new patientContext())
            {
                var pat = db.Patients.Find(PID);

                if (pat != null)
                {
                    PName = pat.Name;

                    foreach (Payment entity in db.Payments)
                    {
                        if (entity.patientID == PID)
                        {
                            pPayments.Add(entity);
                        }
                    }

                    TotalSum = pPayments.Sum(pat => pat.amount);

                }
                else
                {
                    MessageBoxResult resultFind = MessageBox.Show("Patient Not Found","Payments",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            
            }
        }

        [RelayCommand]
        public void addPayment()
        {
            using (var db = new patientContext())
            {
                Payment newPay = new Payment(PType, PAmount, PID);

                db.Payments.Add(newPay);
                db.SaveChanges();

            }

            displayPays();
        }
    }
}
