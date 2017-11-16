using System;
using DbConnection;
using System.Collections.Generic;
// AS 'First Name', AS 'Last Name', AS 'Favorite Number'
namespace csharp_crud
{
    public class Program
    {
        public static void Read()
        {
            List<Dictionary<string, object>> userInfo = DbConnector.Query("SELECT first_name, last_name, favorite_number FROM users");
            Console.WriteLine("User Info--");
            foreach(var info in userInfo)
            {
                foreach(KeyValuePair<string,object> user in info)
                {
                Console.Write($"{ user.Key }: { user.Value }" + ", ");
                }
                Console.WriteLine();
            }
        }

        public static void Insert()
        {
            string first = Console.ReadLine();
            string last = Console.ReadLine();
            string number = Console.ReadLine();
            DbConnector.Execute($"INSERT INTO users (first_name, last_name, favorite_number, created_at, updated_at) VALUES ('{first}', '{last}', '{number}', NOW(), NOW())");
        }
        static void Main(string[] args)
        {
            Read();
            Insert();
        }
    }
}