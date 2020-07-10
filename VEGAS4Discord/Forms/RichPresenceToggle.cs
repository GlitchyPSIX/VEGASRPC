using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegasDiscordRPC.Forms
{
    public partial class RichPresenceToggle : Form
    {
        Timer down;
        bool stat;
        public RichPresenceToggle(bool status)
        {
            down = new Timer();
            down.Interval = 2000;
            down.Tick += (a, b) => OnTimerEnd();
            InitializeComponent();
            stat = status;
        }

        void OnTimerEnd()
        {
            Close();
        }

        private void RichPresenceToggle_Load(object sender, EventArgs e)
        {
            down.Start();
            lbRPCStatus.Text = $"Discord Rich Presence is now {(stat ? "ON" : "OFF")}";
        }
    }
}
