// Programmer: Solomon Rantlhago

using System;
/*The class depend upon abstraction(Employee) which conforms to the DIP.
 * The class adheres to the single responsibility Principle(SRP) 
 */
namespace Project1
{
    [Serializable]
    class CHour : Employee
    {
        public decimal Rate_Hour { get; set; }
        public  double hour { get; set; }

        public CHour(string sNumber, string sName,decimal mRate_hour,double dhour)
        {
            Number = sNumber;
            Name = sName;
            Rate_Hour = mRate_hour;
            hour = dhour;
            type = EmployeeType.Hour;
            lstEmployees.Add(this);
        }
        public override decimal Payment()
        {
            return Rate_Hour * (decimal)hour;
        }
    }
}
