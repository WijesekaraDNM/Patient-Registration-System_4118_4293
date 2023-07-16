using FluentAssertions;
using GroupProject.viewModels;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Windows.Shapes;

namespace GroupProject.test
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
        }

        [Fact]
        public void insertPatient_should_addPatientToDatabase()
        {

            //var options = new DbContextOptionsBuilder<patientContext>()
            //    .UseSqlite($"Data Source = .\\DataBase\\TestPatients.db")
            //    .Options;

            var vm = new Menu1VM();

            vm.PName = "Test";
            vm.PAge = 1;
            vm.PAddress = "TestAddress";
            vm.PTNum = "xxx xxxxxx";
            vm.PDate = "xx/xx/xxxx";
            vm.PGender = "Male";
            vm.PGuard = "TestGuard";
            vm.PGTeleNum = "xxx xxxxxx";
            vm.AdmittedDate = DateTime.Now;

            vm.insertPatient();

            var context = new patientContext();

            using (context)
            {
                context.Database.EnsureCreated();
                context.Patients.Any(Patient => Patient.Name == "Test").Should().BeTrue();
                
                var pat = context.Patients.First();
                context.Patients.Remove(pat);
                context.SaveChanges();
            }
            
        }

        [Fact]
        public void searchPaient_should_SearchInDatabase()
        {
            var vm = new Menu2VM();

            Patient pat1 = new Patient()
            {
                Name = "Test",
                Age = 1,
                Id = 45,
                Address = "Test",
                TeleNumber = "xxx xxxxxxx",
                AdmittedDate = "xx/xx/xxxx",
                Gender = "Test",
                Guardian = "Test",
                PatientType = "Test",
                WardNo = "Test",
                payments = 0,
                GuardianTeleNum = "xxx xxxxxx",
                Doctor = "Test",
                InsuredName = "Test",
                InsuaranceCom = "Test",
                InsuranceComeNum = "Test",
                InsuranceGroup = "Test",
                InsurancePolicy = "Test",
                InsuranceRelation = "Test"
            };

            using(var Db = new patientContext())
            {
                Db.Patients.Add(pat1);
                Db.SaveChanges();
            }

            vm.PID = 45;
            vm.searchPaient();

             Assert.Equal("Test", vm.PName);

            using (var db = new patientContext())//after the test subjects are removed
            {
                db.Patients.Remove(pat1);
                db.SaveChanges();
            }

        }

        [Fact]
        public void changeDetails_should_ChangePatientDetails()
        {
            var vm=new Menu3VM();
            Patient pat2 = new Patient()
            {
                Name = "Test",
                Age = 1,
                Id = 3,
                Address = "Test",
                TeleNumber = "xxx xxxxxxx",
                AdmittedDate = "xx/xx/xxxx",
                Gender = "Test",
                Guardian = "Test",
                PatientType = "Test",
                WardNo = "Test",
                payments = 0,
                GuardianTeleNum = "xxx xxxxxx",
                Doctor = "Test",
                InsuredName = "Test",
                InsuaranceCom = "Test",
                InsuranceComeNum = "Test",
                InsuranceGroup = "Test",
                InsurancePolicy = "Test",
                InsuranceRelation = "Test"
            };

            using (var Db = new patientContext())
            {
                Db.Patients.Add(pat2);
                Db.SaveChanges();
            }

            vm.PID = 3;
            vm.searchPaient();

            if (vm.PName != null)
            {
                Assert.Equal("Test", vm.PName);
            }

            vm.PName = "TEST";
            vm.PAge = 1;
            vm.PAddress = "TESTADDRESS";
            vm.PTNum = "XXX XXXXXXX";
            vm.PDate = "XX/XX/XXXX";
            vm.PGender = "MALE";
            vm.PGuard = "TESTGUARD";
            vm.PGTeleNum = "XXX XXXXXXX";
            vm.AdmittedDate = DateTime.Now;
            vm.PWNo = "TEST";
            vm.PDoctor = "TEST";
            vm.PInName = "TEST";
            vm.PInComName = "TEST";
            vm.PInGroup = "TEST";
            vm.PInPolicy = "TEST";
            vm.PInRelation = "TEST";

            vm.changeDetails();

            using (var context = new patientContext())
            {
                if(context.Patients.Any(Patient=>Patient.Id==3))
                {
                    context.Patients.Any(Patient => Patient.Name == "TEST").Should().BeTrue();
                }

                context.Patients.Remove(pat2);
                context.SaveChanges();

            }
        }

        [Fact]
        public void deletePatient_Should_DeletePatientFromDataBase()
        {
            var vm = new Menu5VM();

            Patient pat1 = new Patient()
            {
                Name = "Test",
                Age = 1,
                Id = 70,
                Address = "Test",
                TeleNumber = "xxx xxxxxxx",
                AdmittedDate = "xx/xx/xxxx",
                Gender = "Test",
                Guardian = "Test",
                PatientType = "Test",
                WardNo = "Test",
                payments = 0,
                GuardianTeleNum = "xxx xxxxxx",
                Doctor = "Test",
                InsuredName = "Test",
                InsuaranceCom = "Test",
                InsuranceComeNum = "Test",
                InsuranceGroup = "Test",
                InsurancePolicy = "Test",
                InsuranceRelation = "Test"
            };

            using (var Db = new patientContext())
            {
                Db.Patients.Add(pat1);
                Db.SaveChanges();
            }
            //vm.PID = 40;
            //vm.deletePatient();

            vm.PID = 70;
            vm.PName = "Test";

            vm.deletePatient();

            using (var db = new patientContext())
            {
                var patientExist = db.Patients.Find(vm.PID);

                Assert.Null(patientExist);
            }

        }

        [Fact]
        public void displayPays_Should_DisplayFullAmount()
        {
            var vm = new Menu4VM();

            Patient pat1 = new Patient()
            {
                Id = 50,
                Name = "Test",
                Address = "Test",
                TeleNumber = "xxx xxxxxxx",
                AdmittedDate = "xx/xx/xxxx",
                Gender = "Test",
                Guardian = "Test",
                PatientType = "Test",
                WardNo = "Test",
                payments = 0,
                GuardianTeleNum = "xxx xxxxxx",
                Doctor = "Test",
                InsuredName = "Test",
                InsuaranceCom = "Test",
                InsuranceComeNum = "Test",
                InsuranceGroup = "Test",
                InsurancePolicy = "Test",
                InsuranceRelation = "Test"
            };

            //add test payments to patient
            Payment pay1 = new Payment("TestType", 100, 50); 

            using (var Db = new patientContext())
            {
                Db.Patients.Add(pat1);
                Db.Payments.Add(pay1);
                Db.SaveChanges();
            }

            vm.PID = 50;

            vm.displayPays();

            if (vm.PID == 50)
            {
                Assert.Equal(100, vm.TotalSum);
            }

            using (var db = new patientContext())//after the test subjects are removed
            {
                db.Patients.Remove(pat1);
                db.Payments.Remove(pay1);
                db.SaveChanges();
            }

        }

        [Fact]
        public void addPayment_Should_AddNewPaymentsToTheTotal()
        {
            var vm = new Menu4VM();

            Patient pat1 = new Patient()
            {
                Id = 50,
                Name = "Test",
                Address = "Test",
                TeleNumber = "xxx xxxxxxx",
                AdmittedDate = "xx/xx/xxxx",
                Gender = "Test",
                Guardian = "Test",
                PatientType = "Test",
                WardNo = "Test",
                payments = 0,
                GuardianTeleNum = "xxx xxxxxx",
                Doctor = "Test",
                InsuredName = "Test",
                InsuaranceCom = "Test",
                InsuranceComeNum = "Test",
                InsuranceGroup = "Test",
                InsurancePolicy = "Test",
                InsuranceRelation = "Test"
            };

            //add test payments to patient
            Payment pay1 = new Payment("TestType", 100, 50);

            using (var Db = new patientContext())
            {
                Db.Patients.Add(pat1);
                Db.Payments.Add(pay1);
                Db.SaveChanges();
            }

            //New payment details
            vm.PID = 50;
            vm.PType = "Test";
            vm.PAmount = 100;

            vm.addPayment();

            Assert.Equal(200, vm.TotalSum);

            using (var db = new patientContext())//after the test subjects are removed
            {
                db.Patients.Remove(pat1);
                db.Payments.Remove(pay1);
                var pay2 = db.Payments.Where(p => p.paymentType == "Test").FirstOrDefault();
                db.Payments.Remove(pay2);
                db.SaveChanges();
            }
        }
    }
} 