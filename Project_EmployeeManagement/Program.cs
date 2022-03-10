using System;

namespace Project_EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            manager.empSalary = 100000.0;
            Developer dev = new Developer();
            dev.empSalary = 80000.0;
            HR hr = new HR();
            hr.empSalary = 60000.0;
        manager.getBonus();
        dev.getBonus();
        hr.getBonus();


        }
    }
}
