using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork__6
{
    internal class Salary
    {
        public double Wage { get; set; }
        public int Days { get; set; }
        public int Month { get; set; }
        public double summa()
        {
            if (Month == 1 || Month == 3 || Month ==  5 || Month == 7 || Month == 8 || Month == 10 || Month == 12 )
                return Wage / 31.0 * Days;
            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
                return Wage / 30.0 * Days;
            if (Month == 2)
                return Wage / 28.0 * Days;

            return 0;
        }
    }
}
