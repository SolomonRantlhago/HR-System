// Programmer: Solomon Rantlhago

using System;
using System.Threading;
using static System.Console;
/*This project adheres to the following Design principles.
 * (i) single Responsibility principle(SRP)-> Every class is responsible to do
 * one thing E.G Csalaried has properties and methods that are Appropriate/neccessary,
 * The same applies to cCommissioned and cHour classes.
 * 
 * (ii) The Closed/Open principle(OCP)-> The OCP states that the behaviours of the system can
 * be extended without having to modify its existing implementation, when i Added CHour to the system, the existing classes-
 * CCommissioned,CSalaried and Employee were closed for modification(I never changed anything in those classes)
 * 
 * (iii) The Liskov Substitution Principle(LSP) -> Derived classes should be substitutable for their base classes E.G Employee is substituted by
 * CCommissioned,CSalaried and CHour
 * 
 * (iV) The dependency inversion Principle(DIP) ->  high-level modules/classes should not depend on low-level modules/classes.
 * Both should depend upon abstractions(An Abstraction can either be an interface or Abstract class) in this case Employee class is
 * the Abstract class and cHour,CSalaried and CCommissioned classes depend upon Employee abstract class.
 * Abstraction class does not depend upon details(meaning if the details change in the derived class they will not affect the abstraction)
 * 
 * (V) DRY(Don't Repeat Yourself) -> The method GetInput() was reused i didn't have to re-Write the code.
 * 
 * (Vi) YANGI(You ain't gonna need it) -> I did not implement interfaces because i was never gonna use them.
 */

namespace Project1
{
    class Program
    {
      static  Employee Employee;
        static void Main()
        {
            Employee.Read();
            Menu();
        } //Main

        private static void Menu()
        {
            Clear();
            WriteLine("1. Add employee");
            WriteLine("2. List employees");
            WriteLine("3. Exit");

            char option = ReadKey().KeyChar.ToString().ToUpper()[0];
            switch (option)
            {
                case '1': AddEmployee(); Menu(); break;
                case '2': ListEmployees(); Menu(); break;
                case '3': break;
                default: Menu(); break;
            }
        } //Menu

        private static void AddEmployee()
        {
            Clear();
            string number =GetInput<string>("Number       : ");
            string name = GetInput<string>("Name          :  ");
            char type= TYPE("Type(S / C / H) : ");
            WriteLine();
          
         
            if (type == 'S')
            {
                CheckRedundacy(EmployeeType.Salaried, number);
                decimal mSalary = GetInput<decimal>("Salary     : ");
                decimal mdeductions = GetInput<decimal>("Deductions : ");
                Employee = new CSalaried(number, name, mSalary, mdeductions);//LSP
               
            }
            if (type == 'C')
            {
                CheckRedundacy(EmployeeType.Commission, number);
                decimal mSales = GetInput<decimal>("Sales : ");
                double dPercentage = GetInput<double>("Percentage : ");
                Employee = new CCommissioned(number, name, mSales, dPercentage);//LSP
            }

           if(type == 'H')
            {
                CheckRedundacy(EmployeeType.Commission, number);
                decimal mRate_Hour = GetInput<decimal>("Rate/Hour :  ");
                double dHour = GetInput<double>("Hours : ");
                Employee = new CHour(number, name, mRate_Hour, dHour);//LSP

            }
            Employee.Save();
        } //AddEmployee

        private static void ListEmployees()
        {
            Clear();
            Console.Write("Type (S/C/H/A): ");
            char option = ReadKey().KeyChar.ToString().ToUpper()[0];
            if (option == 'S')
                ListEmployees("Salaried");
            if (option == 'C')
                ListEmployees("Commissioned");
            if (option == 'H')
                ListEmployees("Hour");
            if (option == 'A')
                ListEmployees("All");

        }//ListEmployees

        private static void ListEmployees(string type)
        {
            Clear();

            foreach (Employee employee in Employee.lstEmployees)
            {
                if (type == "Salaried" && employee.type == EmployeeType.Salaried)
                    WriteLine(employee);
                if (type == "Commissioned" && employee.type == EmployeeType.Commission)
                    WriteLine(employee);
                if ((type == "Hour" && employee.type == EmployeeType.Hour))
                    WriteLine(employee);
                if (type == "All")
                    WriteLine(employee);
            } //foreach

            Write("\nPress any key to return to the menu ...");
            ReadKey();

        } //ListEmployees

        private static char TYPE(string sPrompt)
        {
            char cType;
            do
            {
                Write(sPrompt);
                cType = ReadKey().KeyChar.ToString().ToUpper()[0];
                WriteLine();

            } while (cType != 'S' && cType !='C' && cType!='H');
            return cType;
        }
        private static T GetInput<T>(string sPrompt)
        {
            bool istrue = true;
            T input = default(T);
            do
            {
                try
                {
                    Write(sPrompt);
                    string sInput = ReadLine();
                    if (sInput == "")
                    {
                        istrue = true;
                    }
                    else
                    {
                         input = (T)Convert.ChangeType(sInput, typeof(T));
                        istrue = false;
                    }
                }
                catch
                {
                    istrue = true;
                }
            } while (istrue);
            return input;
        }


        private static void CheckRedundacy(EmployeeType type,string sNumber)
        {
            foreach (Employee employee in Employee.lstEmployees)
            {
                if (sNumber == employee.Number && employee.type==type)
                {
                    WriteLine("The Number Already Exits in the System\n" +
                        "Try Again");
                    Thread.Sleep(1500);
                    AddEmployee();
                }

            }
        }
    }
}
