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
        private string lastName;
        private string email;

        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate;

        private DateTime dob;
        private const int minimalHoursWorkedUnit = 1;

        private Address address;

        public static double taxRate = 0.15;
        public static double bonusPercentage = 0.15;

        public static void IncreaseBonusPercentage(double newPercentage)
        {
            bonusPercentage = newPercentage;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int NumberOfHoursWorked
        {
            get { return numberOfHoursWorked; }
            protected set { numberOfHoursWorked = value; }
        }
        public double Wage
        {
            get { return wage; }
            private set { wage = value; }
        }
        public DateTime Dob
        {
            get { return dob; }
            private set { dob = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public double? HourlyRate
        {
            get { return hourlyRate; }
            set
            {
                if (hourlyRate < 0)
                {
                    hourlyRate = 0;
                }
                else
                {
                    hourlyRate = value;
                }
            }
        }

        public Employee(string first, string last, string em, DateTime bd)
            : this(first, last, em, bd, 0) { }

        public Employee(
            string firstName,
            string lastName,
            string email,
            DateTime dob,
            double? hourlyRate
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Dob = dob;
            HourlyRate = hourlyRate ?? 10;
        }

        public Employee(
            string firstName,
            string lastName,
            string email,
            DateTime dob,
            double? hourlyRate,
            string street,
            string houseNumber,
            string zipCode,
            string city
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Dob = dob;
            HourlyRate = hourlyRate ?? 10;

            Address = new Address(street, houseNumber, zipCode, city);
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
            NumberOfHoursWorked += numberOfHours;
            Console.WriteLine($"{FirstName} {LastName} has worked for {numberOfHours} hour(s)!");
        }

        public double ReceiveWage(bool resetHours = true)
        {
            double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
            double taxAmount = wageBeforeTax * taxRate;

            Wage = wageBeforeTax - taxAmount;

            Console.WriteLine(
                $"{FirstName} {LastName} has recevied a wage of {Wage} for {NumberOfHoursWorked} hour(s) of work."
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
                $"\nFirst Name: \t{FirstName}\nLast name: \t{LastName}\nEmail: \t\t{Email}\nBirthday: \t{Dob.ToShortDateString()}\nTax rate: \t {taxRate}"
            );
        }

        public int CalculateBonusAndBonusTax(int bonus, out int bonusTax)
        {
            bonusTax = 0;
            if (NumberOfHoursWorked > 10)
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
