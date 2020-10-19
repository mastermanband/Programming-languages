using System;
using System.Collections.Generic;
using System.Text;

namespace Serialize_People
{
    [Serializable]
    class Person
    {
        public string name;
        public DateTime dateOfBirth;
        public int age;

        public Person(string _name, DateTime _dateOfBirth)
        {
            name = _name;
            dateOfBirth = _dateOfBirth;
            CalculateAge();
        }

        public Person()
        {
        }

        public override string ToString()
        {
            return name + " was born on " + dateOfBirth.ToShortDateString() + " and is " + age.ToString() + " years old.";
        }

        private void CalculateAge()
        {
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth.AddYears(DateTime.Now.Year - dateOfBirth.Year) > DateTime.Now)
            {
                age--;
            }
        }
    }
}