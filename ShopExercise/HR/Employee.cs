using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExercise.HR
{
    internal class Employee
    {
        private string firstName;
        public string lastName;
        public string email;

        public int numberOfHoursWorked;
        public double wage;
        public double? hourlyRate;

        public DateTime dob;

        public EmployeeType employeeType;
        const int minimalHoursWorkedUnit = 1;

        public static double bonusPercentage = 0.15;

        public static void IncreaseBonusPercentage(double newPercentage)
        {
            bonusPercentage = newPercentage;
        }

        public static double taxRate = 0.15;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public Employee(string first, string last, string em, DateTime bd)
            : this(first, last, em, bd, 0, EmployeeType.StoreManager) { }

        public Employee(
            string first,
            string last,
            string em,
            DateTime bd,
            double? rate,
            EmployeeType empType
        )
        {
            firstName = first;
            lastName = last;
            email = em;
            dob = bd;
            hourlyRate = rate;
            employeeType = empType;
        }

        public void PerformWork()
        {
            //numberOfHoursWorked++;
            PerformWork(minimalHoursWorkedUnit);
            //Console.WriteLine(
            //    $"{firstName} {lastName} has worked for {numberOfHoursWorked} hour(s)!"
            //);
        }

        public void PerformWork(int numberOfHours)
        {
            numberOfHoursWorked++;
            Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHours} hour(s)!");
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = 0.0;
            if (employeeType == EmployeeType.Manager)
            {
                Console.WriteLine(
                    $"An extra was added to the wage since {firstName} is a manager!"
                );
                wageBeforeTax = numberOfHoursWorked * hourlyRate.Value * 1.25;
            }
            else
            {
                wageBeforeTax = numberOfHoursWorked * hourlyRate.Value;
            }

            double taxAmount = wageBeforeTax - taxRate;
            wage = wageBeforeTax - taxAmount;

            Console.WriteLine(
                $"{firstName} {lastName} has recevied a wage of {wage} for {numberOfHoursWorked} hour(s) of work."
            );

            if (resetHours)
            {
                numberOfHoursWorked = 0;
            }

            return wage;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine(
                $"\nFirst Name: \t{firstName}\nLast name: \t{lastName}\nEmail: \tt{email}\nBirthday: \t{dob.ToShortDateString()}\nTax rate: \t {taxRate}"
            );
        }

        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            if (numberOfHoursWorked > 10)
            {
                bonus *= 2;
            }

            if (bonus >= 200)
            {
                bonusTax = bonus / 10;
                bonus -= bonusTax;
            }

            Console.WriteLine(
                $"The employee got a bonus of {bonus} and the tax on the bonus is {bonusTax}"
            );
            return bonus;
        }
    }
}
