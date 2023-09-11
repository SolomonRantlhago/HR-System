// Programmer: Solomon Rantlhago

using System;
/*The class depend upon abstraction(Employee) which conforms to the DIP.
 * The class adheres to the single responsibility Principle(SRP) 
 */
namespace Project1
{
    [Serializable]
    class CSalaried :Employee
    {
        public decimal salary { get; set; }
        public decimal deductions { get; set; }
        public CSalaried(string sNumber, string sName,decimal mSalary,decimal mdeductions)
        {
            Number = sNumber;
            Name = sName;
            salary = mSalary;
            deductions = mdeductions;
            type = EmployeeType.Salaried;
            lstEmployees.Add(this);
        }

        public override decimal Payment()
        {
            if (deductions > salary)
            {
                return 0;
            }
            return salary - deductions;
        }
    }
}
