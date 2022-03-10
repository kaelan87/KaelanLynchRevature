using System;

namespace Project_EmployeeManagement
{
    abstract class Employee
    {
        public int empNo { get; set; }
        public string empName { get; set; }
        public double empSalary { get; set; }
        public bool isPermanent { get; set; }

        public double getBonus(){
            double bonus = empSalary * (.05);
            System.Console.WriteLine("Your bonus is: " + bonus);
            return bonus;
            
        }
    }
}