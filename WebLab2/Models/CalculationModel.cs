using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab2.Models
{
    public class CalculationModel
    {
        public string operation { get; set; }
        public int n1 { get; set; }
        public int n2 { get; set; }
        public string n3 { get; set; }

        public void Calculate()
        {
            n3 = "" + n1;
            if (operation == "+")
                n3 += " + " + n2 + " = " + (n1 + n2);
            else if (operation == "-")
                n3 += " - " + n2 + " = " + (n1 - n2);
            else if (operation == "*")
                n3 += " * " + n2 + " = " + (n1 * n2);
            else if (operation == "/")
            {
                n3 += " / " + n2 + " = ";
                if (n2 != 0) n3 += (n1 / n2);
                else n3 += "ERROR: Division by zero";
            }
        }
    }
}
