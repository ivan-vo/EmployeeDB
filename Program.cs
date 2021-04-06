using System;
using System.Threading.Tasks;
using Npgsql;
using System.Collections.Generic;

namespace tasklist
{
    class Program
    {
        static void Main()
        {
            PrintEmployee(3);
            
        }
        public static Dictionary<int, List<Employee>> EmployeeReader()
        {
            Dictionary<int, List<Employee>> allEmployee = new Dictionary<int, List<Employee>>();
            for (int i = 1; i <= 12; i++)
            {
                allEmployee.Add(i, new List<Employee>());
            }
            var connString = "Host=127.0.0.1;Username=birthday_app;Password=ivanvoronov;Database=employee_birthday";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();
            using (var cmd = new NpgsqlCommand("SELECT first_name, second_name, birthday FROM items", conn))
            using (var reader = cmd.ExecuteReader())            
            while (reader.Read())
            {   
                allEmployee[reader.GetDate(2).Month].Add(new Employee(reader.GetString(0),reader.GetString(1),reader.GetDate(2).ToString()));
            }
            return allEmployee;
        }
        private static List<Employee> GetEmployeeByMonth(int month)
        {
            Dictionary<int, List<Employee>> allEmployee = EmployeeReader();
            return allEmployee[month];   
        }
        public static void PrintEmployee(int month)
        {
            for (int i = 0; i < month; i++)
            {
                Console.WriteLine(DateTime.Now.AddMonths(i).ToString("MMMM"));
                foreach (var empl in GetEmployeeByMonth(DateTime.Now.AddMonths(i).Month))
                {
                    Console.WriteLine($"({empl.birthday.ToString("dd")}) - {empl.firstName}  {empl.secondName}");   
                }
            }
        }
    }
}
