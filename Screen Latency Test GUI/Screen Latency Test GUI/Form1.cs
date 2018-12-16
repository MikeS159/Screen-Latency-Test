using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Screen_Latency_Test_GUI
{
    public partial class Form1 : Form
    {
        AsyncSerial comPort;
        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void setupPort()
        {
            string portName = "COM3";
            int portBaud = 2000000;
            string portParity = "none";
            int portData = 8;
            string portStop = "8";

            comPort = new AsyncSerial(portName, portBaud, portParity, portData, portStop); //comPort should be declared at class level
            if (comPort.CurrentPortError != null | comPort.CurrentPortError != "")
            {
                //No Error
            }
            else
            {
                //Handle Error
                 //Reset for next attempt
            }
            comPort.PacketReceived += onMySerial_receive;
            if (comPort.StartReceive())
            {

            }
            else
            {
                //Port Error
            }
        }

        private void onMySerial_receive(object sender, PacketEventArgs e)
        {
            byte[] packet = e.Packet();
            //string supplyMessage = Encoding.Default.GetString(packet); //Conver to string if needed
            sw.Stop();
            //WINFORM EXAMPLE
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Time = " + sw.Elapsed.TotalMilliseconds.ToString());
                sw.Reset();
            });
        }

        private void sendSerialData()
        {            
            byte[] b = new byte[1];
            b[0] = 1;
            if(comPort.SendSerialData(b))
            { 

            }
            else
            {
                //port isn't open
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setupPort();
            MessageBox.Show("Port Open");
        }

        private void sendSerialData_Btn_Click(object sender, EventArgs e)
        {
            sw.Start();
            this.BackColor = Color.Black;
            sendSerialData();
        }
    }
}
