using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

interface IPasswordHash
{
    string[] GetHashValues();
}

namespace PasswordHashingDemo
{
    class PasswordHash : IPasswordHash
    {
    private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

    private string password = null;
   
    public PasswordHash(string inPassword)
	{
		password = inPassword;      
	}

    public string [] GetHashValues()
    {
        string hash1 = null;
        string seed = null;

        string[] array = new string[2];

        hash1 = Generate_HashValue(this.password);
        seed = Generate_RandomSeed(hash1);

        array[0] = seed;
        array[1]= Generate_HashValue(seed + hash1);

        return array;

    }
    
    private static byte RollDice(byte numberSides)
    {
        if (numberSides <= 0)
            throw new ArgumentOutOfRangeException("numberSides");

        /* ---------------------------------------------- */
        /* Create a byte array to hold the random value. */
        /* ----------------------------------------------*/
        byte[] randomNumber = new byte[1];
        /* ----------------------------------------------*/
        /* fill the array with a random value.           */
        /* ----------------------------------------------*/
        rngCsp.GetBytes(randomNumber);
         
        return (byte)((randomNumber[0] % numberSides)); // 0-Werte einschließen, ansonsten + 1.
    } 

    private string Generate_RandomSeed(string StringIn)
    {
        const byte numberSides = 16;  // Anzahl des Ziffernvorrats
        byte[] array = new byte[StringIn.Length];
        
        /* -------------------------------------------- */
        /* byte-Array mit Zufallswerten füllen.         */
        /* -------------------------------------------- */
        for (int i = 0; i <= array.Length - 1; i++ )        
            array[i] = RollDice(numberSides);
        /* -------------------------------------------- */
        /* Umwandeln in eine String mit Hex-Zahlen.     */
        /* -------------------------------------------- */
        var StringHex = new StringBuilder(array.Length * 2);
        foreach (byte b in array)
            StringHex.AppendFormat("{0:x}",b);

        return StringHex.ToString();
    }

    private string Generate_HashValue(string StringIn)
    {
        var StringOut = new StringBuilder();
        byte[] hashValue;

        SHA256 mySHA256 = SHA256Managed.Create();
        Encoding enc = Encoding.UTF8;
        // Hier passierts!
        hashValue = mySHA256.ComputeHash(enc.GetBytes(StringIn));

        /* ----------------------------------------------*/
        /* Byte-Array in String umwandeln.               */
        /* ----------------------------------------------*/
        foreach (Byte b in hashValue)
            StringOut.Append(b.ToString("x2"));

        return StringOut.ToString();
     
    }

  }
}
