using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordHashingDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var oPassword = new PasswordHash("blub");

            string[] array = new string[2];

            array =  oPassword.GetHashValues();
            Console.WriteLine("Seed: " + array[0]);
            Console.WriteLine("Password: " + array[1]);

            Console.WriteLine();

            array = oPassword.GetHashValues();
            Console.WriteLine("Seed: " + array[0]);
            Console.WriteLine("Password: " + array[1]);
           


            Console.ReadLine();
        }
    }
}
