using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Employee
    {
        string firstName;
        string lastName;
        int age;
        string birthday;

        public Employee(string firstName, string lastName, int age, string birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Birthday = birthday;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string Birthday { get => birthday; set => birthday = value; }
    }
}
