namespace BonusSystem
{
    using System;

    namespace EmployeeBonusSystem
    {
        // Base Class
        class EmployeeBonus
        {
            protected string employeeName;

            public EmployeeBonus(string name)
            {
                employeeName = name;
            }

            public virtual double CalculateBonus()
            {
                return 0.0;
            }

            public virtual string GetPerformanceRating()
            {
                return "Not Rated";
            }

            public void DisplayBonusInfo()
            {
                Console.WriteLine($"Name: {employeeName}");
                Console.WriteLine($"Bonus: {CalculateBonus()}");
                Console.WriteLine($"Performance: {GetPerformanceRating()}");
                Console.WriteLine("---------------------------");
            }
        }

        // Manager Class
        class Manager : EmployeeBonus
        {
            private double baseSalary;
            private double leadershipBonus;

            public Manager(string name, double salary, double bonus)
                : base(name)
            {
                baseSalary = salary;
                leadershipBonus = bonus;
            }

            public override double CalculateBonus()
            {
                return (baseSalary * 0.10) + leadershipBonus;
            }

            public override string GetPerformanceRating()
            {
                return "Excellent";
            }

            // Overloaded Method
            public void CalculateBonus(string level)
            {
                Console.WriteLine($"{employeeName} Bonus ({level}): {CalculateBonus()}");
            }
        }

        // SalesStaff Class
        class SalesStaff : EmployeeBonus
        {
            private double totalSales;
            private double commissionRate;

            public SalesStaff(string name, double sales, double rate)
                : base(name)
            {
                totalSales = sales;
                commissionRate = rate;
            }

            public override double CalculateBonus()
            {
                return totalSales * commissionRate;
            }

            public override string GetPerformanceRating()
            {
                if (totalSales > 150000)
                    return "Outstanding";
                else
                    return "Average";
            }

            // Overloaded Method
            public void CalculateBonus(string level)
            {
                Console.WriteLine($"{employeeName} Bonus ({level}): {CalculateBonus()}");
            }
        }

        // Main Program
        class Program
        {
            static void Main(string[] args)
            {
                EmployeeBonus[] employees = new EmployeeBonus[3];

                employees[0] = new Manager("Alice", 60000, 5000);
                employees[1] = new Manager("Bob", 75000, 7000);
                employees[2] = new SalesStaff("Carol", 200000, 0.05);

                foreach (EmployeeBonus emp in employees)
                {
                    emp.DisplayBonusInfo();

                    if (emp is Manager manager)
                    {
                        manager.CalculateBonus("Annual");
                    }
                    else if (emp is SalesStaff staff)
                    {
                        staff.CalculateBonus("Annual");
                    }
                }
            }
        }
    }
}
