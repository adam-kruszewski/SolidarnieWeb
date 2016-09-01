using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolidarnieWebApp.Tmp
{
    public class Test1 : ITest
    {
        private readonly int liczba;
        private static int sekwencja = 10;

        public Test1()
        {
            liczba = sekwencja++;
        }

        public string DajStringa()
        {
            return "a" + liczba;
        }
    }
}