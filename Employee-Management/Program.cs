using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee_Management
{
    class Program
    {

        static void Main(string[] args)
        {
            int numberOfEmployees;
            string name, address, empType;      //local variables to recieve the data from user.
            decimal basic, hra, pf, annualGross;
            bool flag = false;
        
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false); //set current culture to "en-US" to display Salary in dollars($)
            Console.WriteLine("Welcome to Software Development Company Payroll System!!\n\n"); //welcome message
           
            
            try
            {
                Console.Write("Please Enter the Number of Employees: "); // Define the number of employees user would like to store and display in console.
                 flag = int.TryParse(Console.ReadLine(), out numberOfEmployees) && numberOfEmployees > 0;

                 if (flag == false) // validate user input - number of employees and exit if input is <= 0 or not number
                  {
                    throw new ArgumentOutOfRangeException("Number Of Employees", "Number Of Employees should be a number");
                  }

                 Employee[] empl = new Employee[numberOfEmployees];  //Array of type Employee to store the employee details.

                 for (int i = 0; i < numberOfEmployees; i++) //Recieve and store the employee details from user
                {
                    Console.Write("Please Enter Employee Name: ");
                    name = Console.ReadLine();

                    Console.Write("Please Enter Employee Address: ");
                    address = Console.ReadLine();

                    basic = GetSalaryComponent("Enter Annual Basic Amount: ");
                    hra = GetSalaryComponent("Enter Annual HRA Amount: ");
                    pf = GetSalaryComponent("Enter Annual PF Amount: ");

                    annualGross = basic + hra + pf;

                    flag = false;
                   while(!flag)
                    {
                        Console.Write("Please Enter EmployeeType(W2/1099)");
                        empType = Console.ReadLine().ToUpper();

                        switch (empType)
                        {
                            case "1099":
                                empl[i] = new Employee_1099(name, address, annualGross); // create an employee of 1099 type
                                flag = true;
                                break;
                            case "W2":
                                empl[i] = new Employee_W2(name, address, annualGross); // create an employee of W2 type
                                flag = true;
                                break;
                            default: Console.WriteLine("Employee Type Should be W2 or 1099");
                                continue;
                        }  
                    }
                }

                 foreach (Employee emp in empl) //loop through each employee and display the information in console
                  {
                    Console.WriteLine("************************************************************");
                    Console.WriteLine(emp); //print employee
                  }
                 Console.ReadLine();
           }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);  //display exceptions in console
                Console.ReadLine();
            }
        }

      
        //Read decimal values from user input and handle exceptions
        private static decimal GetSalaryComponent(string message)
        {
            decimal value;
            bool flag;

            Console.Write(message);
            flag = decimal.TryParse(Console.ReadLine(), out value) && value > 0;
           
            while (!flag)
            {
             Console.WriteLine("Input should be a number and must be > 0");
             Console.Write(message);
             flag = decimal.TryParse(Console.ReadLine(), out value) && value > 0;
            }
            return value;
        }
        
    }
}