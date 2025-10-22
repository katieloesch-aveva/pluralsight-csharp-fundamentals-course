using System.Text;
using ShopExercise.Accounting;
using ShopExercise.HR;

Console.WriteLine("Creating an employee");
Console.WriteLine("----------------------\n");

//Employee bethany = new Employee(
//    "Bethany",
//    "Smith",
//    "beth@email.com",
//    new DateTime(1979, 1, 13),
//    25
//);

//bethany.DisplayEmployeeDetails();
//bethany.PerformWork();
//bethany.PerformWork(5);

//bethany.firstName = "Beth";
//bethany.hourlyRate = 11;

//bethany.DisplayEmployeeDetails();
//bethany.PerformWork();
//bethany.PerformWork(2);

//double receivedWageBethany = bethany.ReceiveWage(true);
//Console.WriteLine($"Wage paid (message from program: {receivedWageBethany}");

//Console.WriteLine(bethany.firstName);

//Employee bethany = new Employee(
//    "Bethany",
//    "Smith",
//    "beth@email.com",
//    new DateTime(1979, 1, 13),
//    25,
//    EmployeeType.Manager
//);

//bethany.DisplayEmployeeDetails();

//Employee bethCopy = bethany;
//Console.WriteLine("original:\n");
//bethany.DisplayEmployeeDetails();
//Console.WriteLine("copy:\n");
//bethCopy.DisplayEmployeeDetails();

//bethCopy.firstName = "Maxine";
//Console.WriteLine("original:\n");
//bethany.DisplayEmployeeDetails();
//Console.WriteLine("copy:\n");
//bethCopy.DisplayEmployeeDetails();

//bethany.PerformWork(25);

//WorkTask task;

//task.description = "deploy project";
//task.hours = 3;
//task.PerformWorkTask();

//int minimumBonus = 100;
//int bonusTax;

//int receivedBonus = bethany.CalculateBonusAndBonusTax(minimumBonus, out bonusTax);

//StringBuilder builder = new StringBuilder();

//builder.Append("Last name: ");
//builder.AppendLine(bethany.lastName);
//builder.Append("First name: ");
//builder.Append(bethany.firstName);
//string result = builder.ToString();

//StringBuilder builder2 = new StringBuilder();

//for (int i = 0; i < 251; i++)
//{
//    builder2.Append(i);
//    builder2.Append(" ");
//}

//string list = builder2.ToString();

//Console.WriteLine(builder);
//Console.WriteLine(builder2);

//Customer customer = new Customer();

//Employee.taxRate = 0.02;
//bethany.DisplayEmployeeDetails();

//Console.WriteLine("How many employees fo you need to register?");

//int numberOfEmployees = int.Parse(Console.ReadLine());

//Console.WriteLine($"Creating IDs for {numberOfEmployees} employees...");
//int[] employeeIDs = new int[numberOfEmployees];

//for (int i = 0; i < numberOfEmployees; i++)
//{
//    Console.WriteLine($"Enter ID for employee #{i + 1}:");
//    employeeIDs[i] = int.Parse(Console.ReadLine());
//}

//Console.WriteLine("You registered the following IDs:");

//for (int i = 0; i < numberOfEmployees; i++)
//{
//    Console.WriteLine($"ID of employee #{i + 1}: {employeeIDs[i]}");
//}

//Array.Sort(employeeIDs);
//for (int i = 0; i < numberOfEmployees; i++)
//{
//    Console.WriteLine($"ID of employee #{i + 1}: {employeeIDs[i]}");
//}

//int[] copyOfEmployeeIds = new int[numberOfEmployees];

//employeeIDs.CopyTo(copyOfEmployeeIds, 0);

//Console.WriteLine("You made a copy of the following IDs:");

//for (int i = 0; i < numberOfEmployees; i++)
//{
//    Console.WriteLine($"ID of employee #{i + 1}: {copyOfEmployeeIds[i]}");
//}

//List<int> employeeIdList = new List<int>();
//employeeIdList.Add(11);
//employeeIdList.Add(23);
//employeeIdList.Add(55);
//employeeIdList.Add(34);
//employeeIdList.Add(44);

//Console.WriteLine("List:");
//Console.WriteLine(employeeIdList);

Employee beth = new Employee(
    "Beth",
    "Childs",
    "beth@email.com",
    new DateTime(1990, 1, 20),
    25,
    EmployeeType.Manager
);
Employee sarah = new Employee(
    "Sarah",
    "Childs",
    "beth@email.com",
    new DateTime(1990, 1, 20),
    25,
    EmployeeType.Manager
);
Employee kosima = new Employee(
    "Kosima",
    "Childs",
    "beth@email.com",
    new DateTime(1990, 1, 20),
    25,
    EmployeeType.Manager
);
Employee alison = new Employee(
    "Alison",
    "Childs",
    "beth@email.com",
    new DateTime(1990, 1, 20),
    25,
    EmployeeType.Manager
);
Employee krystal = new Employee(
    "Krystal",
    "Childs",
    "beth@email.com",
    new DateTime(1990, 1, 20),
    25,
    EmployeeType.Manager
);

//Employee[] employees = new Employee[] { beth, sarah, alison, kosima, krystal };

//foreach (Employee i in employees)
//{
//    i.numberOfHoursWorked = new Random().Next(25);
//    Console.WriteLine(
//        $"{i.firstName} is an employee and she worked {i.numberOfHoursWorked} this week."
//    );
//}

List<Employee> employeeList = new List<Employee>();
employeeList.Add(beth);
employeeList.Insert(0, alison);
employeeList.Add(kosima);
employeeList.Insert(0, sarah);
employeeList.Add(krystal);

foreach (Employee e in employeeList)
{
    Console.WriteLine($"{e.FirstName} works here.");
}
