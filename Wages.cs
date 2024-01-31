using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public class Wages : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }
        public Wages() { }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
            Rate = rate;
            Hours = hours;
        }
        public override double GetPay()
        {
            if (Hours > 40)
            {
                // Calculating overtime bonus
                const double OVERTIMEBONUS = 1.5;
                double extraPay = (40 * Rate) + ((Hours - 40) * OVERTIMEBONUS * Rate);
                return Math.Round(extraPay, 2);
            }
            return Math.Round(Rate * Hours, 2);
        }
        public override string ToString()
        {
            return base.ToString() + $"Rate: {Rate}$ \n" +
                $"Hours: {Hours} \n\n";
        }
    }
}
