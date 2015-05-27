using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.Server
{
    using System.Net;
    using System.Net.Sockets;

    public partial class MainForm : Form
    {
        private static TcpListener tcpListener;// = new TcpListener(IPAddress.Any, 15446);
        internal static Dictionary<Guid, Client> Clients { get; set; }
        public MainForm()
        {
            Clients = new Dictionary<Guid, Client>();
            InitializeComponent();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private void StartListening_Click(object sender, EventArgs e)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, (int)PortNumber.Value);
                tcpListener.Start();
                tcpListener.BeginAcceptSocket(AcceptTCPConnection, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AcceptTCPConnection(IAsyncResult result)
        {
            var socket = tcpListener.EndAcceptSocket(result);
            tcpListener.BeginAcceptSocket(this.AcceptTCPConnection, null);
            var guid = Guid.NewGuid();
            Client client = new Client(socket, guid);
            Clients.Add(guid, client);
            client.StartComminication();
        }
    }
}
