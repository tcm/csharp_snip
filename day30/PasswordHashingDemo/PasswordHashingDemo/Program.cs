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
            // Console.WriteLine("blub: " + str);

            string str2 = oPassword.Generate_Random_Seed(str.Length);
            Console.WriteLine("seed: " + str2);

            string str3 = oPassword.Generate_HashValue(str + str2);
            Console.WriteLine("hash: " + str3);

            Console.ReadLine();
        }
    }
}
