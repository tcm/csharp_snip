using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

interface IPasswordHash
{
    string Generate_HashValue(string StringIn);
    string Generate_Random_String(int Length);
}

namespace PasswordHashingDemo
{
    class PasswordHash : IPasswordHash
    {
    private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

    private static byte RollDice(byte numberSides)
    {
        if (numberSides <= 0)
            throw new ArgumentOutOfRangeException("numberSides");

        // Create a byte array to hold the random value.
        byte[] randomNumber = new byte[1];
        // Fill the array with a random value.
        rngCsp.GetBytes(randomNumber);
         
        return (byte)randomNumber[0];
    } 

    public string Generate_Random_String(int LengthIn)
    {
        string StringOut = "";
        byte[] array = new byte[LengthIn];
        

        for (int i = 0; i <= LengthIn; i++ )
        {
         
            array[i] = RollDice(15);
        }
            

        // TODO: Hier müssen die Werte noch als String aneinandergefügt werden
        //       und vorher in ab 10 in Hexwerte gewandelt werden.

        return StringOut;
    }

    public string Generate_HashValue(string StringIn)
    {
        var StringOut = new StringBuilder();
        byte[] hashValue;

        SHA256 mySHA256 = SHA256Managed.Create();
        Encoding enc = Encoding.UTF8;
        // Hier passierts!
        hashValue = mySHA256.ComputeHash(enc.GetBytes(StringIn));

        // Byte-Array in String umwandeln.
        foreach (Byte b in hashValue)
            StringOut.Append(b.ToString("x2"));

        return StringOut.ToString();
    }

  }
}
