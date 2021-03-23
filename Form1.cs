using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace StepperControlEthernet
{
    public partial class Form1 : Form
    {
        
        private static int remotePort;        
        private static int sendPort;
        public bool isalive = false;
        Thread tReceive = null;
        UdpClient receivingUdpClient = null;
        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void loginButton_Click(object sender, EventArgs e)
        {
            
            
            remotePort = Int16.Parse(remoteportTextBox.Text);
            sendPort = Int16.Parse(sendportbox.Text);
            

            try
            {
               
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                
                button1.Enabled = true;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        

        

        

        private void logoutButton_Click(object sender, EventArgs e)
        {
            EndSocket();
            isalive = false;
            tReceive.Abort();
            receivingUdpClient.Close();
        }
        private void EndSocket()
        {
            localportTextBox.ReadOnly = false;
            remoteportTextBox.ReadOnly = false;
            remoteadressTextBox.ReadOnly = false;
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            
            button1.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isalive)
            {
                tReceive.Abort();
                receivingUdpClient.Close();
            }
        }



        

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Owner = this;
            f.Show();
            Hide();
        }
    }


}


