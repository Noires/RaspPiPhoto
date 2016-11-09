using System;
using System.Windows.Forms;
using Renci.SshNet;
using System.IO;
using System.Threading;

namespace RaspPiPhoto
{
    public partial class RaspPiView : UserControl
    {
        private RaspPiModel m_oModel;
        private SynchronizationContext m_oSynchronizationContext;

        public RaspPiView(RaspPiModel oModel)
        {
            InitializeComponent();
            m_oModel = oModel;
            m_oSynchronizationContext = SynchronizationContext.Current;

            textBoxIP.Text = m_oModel.IPAddress.ToString();
            textBoxID.Text = m_oModel.ID;
            textBoxGroup.Text = m_oModel.Group;
        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(PictureTake)).Start();
        }

        private void PictureTake()
        {
            String sFileName = m_oModel.IPAddress.ToString() + "_" + DateTime.Today.ToFileTime() + ".jpg";
            using (SshClient conn = new SshClient(m_oModel.IPAddress.ToString(), 22, "pi", "raspberry"))
            {
                conn.Connect();
                try
                {
                    conn.RunCommand("raspistill -o "+sFileName+" -r -rot 180 -ss 12000 -ISO 700 -awb off -awbg 1.5,1.5 -q 100 -t 1");
                }
                finally
                {
                    conn.Disconnect();
                }
            }
            using (SftpClient conn = new SftpClient(m_oModel.IPAddress.ToString(), 22, "pi", "raspberry"))
            {               
                FileStream oFileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + sFileName, FileMode.Create);
                //conn.OperationTimeout = TimeSpan.FromMilliseconds(timeout);
                conn.Connect();
                try
                {
                    if (conn.Exists(sFileName))
                    {
                        conn.DownloadFile(sFileName, oFileStream);
                    }
                }
                finally
                {
                    conn.Disconnect();
                    oFileStream.Close();
                    m_oSynchronizationContext.Post(new SendOrPostCallback(o =>
                    {
                        pictureBoxPreview.ImageLocation = (String)o;
                    }), AppDomain.CurrentDomain.BaseDirectory + sFileName);
                }

            }
        }

        private void OnIDBtnCLick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            using (SftpClient conn = new SftpClient(btn.Name.Replace("BtnID_", ""), 22, "root", "raspberry"))
            {

                //conn.OperationTimeout = TimeSpan.FromMilliseconds(timeout);
                conn.Connect();

                try
                {
                    string newID = Microsoft.VisualBasic.Interaction.InputBox("Set the new identification ", "New id:");                    
                        conn.WriteAllText("/boot/id.txt", newID);
                    
                }
                finally
                {
                    conn.Disconnect();
                }
            }
        }

        private void OnPicBtnCLick(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxPreview_Click(object sender, EventArgs e)
        {

        }
    }
}
