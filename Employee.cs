using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public class Employee
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string Dob { get; set; }
        public string Dept { get; set; }

        public Employee() 
        {
            // No Argument "Default" Employee
            Id = "000";
            Name = "Name";
            Address = "address";
            Phone = "123-456-7890";
            Sin = 0;
            Dob = "01/01/2024";
            Dept = "Dept. Desc";
        }
        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
        }
        // This method was added to facilitate calculating the weeklypay of all Employee objects by simply calling this method on all child objects.
        // Each child object will override this method depending their respective class, and return the intended result.
        public virtual double GetPay() { return 0; }
        public override string ToString()
        {
            return $"ID: {Id} \n" +
                $"Name: {Name} \n" +
                $"Address: {Address} \n" +
                $"Phone: {Phone} \n" +
                $"Sin: {Sin} \n" +
                $"Dob: {Dob}  \n" +
                $"Dept: {Dept}  \n";
        }
    }
}
