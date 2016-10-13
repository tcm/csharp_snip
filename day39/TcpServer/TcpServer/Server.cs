using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TcpServer
{
    class Server
    {

        /// <summary>
        /// Port, auf dem der Server auf Clientverbindungen wartet
        /// </summary>
        public const int serverListenPort = 10000;
        /// <summary>
        /// Anzahl Millisekunden in Warteschleifen
        /// </summary>
        public const int sleepTime = 200;
        /// <summary>
        /// IP-Adresse, an der auf Verbindungen gewartet werden soll.
        /// Standardmässig wird auf allen Schnittstellen gewartet.
        /// </summary>
        public IPAddress ipAddress = IPAddress.Any;
        /// <summary>
        /// Der Haupt-Thread
        /// </summary>
        private Thread mainThread;
        /// <summary>
        /// Anzahl der maximal möglichen Clients pro Server
        /// </summary>
        public const int maxServerConnections = 100;
        /// <summary>
        /// Array für die möglichen Verbindungen
        /// </summary>
        private System.Collections.ArrayList Clients = new ArrayList(maxServerConnections);

        public Server()
        {
            // Hauptthread wird instanziert ...
            mainThread = new Thread(new ThreadStart(this.mainListener));
            // ... und gestartet
            mainThread.Start();
        }

        /// <summary>
        /// Haupt-Thread, wartet auf neue Client-Verbindungen
        /// </summary>
        private void mainListener()
        {
            // Alle Netzwerk-Schnittstellen abhören
            TcpListener listener = new TcpListener(ipAddress, serverListenPort);
            System.Console.WriteLine("Listening on port " + serverListenPort + "...");
            try
            {
                listener.Start();
                // Solange Clients akzeptieren, bis das
                // angegebene Maximum erreicht ist
                while (true)
                {
                    while (!listener.Pending()) { Thread.Sleep(sleepTime); }
                    Socket newSocket = listener.AcceptSocket();
                    if (newSocket != null)
                    {
                        // Mitteilung bzgl. neuer Clientverbindung
                        System.Console.WriteLine("Neue Client-Verbindung (" +
                            "IP: " + newSocket.RemoteEndPoint + ", " +
                            "Port " + ((IPEndPoint)newSocket.LocalEndPoint).Port.ToString() + ")");
                        serverInstance newConnection = new serverInstance(newSocket);
                        Clients.Add(newConnection);
                    }
                }
            }
            catch (ThreadAbortException ex)
            {
                System.Console.WriteLine("Server wird beendet");
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler bei Verbindungserkennung", ex);
            }
        }
    }
}
