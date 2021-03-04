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
        bool alive = false; // контроллируем поток приема сообщений
        UdpClient client;
        int LOCALPORT; // Принимаем сообщения
        int REMOTEPORT; // Передаем сообщения        
        string remoteAdress; // Передаём сообщения на.. 
        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            commandTextBox.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LOCALPORT = Int32.Parse(localportTextBox.Text);
            REMOTEPORT = Int32.Parse(remoteportTextBox.Text);
            remoteAdress = remoteadressTextBox.Text;
            localportTextBox.ReadOnly = true;
            remoteportTextBox.ReadOnly = true;
            remoteadressTextBox.ReadOnly = true;
            client = new UdpClient(LOCALPORT);

            try
            {
                //Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                //receiveThread.Start();
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
                commandTextBox.ReadOnly = false;
                alive = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveMessage()
        {
            client = new UdpClient(LOCALPORT); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = client.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                    recievedMessageTextBox.Text = message;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                while (true)
                {
                    string message = commandTextBox.Text; // сообщение для отправки
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    client.Send(data, data.Length, remoteAdress, REMOTEPORT); // отправка
                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            EndSocket();

        }
        private void EndSocket()
        {
            localportTextBox.ReadOnly = false;
            remoteportTextBox.ReadOnly = false;
            remoteadressTextBox.ReadOnly = false;
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            commandTextBox.ReadOnly = true;
            alive = false;
            client.Close();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                EndSocket();
        }
    }


}


