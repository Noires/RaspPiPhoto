using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaspPiPhoto
{
    public class RaspPiFactory
    {
        private static string IDPath = "/boot/id.txt";
        private static string GroupPath = "/boot/group.txt";
        private static string ConfigPath = "/boot/config.txt";
        private static string RPUser = "pi";
        private static string RPPW = "raspberry";
        private static int RPPort = 22;
        private string m_sIPMask;
        private int m_iIPStart;
        private int m_iIPEnd;
        private List<RaspPiModel> m_oRaspPiModels;
        private FlowLayoutPanel m_oOutputPanel;
        private SynchronizationContext m_oSyncContext;

        public RaspPiFactory(string sIPMask, int iStart, int iEnd, FlowLayoutPanel oOutputPanel, SynchronizationContext oSyncContext)
        {
            m_sIPMask = sIPMask;
            m_iIPStart = iStart;
            m_iIPEnd = iEnd;
            m_oRaspPiModels = new List<RaspPiModel>();
            m_oOutputPanel = oOutputPanel;
            m_oOutputPanel.Controls.Clear();
            m_oSyncContext = oSyncContext;
            new Thread(new ThreadStart(this.CheckRaspBerrys)).Start();
        }

        private async void CheckRaspBerrys()
        {
            Task<PingReply[]> oRaspBerryList = PingAll();
            await Task.WhenAll(ReadRaspBerryRange(oRaspBerryList.Result));
            CreateRaspPiViews();
        }

        private async Task ReadRaspBerryRange(PingReply[] oPingResponses)
        {
            List<Task> oRPTasks = new List<Task>();
            PingReply[] pingReplyArray = oPingResponses;
            foreach (PingReply oResponse in oPingResponses)
            {
                if (oResponse.Status == IPStatus.Success)
                {
                    oRPTasks.Add(this.ReadRaspBerry(oResponse));
                }
            }
            await Task.WhenAll(oRPTasks);
        }

        private Task ReadRaspBerry(PingReply oResponse)
        {
            return Task.Run((Action)(() =>
           {
               using (SftpClient conn = new SftpClient(oResponse.Address.ToString(), RPPort, RPUser, RPPW))
               {
                   try
                   {
                       conn.Connect();
                       if (conn.IsConnected)
                       {
                           if (conn.Exists(RaspPiFactory.IDPath))
                           {
                               string sID = conn.ReadAllText(RaspPiFactory.IDPath);
                               string sGroup = conn.ReadAllText(RaspPiFactory.GroupPath);
                               string sConfig = conn.ReadAllText(RaspPiFactory.ConfigPath);
                               RaspPiModel newModel = new RaspPiModel(oResponse.Address, sID, sGroup);
                               newModel.Config = sConfig;
                               m_oRaspPiModels.Add(newModel);
                               Console.WriteLine(sID);
                           }
                       }
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine(e.ToString());
                   }
                   finally
                   {
                       conn.Disconnect();
                   }
               }
           }));
        }

        public void CreateRaspPiViews()
        {
            m_oSyncContext.Post((SendOrPostCallback)(o =>
           {
               FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)o;
               foreach (RaspPiModel oModel in m_oRaspPiModels)
                   new RaspPiView(oModel)
                   {
                       Parent = ((Control)flowLayoutPanel)
                   }.Show();
           }), m_oOutputPanel);
        }

        private Task TakePicture(RaspPiModel oModel)
        {
            return Task.Run((Action)(() =>
           {
           string sFilename = oModel.IPAddress.ToString() + "_" + DateTime.Today.ToFileTime() + ".jpg";
               using (SshClient conn = new SshClient(oModel.IPAddress.ToString(), 22, RPUser, RPPW))
               {
                   conn.Connect();
                   try
                   {
                       String sConfig = oModel.Config;
                       if (sConfig == "")
                       {
                           sConfig = " -r - rot 180 - ss 12000 - ISO 700 - awb off - awbg 1.5,1.5 - q 100 - t 1";
                       }
                       conn.RunCommand("raspistill -o " + sFilename + sConfig);
                   }
                   finally
                   {
                       conn.Disconnect();
                   }
               }
               using (SftpClient conn = new SftpClient(oModel.IPAddress.ToString(), 22, RPUser, RPPW))
               {
                   FileStream oFileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + sFilename, FileMode.Create);
                   conn.Connect();
                   try
                   {
                       if (!conn.Exists(sFilename))
                           return;
                       conn.DownloadFile(sFilename, oFileStream);
                   }
                   finally
                   {
                       conn.Disconnect();
                       oFileStream.Close();
                   }
               }
           }));
        }

        public async void TakePictures()
        {
            List<Task> oTPTasks = new List<Task>();
            foreach (RaspPiModel oRaspPiModel in m_oRaspPiModels)
            {
                oTPTasks.Add(this.TakePicture(oRaspPiModel));
            }
            await Task.WhenAll(oTPTasks);
        }

        private async Task<PingReply[]> PingAll()
        {
            List<IPAddress> oIPList = new List<IPAddress>();
            for (int i = m_iIPStart; i <= m_iIPEnd; i++)
            {
                try
                {
                    oIPList.Add(IPAddress.Parse(this.m_sIPMask + i));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            var tasks = oIPList.Select(ip => new Ping().SendPingAsync(ip));
            var oResults = await Task.WhenAll(tasks);
            return oResults;
        }
    }
}
