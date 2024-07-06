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
    public partial class ConfigForm : Form
    {

        private ConfigManager _configManager;
        public event EventHandler OnSave;


        private List<ComboboxItem<DisplayDetailType>> _types = new() {
            new ComboboxItem<DisplayDetailType>("Track Counts", DisplayDetailType.TRACKS),
            new ComboboxItem<DisplayDetailType>("Media Event Count", DisplayDetailType.MEDIA_EVENTS),
            new ComboboxItem<DisplayDetailType>("Project Filename", DisplayDetailType.PROJECT_FILENAME)
        };

        public ConfigForm(ConfigManager manager)
        {
            InitializeComponent();
            _configManager = manager;
            cbDetailStyle.DataSource = _types;

            cbIdling.Checked = _configManager.CurrentConfig.IdleEnabled;
            nudIdleSeconds.Value = (decimal)_configManager.CurrentConfig.IdleTimeout;
            cbStartupTimer.Checked = _configManager.CurrentConfig.UseStartupTime;
        }

        private void cbIdling_CheckedChanged(object sender, EventArgs e)
        {
            nudIdleSeconds.Enabled = cbIdling.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://glitchypsi.xyz");
        }

        private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/GlitchyPSIX/VEGASRPC");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _configManager.CurrentConfig.IdleEnabled = cbIdling.Checked;
            _configManager.CurrentConfig.IdleTimeout = Math.Max(10, (float)nudIdleSeconds.Value);
            _configManager.CurrentConfig.UseStartupTime = cbStartupTimer.Checked;
            _configManager.CurrentConfig.DisplayDetailType =
                ((ComboboxItem<DisplayDetailType>)cbDetailStyle.SelectedItem).Value;
            _configManager.SaveConfig();
            OnSave?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
