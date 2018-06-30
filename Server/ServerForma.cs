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

namespace Server
{
    public partial class ServerForma : Form
    {
        Server server = new Server();

        public ServerForma()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Thread nit = new Thread(server.PokreniServer);
            nit.Start();
            btnStartServer.Enabled = false;
            btnStopServer.Enabled = true;
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            server.ZaustaviServer();
            btnStartServer.Enabled = true;
            btnStopServer.Enabled = false;
        }

        private void ServerForma_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.ZaustaviServer();
        }
    }
}
