using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Lab2Inheritance
{

    public class Program
    {
        // Listing all the functions used in the program, they all recieve a list of Employee objects as a parameter.
        static void AvgWeeklyPayments(List<Employee> employeesList)
        {
            double weeklyPay = 0;
            foreach (var employee in employeesList)
            {
                // Employee class has GetPay() method that is set to virtual, so each child object can override it accordingly
                weeklyPay += employee.GetPay();
            }
            // Using Count to determine the number of objects in the list,
            double totalWeeklyPaymentAverage = Math.Round(weeklyPay / employeesList.Count, 2);
            Console.WriteLine($"The average weekly earnings are: {totalWeeklyPaymentAverage}$\n");
        }

        static void HighestWage(List<Employee> employees)
        {
            double HighestPay = 0;
            // Creating an object variable to then store & display the desired object 
            Employee HighestWageEmployee = new();
            foreach (Employee employee in employees)
            {
                // This will sort through all the objects that belong to the Wages child class
                if (employee is Wages)
                {
                    // This will compare each one and determine the Employee with the highest pay
                    if (employee.GetPay() > HighestPay)
                    {
                        HighestPay = employee.GetPay();
                        HighestWageEmployee = employee;
                    }
                }
            }
            Console.WriteLine($"This is the Wage Employee with the highest weekly pay: \n" +
                $"Name: {HighestWageEmployee.Name}\n" +
                $"Weekly Pay: {HighestWageEmployee.GetPay()}$\n");
        }

        static void LowestSalary(List<Employee> employeesList)
        {
            // Setting this initialized variable to a very high number to compensate for some large salaries
            double lowestPay = 100000000;
            Employee lowestSalaryEmployee = new();
            // This loop is quite similar the one seen previous
            foreach (Employee employee in employeesList)
            {
                if (employee is Salaried)
                {
                    if (employee.GetPay() < lowestPay)
                    {
                        lowestPay = employee.GetPay();
                        lowestSalaryEmployee = employee;
                    }
                }
            }
            Console.WriteLine($"This is the lowest Salary Employee: \n" +
                $"Name: {lowestSalaryEmployee.Name}\n" +
                $"Salary: {lowestSalaryEmployee.GetPay()}$\n");
        }

        static void PercentageEmployeeType(double salary, double wages, double parttime, List<Employee> employeeList)
        {
            // This function recieves the parameters of the number of each time of employee and displays the percentages of each.
            double numberEmployees = employeeList.Count;
            double salariedPercent = Math.Round(salary / numberEmployees * 100, 1);
            double wagePercent = Math.Round(wages / numberEmployees * 100, 1);
            double partTimePercent = Math.Round(parttime / numberEmployees * 100, 1);

            Console.WriteLine($"Percentage of Salary Workers is {salariedPercent}%\n" +
            $"Percentage of Wage Workers is {wagePercent}%\n" +
            $"Percentage of Part Time Workers is {partTimePercent}%");
        }

        static void Main(string[] args)
        {
            // These numbers are not expected to be decimals (doubles), but will facilate calculations later on
            double salariedCount = 0;
            double wageCount = 0;
            double partTimeCount = 0;

            // Creating an empty list to fill with all the objects created
            List<Employee> employeeList = [];
            
            // This is a somewhat effective relative path to access the res folder in the desired location
            string path = Path.GetFullPath("../../../res/employees.txt");

            using StreamReader txt = new(path);
            {
                while (true)
                {
                    var line = txt.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    // This splits each line by ":" resulting an array of data
                    string[] data = line.Split(":");

                    // This determines the first character in this string -> resulting in determining the type of object we will create
                    string employeeType = (data[0].Substring(0, 1));

                    // As employees are created using the data separated by ":" and then they are added the list initialized previously.
                    switch (employeeType)
                    {
                        case "0":
                        case "1":
                        case "2":
                        case "3":
                        case "4":
                            Salaried salaried = new(data[0], data[1], data[2], data[3], long.Parse(data[4]), data[5], data[6], double.Parse(data[7]));
                            employeeList.Add(salaried);
                            salariedCount += 1;
                            break;
                        case "5":
                        case "6":
                        case "7":
                            Wages wage = new(data[0], data[1], data[2], data[3], long.Parse(data[4]), data[5], data[6], double.Parse(data[7]), double.Parse(data[8]));
                            employeeList.Add(wage);
                            wageCount += 1;
                            break;
                        case "8":
                        case "9":
                            PartTime partTime = new(data[0], data[1], data[2], data[3], long.Parse(data[4]), data[5], data[6], double.Parse(data[7]), double.Parse(data[8]));
                            employeeList.Add(partTime);
                            partTimeCount += 1;
                            break;
                    }
                }
            }

            // Calling each function to display all the information to the user.
            AvgWeeklyPayments(employeeList);
            HighestWage(employeeList);
            LowestSalary(employeeList);
            PercentageEmployeeType(salariedCount, wageCount, partTimeCount, employeeList);
        }
    }
}
 