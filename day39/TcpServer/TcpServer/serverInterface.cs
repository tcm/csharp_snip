using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TcpServer
{
    interface serverInterface
    {
        /// <summary>
        /// Teilt dem Interface die verwendeten Verbindungsinformationen mit
        /// </summary>
        /// <param name="socket">Socket-Verbindung zum Client</param>
        void setConnectionData(Socket socket);
        /// <summary>
        /// Automatisch registrierter Eventhandler
        /// </summary>
        /// <param name="Message"></param>
        void newMessage(string Message);
        /// <summary>
        /// Beenden der Verbindung zum Client
        /// </summary>
        void closeConnection();
        /// <summary>
        /// Wird aufgerufen, wenn Daten vom Client empfangen wurden
        /// </summary>
        /// <param name="data">Die Daten als Byte-Array</param>
        void Receive(byte[] data);
    }
}
