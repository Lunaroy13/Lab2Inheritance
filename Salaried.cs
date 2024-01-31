using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2Inheritance
{
    public class Salaried: Employee
    {
        public double Salary { get; set; }
        public Salaried() 
        { 
            Salary = 0;
        }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
            Salary = salary;
        }
        public override double GetPay()
        {
            // No calculation needed for Salaried objects this is effectively a getter
            return Salary;
        }
        public override string ToString() 
        {
            return base.ToString() + $"Salary: {Salary}$ \n\n";
        }
    }
}
