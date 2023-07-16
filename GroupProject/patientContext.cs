using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    public class patientContext:DbContext
    {

        //public string path = @"D:\Documents\Rashmitha\Academic\Semester 3\EE3206 - GUI Programming\GroupProjectFinalVersion\GroupProject\DataBase\Patients.db";

        //public patientContext(DbContextOptions<patientContext> options)
        //    : base(options)
        //{
                
        //}

        //public patientContext() 
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(IsRunningTest())
            {
                var filepath = ".\\Database\\TestDatabase.db";
                if (!File.Exists(filepath)) File.Create(filepath);

                optionsBuilder.UseSqlite($"Data Source=.\\Database\\TestDatabase.db");
            }
            else
            {
                var filepath = ".\\Database\\Patients.db";
                if (!File.Exists(filepath)) File.Create(filepath);

                optionsBuilder.UseSqlite($"Data Source=.\\Database\\Patients.db");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public bool IsRunningTest()
        {
            bool isTest =  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing";
            return isTest;

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
