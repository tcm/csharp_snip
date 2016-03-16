using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

interface IPasswordHash
{
    string Generate_HashValue(string StringIn);
    string Generate_Random_Seed(int Length);
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
         
        return (byte)((randomNumber[0] % numberSides));
    } 

    public string Generate_Random_Seed(int LengthIn)
    {
        const byte numberSides = 16;  // Anzahl des Ziffernvorrats
        byte[] array = new byte[LengthIn];
        
        // byte-Array mit Zufallswerten füllen.
        for (int i = 0; i <= array.Length - 1; i++ )        
            array[i] = RollDice(numberSides);

        // Umwandeln in eine String mit Hex-Zahlen.
        var StringHex = new StringBuilder(array.Length * 2);
        foreach (byte b in array)
            StringHex.AppendFormat("{0:x}",b);
       
        return StringHex.ToString();
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
