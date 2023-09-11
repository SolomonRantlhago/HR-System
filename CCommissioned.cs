// Programmer: Solomon Rantlhago


using System;
/*The class depend upon abstraction(Employee) which conforms to the DIP.
 * The class adheres to the single responsibility Principle(SRP) 
 */
namespace Project1
{
    [Serializable]
    class CCommissioned:Employee
    {
        public decimal Sales { get; set; }
        public double Percentage { get; set; }

        public CCommissioned(string sNumber,string sName,decimal mSales,double dPercentage)
        {
            Number = sNumber;
            Name = sName;
            Sales = mSales;
            Percentage = dPercentage;
            type = EmployeeType.Commission;
            lstEmployees.Add(this);
        }
        public override decimal Payment()
        {
           return Sales * (decimal)(Percentage / 100.0);
        }
    }
}
