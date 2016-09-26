using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketServer
{
    class Server
    {
        bool operate = true;
        int port;
        TcpClient m_TcpClient;
        NetworkStream m_NetworkStream;


        public event EventHandler<DataReceivedEventArgs> DataReceived;
        public Server(int port)
        {
            this.port = port;
        }

        public void StartListener()
        {
            TcpListener m_TcpListener = null;
            IPAddress[] m_IPAddress = null;
            String m_HostName = String.Empty;

            m_HostName = Dns.GetHostName();
            IPHostEntry m_IPHostEntry = Dns.GetHostEntry(m_HostName);
            m_IPAddress = m_IPHostEntry.AddressList;

            m_TcpListener = new TcpListener(m_IPAddress[0], port);
            m_TcpListener.Start();

            while (operate)
            {
                try
                {
                    Thread.Sleep(10);
                    m_TcpClient = m_TcpListener.AcceptTcpClient();
                    byte[] m_bytes = new byte[4096];
                    m_NetworkStream = m_TcpClient.GetStream();
                    m_NetworkStream.Read(m_bytes, 0, m_bytes.Length);
                    Receive(m_bytes);
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }


        public void Receive(byte[] bytes)
        {
            string msg = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            DataReceived(this, new DataReceivedEventArgs(msg));
        }

        public void StopListener()
        {
            this.operate = false;
            m_TcpClient.Close();
            m_NetworkStream.Close();
            m_NetworkStream.Dispose();
        }
    }


    public class DataReceivedEventArgs : EventArgs
    {
        private string m_msg;

        public string Msg
        {
            get { return m_msg; }
            set { m_msg = value; }
        }

        public DataReceivedEventArgs(string msg)
        {
            this.m_msg = msg;
        }
    }
}
