using System;
using System.Threading.Tasks;
using Npgsql;
using System.Collections.Generic;

namespace tasklist
{
    public class Employee
    {
        public readonly string firstName;
        public readonly string secondName;
        public readonly DateTime birthday;
        public Employee(string firstName, string secondName, string birthday)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.birthday = DateTime.Parse(birthday);
        }
    }
}