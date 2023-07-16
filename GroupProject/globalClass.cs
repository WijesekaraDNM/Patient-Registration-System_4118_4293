using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    static class globalClass
    {
        public static bool IsRunningTest()//for testing purposes
        {
            bool isTest = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Testing";
            return isTest;

        }
    }
}
