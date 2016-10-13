using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;



namespace SocketServer
{
    class Program
    {

        static void Main(string[] args)
        {

            var ep = new IPEndPoint(IPAddress.Any, 1234);
            // var ep = new IPEndPoint(IPAddress.Loopback, 1234);
          
            var listener = new TcpListener(ep);
            listener.Start();

            Console.WriteLine(@"  
            ===================================================  
                   Started listening requests at: {0}:{1}  
            ===================================================",
            ep.Address, ep.Port);

            // Run the loop continously; this is the server.  
            while(true)
            {
                const int bytesize = 1024 * 1024;

                string message = null;
                byte[] buffer = new byte[bytesize];

                var sender = listener.AcceptTcpClient();
                sender.GetStream().Read(buffer, 0, bytesize);

                // Read the message, and perform different actions  
                message = cleanMessage(buffer);

                Console.WriteLine(message);
  
            
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes("Thank you for your message.");
                sender.GetStream().Write(bytes, 0, bytes.Length);
            }

        }

        // Sends the message string using the bytes provided.  
        private static string cleanMessage(byte[] bytes)
        {
            // string message = System.Text.Encoding.Unicode.GetString(bytes);
            string message = System.Text.Encoding.UTF8.GetString(bytes);

            string messageToPrint = null;

            foreach (var nullChar in message)
            {
                if (nullChar != '\0')
                {
                    messageToPrint += nullChar;
                }
            }
            return messageToPrint;
        }


     

    }  
}
