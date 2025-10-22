using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopExercise.HR;

namespace ShopExercise
{
    internal class StoreManager : Employee
    {
        public StoreManager(
            string firstName,
            string lastName,
            string email,
            DateTime dob,
            double? hourlyRate
        )
            : base(firstName, lastName, email, dob, hourlyRate) { }
    }
}
