using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFormatterSerialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int YearOfBirth { get; set; }

        public Person(string name, string surname, string number, int year)
        {
            Name = name; Surname = surname; PhoneNumber = number; YearOfBirth = year;
        }
    }
}