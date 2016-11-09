using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RaspPiPhoto
{
    
    public class RaspPiModel
    {
        private IPAddress m_oIPAddress;
        private String m_sID;
        private String m_sGroup;
        private String m_sConfig;

        public String Config
        {
            get
            {
                return m_sConfig;
            }
            set
            {
                m_sConfig = value;
            }
        }


        public IPAddress IPAddress
        {
            get
            {
                return m_oIPAddress;
            }

            set
            {
                m_oIPAddress = value;
            }
        }

        public string ID
        {
            get
            {
                return m_sID;
            }

            set
            {
                m_sID = value;
            }
        }

        public string Group
        {
            get
            {
                return m_sGroup;
            }

            set
            {
                m_sGroup = value;
            }
        }

        public RaspPiModel(IPAddress oResponse, String sID, String sGroup)
        {
            if ((oResponse != null ) && (sID != "") && (sGroup != ""))
            { 
                m_oIPAddress = oResponse;
                m_sID = sID;
                m_sGroup = sGroup;
            }
        }   

    }
}
