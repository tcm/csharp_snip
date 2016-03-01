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

            var oPassword = new PasswordHash();

            string str = oPassword.Generate_HashValue("blub");
            Console.WriteLine("blub: " + str);

            Console.ReadLine();
        }
    }
}
