using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopExercise.HR;

namespace ShopExercise
{
    internal class Researcher : Employee
    {
        public Researcher(
            string firstName,
            string lastName,
            string email,
            DateTime dob,
            double? hourlyRate
        )
            : base(firstName, lastName, email, dob, hourlyRate) { }

        private int numberOfPieTastesInvented = 0;
        public int NumberOfPieTastesInvented
        {
            get { return numberOfPieTastesInvented; }
            private set { numberOfPieTastesInvented = value; }
        }

        public void ResearchNewPieTastes(int researchHours)
        {
            NumberOfHoursWorked += researchHours;
            if (new Random().Next(100) > 50)
            {
                NumberOfPieTastesInvented++;
                Console.WriteLine(
                    $"Researcher {FirstName} {LastName} has invented a new pie taste! Total number of pies invented: {NumberOfPieTastesInvented}"
                );
            }
            else
            {
                Console.WriteLine(
                    $"Researcher {FirstName} {LastName} is working still on a new pie taste!"
                );
            }
        }
    }
}
