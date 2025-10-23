using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopExercise.HR;

namespace ShopExercise
{
    internal class Manager : Employee
    {
        public Manager(
            string firstName,
            string lastName,
            string email,
            DateTime dob,
            double? hourlyRate
        )
            : base(firstName, lastName, email, dob, hourlyRate) { }

        public void AttendManagementMeeting()
        {
            NumberOfHoursWorked += 10;

            Console.WriteLine(
                $"Manager {FirstName} {LastName} is now attending a long meeting that could have been an email."
            );
        }

        public override void giveBonus()
        {
            if (NumberOfHoursWorked > 5)
            {
                Console.WriteLine(
                    $"Manager {FirstName} {LastName} received a management bonus of 500."
                );
            }
            else
            {
                Console.WriteLine(
                    $"Manager {FirstName} {LastName} recieved a management bonus of 250."
                );
            }
        }
    }
}
