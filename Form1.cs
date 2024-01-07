using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket_test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //winsock_Ear.Listen(2000);//This is to make the PC act as host
            winsock_Ear.Connect("192.168.1.163", 2000); //This is to make the PC act as client

        }

        private void winsock_Ear_Connected(object sender, Winsock_Orcas.WinsockConnectedEventArgs e)
        {
            label1.Text = "¡¡Connected to Node-RED server!!";
        }

        private void winsock_Ear_ConnectionRequest(object sender, Winsock_Orcas.WinsockConnectionRequestEventArgs e)
        {
            winsock_Ear.Close();
            winsock_Ear.Accept(e.Client);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //we get the text from the Textbox entered from the keyboard 
            string text_to_send = this.textBox1.Text;
            winsock_Ear.Send(text_to_send);
        }
    }
}
