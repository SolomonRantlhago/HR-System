// Programmer: Solomon Rantlhago

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
/* This is an abstract class and it does not depend upon details.
 * Both high-level modules/classes and low-level modules/classes 
 * will have depend upon it to adhere to Dependency inversion Principle(DIP)
 */
namespace Project1
{
    enum EmployeeType
    {
        Salaried, Commission,Hour
    } //enum EmployeeType

    [Serializable]
   abstract class Employee
    {
        private const string FILENAME = @"C:\\temp\\Employees.bin";

        public string Number { get; set; }
        public string Name { get; set; }
        public EmployeeType type { get; set; }


        public static List<Employee> lstEmployees = new List<Employee>();

        public abstract decimal Payment();
        public override string ToString()
        {
            return $"Number: {Number}; Name: {Name}; Type: {type}; Payment: {Payment().ToString("0.00")}";
        } //ToString

        public static void Save()
        {
            FileStream fs = new FileStream(FILENAME, FileMode.Create);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, lstEmployees);
            fs.Close();
        } //Save

        public static void Read()
        {
            if (!File.Exists(FILENAME))
                return;

            FileStream fs = new FileStream(FILENAME, FileMode.Open);
            IFormatter formatter = new BinaryFormatter();
            lstEmployees = (List<Employee>)formatter.Deserialize(fs);
            fs.Close();
        } //Read
    }
}
