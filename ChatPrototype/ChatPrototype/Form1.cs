using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ChatPrototype
{
    public partial class Form1 : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //setting up socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //get user ip
            textLocalIp.Text = GetLocalIP();

            textFriendsIp.Text = GetLocalIP();
        }
        private string GetLocalIP()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //binding sockets
            epLocal = new IPEndPoint(IPAddress.Parse(textLocalIp.Text), Convert.ToInt32(textLocalPort.Text));
            sck.Bind(epLocal);
            // connect to remote IP and port
            epRemote = new IPEndPoint(IPAddress.Parse(textFriendsIp.Text), Convert.ToInt32(textFriendsPort.Text));
            sck.Connect(epRemote);
            // starts to listen to an specific port
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            
        }

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] recievedData = new byte[1500];
                recievedData = (byte[])aResult.AsyncState;
                //converting byte[] to string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string recievedMessage = aEncoding.GetString(recievedData);

                //Adding this message into Listbox
                listMessage.Items.Add("Friend: " + recievedMessage);

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            // converts from string to byte[]
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] msg = new byte[1500];
            msg = enc.GetBytes(textMessage.Text);
            // sending the message
            sck.Send(msg);
            // add to listbox
            listMessage.Items.Add("ME: " + textMessage.Text);
            textMessage.Text = "";
        }
    }
}
