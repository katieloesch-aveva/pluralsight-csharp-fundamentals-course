using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopExercise.HR;

namespace ShopExercise
{
    internal class Utilities
    {
        private static string directory =
            @"C:\Users\katie.loesch\OneDrive - AVEVA Solutions Limited\dev\CsharpProjects\data\shopExerciseData\";
        private static string fileName = "employees.txt";

        internal static void RegisterEmployee(List<Employee> employees)
        {
            Console.WriteLine("Creating an employee");
            Console.WriteLine("What type of employee do you want to register?");
            Console.WriteLine(
                "1. Employee\n2. Manager\n3. Store manager\n4. Researcher\n5. Junior Researcher"
            );
            Console.Write("Your selection: ");
            string employeeType = Console.ReadLine();

            if (
                employeeType != "1"
                && employeeType != "2"
                && employeeType != "3"
                && employeeType != "4"
                && employeeType != "5"
            )
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Console.WriteLine("Enter the first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the date of birth: ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the hourly wage: ");
            double hourlyRate = double.Parse(Console.ReadLine());

            Employee employee = null;

            switch (employeeType)
            {
                case "1":
                    employee = new Employee(firstName, lastName, email, dob, hourlyRate);
                    break;
                case "2":
                    employee = new Manager(firstName, lastName, email, dob, hourlyRate);
                    break;
                case "3":
                    employee = new StoreManager(firstName, lastName, email, dob, hourlyRate);
                    break;
                case "4":
                    employee = new Researcher(firstName, lastName, email, dob, hourlyRate);
                    break;
                case "5":
                    employee = new JuniorResearcher(firstName, lastName, email, dob, hourlyRate);
                    break;
            }

            employees.Add(employee);
            Console.WriteLine("Employee created!\n\n");
        }

        internal static void CheckForExistingEmployeeFile()
        {
            //Check if file already exists
            string path = $"{directory}{fileName}";
            bool existingFileFound = File.Exists(path);

            if (existingFileFound)
            {
                Console.WriteLine("An existing file with Employee data is found.");
            }
            else
            { // check if folder already exists
                if (!Directory.Exists(directory))
                { // if it doesn't exist, create it
                    Directory.CreateDirectory(directory);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Directory is ready for saving files.");
                    Console.ResetColor();
                }
            }
        }

        internal static void ViewAllEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                employees[i].DisplayEmployeeDetails();
            }
        }

        internal static void LoadEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";

            try
            {
                if (File.Exists(path))
                {
                    employees.Clear();

                    //read file
                    string[] employeesStr = File.ReadAllLines(path);

                    Console.WriteLine(employeesStr.Length);

                    for (int i = 0; i < employeesStr.Length; i++)
                    {
                        // employeesStr[i] corresponds to a line/employee
                        // employeesStr[0] -> first line/employee
                        // employeesStr[1] -> second line/employee, etc

                        string[] employeeSplits = employeesStr[i].Split(";");

                        string firstName = employeeSplits[0]
                            .Substring(employeeSplits[0].IndexOf(":") + 1);
                        string lastName = employeeSplits[1]
                            .Substring(employeeSplits[1].IndexOf(":") + 1);
                        string email = employeeSplits[2]
                            .Substring(employeeSplits[2].IndexOf(":") + 1);
                        DateTime dob = DateTime.Parse(
                            employeeSplits[3].Substring(employeeSplits[3].IndexOf(":") + 1)
                        );
                        double hourlyRate = double.Parse(
                            employeeSplits[4].Substring(employeeSplits[4].IndexOf(":") + 1)
                        );
                        string employeeType = employeeSplits[5]
                            .Substring(employeeSplits[5].IndexOf(":") + 1)
                            .Trim();

                        Employee employee = null;

                        switch (employeeType)
                        {
                            case "1":
                                employee = new Employee(
                                    firstName,
                                    lastName,
                                    email,
                                    dob,
                                    hourlyRate
                                );
                                break;
                            case "2":
                                employee = new Manager(firstName, lastName, email, dob, hourlyRate);
                                break;
                            case "3":
                                employee = new StoreManager(
                                    firstName,
                                    lastName,
                                    email,
                                    dob,
                                    hourlyRate
                                );
                                break;
                            case "4":
                                employee = new Researcher(
                                    firstName,
                                    lastName,
                                    email,
                                    dob,
                                    hourlyRate
                                );
                                break;
                            case "5":
                                employee = new JuniorResearcher(
                                    firstName,
                                    lastName,
                                    email,
                                    dob,
                                    hourlyRate
                                );
                                break;
                        }

                        employees.Add(employee);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
                    //Console.ResetColor();
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong parsing the file, please check the data");
                Console.WriteLine(iex.Message);
                //Console.ResetColor();
            }
            catch (FileNotFoundException fnfex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fnfex.Message);
                Console.WriteLine(fnfex.StackTrace);
                //Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Somethihng went wrong while loading the file!");
                Console.WriteLine(ex.Message);
                //Console.ResetColor();
            }
            finally
            {
                Console.ResetColor();
            }
        }

        internal static void SaveEmployees(List<Employee> employees)
        {
            string path = $"{directory}{fileName}";
            StringBuilder sb = new StringBuilder();

            foreach (Employee employee in employees)
            {
                string type = GetEmployeeType(employee);
                sb.Append($"firstName: {employee.FirstName};");
                sb.Append($"lastName: {employee.LastName};");
                sb.Append($"email: {employee.Email};");
                sb.Append($"dob: {employee.Dob};");
                sb.Append($"hourlyRate: {employee.HourlyRate};");
                sb.Append($"type: {type};");
                sb.Append(Environment.NewLine);
            }

            File.WriteAllText(path, sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved employees successfully");
            Console.ResetColor();
        }

        private static string GetEmployeeType(Employee employee)
        {
            if (employee is Manager)
                return "2";
            else if (employee is StoreManager)
                return "3";
            else if (employee is JuniorResearcher)
                return "5";
            else if (employee is Researcher)
                return "4";
            else if (employee is Employee)
                return "1";
            return "0";
        }

        internal static void LoadEmployeeById(List<Employee> employees)
        {
            try
            {
                Console.Write("Enter ID of employee you want to load: ");
                int selectedId = int.Parse(Console.ReadLine());
                Employee selectedEmployee = employees[selectedId];
                selectedEmployee.DisplayEmployeeDetails();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"Wrong format! Need to enter a number between 0 and {employees.Count - 1}"
                );
                Console.ResetColor();
            }
        }
    }
}
