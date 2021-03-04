using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

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
            try
            {
                ReceiveMessage();
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                alive = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(LOCALPORT); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            UdpClient send = new UdpClient(LOCALPORT);
            try
            {
                while (true)
                {
                    string message = commandTextBox.Text; // сообщение для отправки
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    send.Send(data, data.Length, remoteAdress, REMOTEPORT); // отправка
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                send.Close();
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

    
