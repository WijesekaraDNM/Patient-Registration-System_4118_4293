using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class Payment
    {
        public int paymentID { get; set; }
        public string paymentType { get; set; }
        public int amount { get; set; }
        public int patientID { get; set; }

        public Payment(string paymentType, int amount, int patientID)
        {
            this.paymentType = paymentType;
            this.amount = amount;
            this.patientID = patientID;
        }
    }
}
