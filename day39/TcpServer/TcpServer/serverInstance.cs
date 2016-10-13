using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;


namespace TcpServer
{
    /// <summary>
    /// Serverseitige Verbindungsinstanz
    /// </summary>
    class serverInstance
    {
        /// <summary>
        /// Zeit in Millisekunden in Warteschleifen
        /// </summary>
        const int SleepTime = 200;
        public Thread serverThread;
        public Socket socket;
        /// <summary>
        /// Standard-Konstruktor, welcher u.a. den
        /// Thread für diese Verbindung erzeugt.
        /// </summary>
        /// <param name="socket">Verbindungssocket</param>
        public serverInstance(Socket socket)
        {
            this.socket = socket;
            // Thread erzeugen
            serverThread = new Thread(new ThreadStart(Process));
            serverThread.Start();
        }

        public void Process()
        {
            try
            {
                socket.Close();
                serverThread.Abort();
            }
            catch
            {
                System.Console.WriteLine("Verbindung zum Client beendet");
            }
        }
    }
}
