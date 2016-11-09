using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaspPiPhoto
{
    public partial class FormMain : Form
    {
        private RaspPiFactory m_oRPFactory;
        private readonly SynchronizationContext m_oSynchronizationContext;

        public FormMain()
        {
            InitializeComponent();

            m_oSynchronizationContext = SynchronizationContext.Current;
            /*
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine(ip.Address.ToString());
                            int iLastDot = ip.Address.ToString().LastIndexOf('.');
                            int iLastPartLength = ip.Address.ToString().Substring(iLastDot).Length;
                            Console.WriteLine(ip.Address.ToString().Remove(iLastDot + 1, iLastPartLength - 1));
                        }
                    }
                }
            }
            */
            m_oRPFactory = new RaspPiFactory("192.168.99.",2,254,flowLayoutPanelRaspPi, m_oSynchronizationContext);
           
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
          m_oRPFactory = new RaspPiFactory("192.168.99.", 2, 254, flowLayoutPanelRaspPi, m_oSynchronizationContext);
        }

        private void takePicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(m_oRPFactory.TakePictures)).Start();
        }
    }
}
