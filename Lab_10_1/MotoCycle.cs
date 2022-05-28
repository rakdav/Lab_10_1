using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_1
{
    internal class MotoCycle
    {
        public string Marka { get; set; }
        public string Color { get; set; }
        public int SerialNumber { get; set; }
        public string RegNumber { get; set; }
        public int Year { get; set; }
        public int YearTech { get; set; }
        public decimal Price { get; set; }

        public override string? ToString()
        {
            return Marka+"\n"+Color+"\n"+SerialNumber+"\n"+RegNumber+"\n"+
                Year.ToString()+"\n"+YearTech.ToString()+"\n"+Price.ToString()+"\n";
        }
    }
}
