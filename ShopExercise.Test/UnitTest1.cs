using ShopExercise.HR;

namespace ShopExercise.Test
{
    public class UnitTest1
    {
        [Fact]
        public void PerformWork_Adds_NumberOfHours()
        {
            //Arrange
            Employee e = new Employee(
                "Donny",
                "Hendricks",
                "donny.hendricks@email.com",
                new DateTime(1979, 1, 16),
                25
            );

            int numberOfHours = 3;

            //Act
            e.PerformWork(numberOfHours);

            //Assert

            Assert.Equal(numberOfHours, e.NumberOfHoursWorked);
        }

        [Fact]
        public void PerformWork_Adds_DefaultNumberOfHours_IfNoValueSpecified()
        {
            //Arrange
            Employee e = new Employee(
                "Donny",
                "Hendricks",
                "donny.hendricks@email.com",
                new DateTime(1979, 1, 16),
                25
            );

            //Act
            e.PerformWork();

            //Assert

            Assert.Equal(1, e.NumberOfHoursWorked);
        }
    }
}
