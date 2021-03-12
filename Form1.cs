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
            localPort = Int16.Parse(localportTextBox.Text);
            remotePort = Int16.Parse(remoteportTextBox.Text);
            remoteIPAddress = IPAddress.Parse(remoteadressTextBox.Text);
            localportTextBox.ReadOnly = true;
            remoteportTextBox.ReadOnly = true;
            remoteadressTextBox.ReadOnly = true;
            

            try
            {
                Thread tRec = new Thread(new ThreadStart(Receiver));
                tRec.Start();
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
                commandTextBox.ReadOnly = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Receiver()
        {
            // Создаем UdpClient для чтения входящих данных
            UdpClient receivingUdpClient = new UdpClient(localPort);

            IPEndPoint RemoteIpEndPoint = null;

            try
            {
                

                while (true)
                {
                    // Ожидание дейтаграммы
                    byte[] receiveBytes = receivingUdpClient.Receive(
                       ref RemoteIpEndPoint);

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

        private static void Send(string datagram)
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
            
        }
    }


}


