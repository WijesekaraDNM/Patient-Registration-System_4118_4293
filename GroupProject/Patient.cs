using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GroupProject
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string TeleNumber { get; set; }
        public string AdmittedDate { get; set; }
        public string Gender { get; set; }
        public string Guardian { get; set; }
        public string PatientType { get; set; }
        public string WardNo { get; set; }
        public int payments { get; set; }
        public string GuardianTeleNum { get; set; }
        public string Doctor { get; set; }
        public string InsuredName { get; set; }
        public string InsuaranceCom { get; set; }
        public string InsuranceComeNum { get; set; }
        public string InsurancePolicy { get; set; }
        public string InsuranceRelation { get; set; }
        public string InsuranceGroup { get; set; }
        //public BitmapImage PatientImage { get; internal set; }
    }
}
