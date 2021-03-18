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
        private static IPAddress remoteIPAddress;
        private static int remotePort;
        private static int localPort;        
        public bool isalive = false;
        Thread tReceive = null;
        UdpClient receivingUdpClient = null;
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

        public void loginButton_Click(object sender, EventArgs e)
        {
            
            localPort = Int16.Parse(localportTextBox.Text);
            remotePort = Int16.Parse(remoteportTextBox.Text);
            remoteIPAddress = IPAddress.Parse(remoteadressTextBox.Text);
            localportTextBox.ReadOnly = true;
            remoteportTextBox.ReadOnly = true;
            remoteadressTextBox.ReadOnly = true;
            isalive = true;

            try
            {
                tReceive = new Thread(new ThreadStart(Receiver));
                tReceive.Start();
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
                commandTextBox.ReadOnly = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                isalive = false;
                
            }
        }
        private void Receiver()
        {
            // Создаем UdpClient для чтения входящих данных
            receivingUdpClient = new UdpClient(localPort);

            IPEndPoint RemoteIpEndPoint = null;

            try
            {
                

                while (isalive)
                {
                    // Ожидание дейтаграммы
                    byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);

                    // Преобразуем и отображаем данные
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    receivedMessageTextBox.Text = returnData.ToString();                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникло исключение: " + ex.ToString() + "\n  " + ex.Message);
            }
        }

        public void sendButton_Click(object sender, EventArgs e)
        {
            Send(commandTextBox.Text);
        }

        public static void Send(string datagram)
        {
            // Создаем UdpClient
            UdpClient sender = new UdpClient();

            // Создаем endPoint по информации об удаленном хосте
            IPEndPoint endPoint = new IPEndPoint(remoteIPAddress, remotePort);

            try
            {
                // Преобразуем данные в массив байтов
                byte[] bytes = Encoding.UTF8.GetBytes(datagram);

                // Отправляем данные
                sender.Send(bytes, bytes.Length, endPoint);
                sender.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникло исключение: " + ex.ToString() + "\n  " + ex.Message);
            }
            finally
            {
                // Закрыть соединение
                sender.Close();
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
            commandTextBox.ReadOnly = true;    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isalive)
            {
                tReceive.Abort();
                receivingUdpClient.Close();
            }
        }
    }


}


