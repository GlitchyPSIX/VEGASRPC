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

namespace VegasDiscordRPC.Forms
{
    public partial class ConfigForm : Form {
        private List<ComboboxItem<DisplayDetailType>> _types = new() {
            new ComboboxItem<DisplayDetailType>("Track Counts", DisplayDetailType.TRACKS),
            new ComboboxItem<DisplayDetailType>("Media Event Count", DisplayDetailType.MEDIA_EVENTS),
            new ComboboxItem<DisplayDetailType>("Project Filename", DisplayDetailType.PROJECT_FILENAME)
        };

        public ConfigForm()
        {
            InitializeComponent();
            cbDetailStyle.DataSource = _types;
        }

        private void cbEnableRichPresence_CheckedChanged(object sender, EventArgs e) {
            gbOtherSetts.Enabled = cbEnableRichPresence.Checked;
        }

        private void cbIdling_CheckedChanged(object sender, EventArgs e) {
            nudIdleSeconds.Enabled = cbIdling.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://glitchypsi.xyz");
        }

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/GlitchyPSIX/VEGASRPC");
        }
    }
}
