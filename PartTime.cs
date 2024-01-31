using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public class PartTime : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }
        public PartTime() { }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
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
            // This is rounded due to how C# stores certain values.
            // To get more predictable results we will round to 2 decimals whenever we do any calculation
            return Math.Round(Rate * Hours, 2);
        }
        public override string ToString()
        {
            return base.ToString() + $"Rate: {Rate}$ \n" +
                $"Hours: {Hours} \n\n";
        }
    }
}
