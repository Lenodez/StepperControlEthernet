using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace StepperControlEthernet
{
    public partial class Form2 : Form
    {
        private static IPAddress remoteIPAddress;
        private static int remotePort;
        private static int localPort;
        private static int sendPort;
        public bool isalive = false;
        Thread tReceive = null;
        UdpClient receivingUdpClient = null;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            localPort = Int16.Parse(form1.localportTextBox.Text);
            remotePort = Int16.Parse(form1.remoteportTextBox.Text);
            sendPort = Int16.Parse(form1.sendportbox.Text);
            remoteIPAddress = IPAddress.Parse(form1.remoteadressTextBox.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
                       
            isalive = true;

            try
            {
                tReceive = new Thread(new ThreadStart(Receiver));
                tReceive.Start();               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        public static void Send(string datagram)
        {
            // Создаем UdpClient
            UdpClient sender = new UdpClient(sendPort);

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
        public void leftButton_Click(object sender, EventArgs e)
        {
            Send("left");
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            Send("right");
        }
        public void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Send("left");
                    break;
                case Keys.Right:
                    Send("right");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;            
            main.Show();
            Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            receivingUdpClient.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Send("s"+speedBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Send("d" + distanceBox.Text);
        }

        
    }
}
