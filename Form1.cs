using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace PortScanWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            scan();
            
        }
        
        private void scan()
        {
            //Store range of ports
            int portStart = Convert.ToInt32(IP_Range_Start.Text);
            int portEnd = Convert.ToInt32(IP_Range_End.Text);


            for (int currPort = portStart; currPort <= portEnd; currPort++)
            {
                TcpClient tcpPortScan = new TcpClient();
                
                try
                {
                    tcpPortScan.Connect(txtIPAddress.Text, currPort);
                    PortBox.AppendText("Port " + currPort + " is open!\n");
                }
                catch
                {
                    PortBox.AppendText("Port " + currPort + " is closed.\n");
                }
            }
        }
        private void endScan_Click(object sender, EventArgs e)
        {
            
        }

        private void myCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (myCombo.SelectedIndex)
            {
                case 0:
                    IP_Range_Start.Text = "0";
                    IP_Range_End.Text = "1024";
                    break;
                case 1:
                    IP_Range_Start.Text = "1025";
                    IP_Range_End.Text = "49151";
                    break;
                case 2:
                    IP_Range_Start.Text = "49151";
                    IP_Range_End.Text = "65535";
                    break;

                default:
                    break;
            }
            
        }
    }

}
