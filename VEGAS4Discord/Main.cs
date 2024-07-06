using System;
using System.Windows.Forms;
using System.Collections;
using ScriptPortal.Vegas;
using DiscordRpcNet;
using System.Linq;
using VegasDiscordRPC.Forms;

namespace VegasDiscordRPC
{

    public class EntryPoint : ICustomCommandModule
    {
        // DummyDocker is here because using a Docker is the only way I can listen to the VEGAS window closing.
        DockableControl dummyDocker;

        DiscordRpc.EventHandlers callbacks;
        DiscordRpc.RichPresence presence;

        public LogFile lfile = new LogFile();

        Timer idleTimer = new();

        int SecondsSinceLastAction;
        // Whether it's playing, rendering...
        bool isActive;

        private ConfigManager _myConfig = new();

        private DateTime _sinceOpened;

        private long unixTimestamp(DateTime dt)
        {
            return (dt.Ticks - 621355968000000000) / 10000000;
        }

        public ICollection GetCustomCommands()
        {
            CustomCommand cmd = new CustomCommand(CommandCategory.Tools, "ToggleStatus")
            {
                DisplayName = "Toggle Rich Presence"
            };
            cmd.Invoked += (a, b) => TogglePresence(DomainManager.VegasDomainManager.GetVegas());
            callbacks.disconnectedCallback += DisconnectedCallback;
            callbacks.errorCallback += ErrorCallback;
            callbacks.readyCallback += ReadyCallback;

            dummyDocker = new DockableControl("dummyDocker");
            return new CustomCommand[] { cmd };
        }

        void loadDummyDocker(Vegas vegas)
        {
            // because VEGAS API is stupid and only allows to listen on app close through a docked control
            // so we make a super tiny one where nobody can see it and we win
            dummyDocker.AppWindowClosed += (a, b) => { Shutdown(); };
            dummyDocker.DefaultDockWindowStyle = DockWindowStyle.Detached;
            dummyDocker.DefaultFloatingSize = new System.Drawing.Size(1, 1);
            dummyDocker.DefaultFloatingLocation = new System.Drawing.Point(2, 2);
            vegas.LoadDockView(dummyDocker);
        }

        public void Shutdown()
        {
            dummyDocker.Dispose();
            DiscordRpc.Shutdown();
        }

        public void InitializeModule(Vegas vegas)
        {
            _sinceOpened = DateTime.Now;
            resetPresence(ref presence, vegas);
            DiscordRpc.Initialize("434711433112977427", ref callbacks, true, string.Empty);
            presence.details = "Idling";
            vegas.TrackEventCountChanged += (a, b) => { };
            vegas.TrackCountChanged += (a, b) => { UpdateTrackNumber(vegas); };
            vegas.TrackEventCountChanged += (a, b) => { UpdateTrackNumber(vegas); };
            vegas.PlaybackStarted += (a, b) => { isActive = true; GenericNonIdleAction(vegas); };
            vegas.PlaybackStopped += (a, b) => { isActive = false; GenericNonIdleAction(vegas); };
            vegas.ProjectSaving += (a, b) => GenericNonIdleAction(vegas);
            vegas.RenderStarted += (a, b) => RenderStarted(vegas);
            vegas.RenderProgress += (a, b) => RenderEvtProgress(b, vegas);
            vegas.RenderFinished += (a, b) => RenderEvtFinish(b, vegas);
            vegas.AppInitialized += (a, b) => loadDummyDocker((Vegas)a);
            DiscordRpc.RunCallbacks();
            DiscordRpc.UpdatePresence(ref presence);
            idleTimer.Interval = 120000;
            idleTimer.Tick += (a, b) => IntervalTick();
            idleTimer.Start();
        }

        public void IntervalTick() {
            if (isActive || !_myConfig.CurrentConfig.IdleEnabled) return;

            if (SecondsSinceLastAction < _myConfig.CurrentConfig.IdleTimeout)
            {
                SecondsSinceLastAction += 10;
            }
            else if (SecondsSinceLastAction >= _myConfig.CurrentConfig.IdleTimeout)
            {
                resetPresence(ref presence, DomainManager.VegasDomainManager.GetVegas());
                presence.details = "Idling";
                DiscordRpc.UpdatePresence(ref presence);
            }
        }

        /// <summary>
        /// Resets the presence object.
        /// </summary>
        /// <param name="pres">The presence object to reset (Future use: ?)</param>
        /// <param name="vegas">The Vegas object</param>
        /// <param name="smallKey">Small image key</param>
        /// <param name="smallText">Small image hover text</param>
        public void resetPresence(ref DiscordRpc.RichPresence pres, Vegas vegas, string smallKey = "", string smallText = "")
        {
            if (!_myConfig.CurrentConfig.PresenceEnabled)
                return;

            int vegasVersion = int.Parse(vegas.Version.Split(' ')[1].Split('.')[0]);
            string verKey;

            switch (vegasVersion) {
                case >= 13 and < 15:
                {
                    verKey = $"v{vegasVersion}";
                    break;
                }
                case >= 15 and <= 18:
                {
                    verKey = "v15";
                    break;
                }
                case > 18:
                {
                    verKey = "v19";
                    break;
                }
                default:
                {
                    verKey = "v13";
                    break;
                }
            }

            pres = new DiscordRpc.RichPresence
            {
                largeImageKey = verKey,
                largeImageText = vegas.Version
            };

            if (_myConfig.CurrentConfig.UseStartupTime) {
                pres.startTimestamp = unixTimestamp(_sinceOpened);
            }

            if (smallKey != "")
            {
                pres.smallImageKey = smallKey;
            }
            if (smallText != "")
            {
                pres.smallImageText = smallText;
            }
        }

        public void RenderStarted(Vegas vegas)
        {

            if (!_myConfig.CurrentConfig.PresenceEnabled)
                return;

            SecondsSinceLastAction = 0;
            isActive = true;
            resetPresence(ref presence, vegas);

            if (!_myConfig.CurrentConfig.UseStartupTime) {
                presence.startTimestamp = unixTimestamp(DateTime.UtcNow);
            }

            presence.details = "";
            presence.state = "Rendering... (0%)";
            DiscordRpc.UpdatePresence(ref presence);
        }

        public void RenderEvtProgress(RenderStatusEventArgs renderargs, Vegas vegas)
        {
            if (!_myConfig.CurrentConfig.PresenceEnabled)
                return;

            if (!_myConfig.CurrentConfig.UseStartupTime)
            {
                presence.startTimestamp = unixTimestamp(DateTime.UtcNow);
            }
            presence.details = "";
            presence.state = $"Rendering... ({renderargs.PercentComplete}%)";
            DiscordRpc.UpdatePresence(ref presence);
        }


        public void RenderEvtFinish(RenderStatusEventArgs renderargs, Vegas vegas)
        {
            if (!_myConfig.CurrentConfig.PresenceEnabled)
                return;

            SecondsSinceLastAction = 0;
            isActive = false;
            presence = new DiscordRpc.RichPresence();
            resetPresence(ref presence, vegas);
            switch (renderargs.Status)
            {
                case RenderStatus.Complete:
                    presence.state = "Just finished rendering";
                    break;
                case RenderStatus.Failed:
                    presence.state = "Just failed to render";
                    break;
                case RenderStatus.Canceled:
                    presence.state = "Just canceled rendering";
                    break;
            }
            DiscordRpc.UpdatePresence(ref presence);
        }

        public void GenericNonIdleAction(Vegas vegas)
        {
            if (!_myConfig.CurrentConfig.PresenceEnabled)
                return;
            SecondsSinceLastAction = 0;
            UpdateTrackNumber(vegas);
        }

        public void UpdateTrackNumber(Vegas vegas)
        {
            if (!_myConfig.CurrentConfig.PresenceEnabled)
                return;

            SecondsSinceLastAction = 0;
            resetPresence(ref presence, vegas);
            if (vegas.Project.Tracks.Count != 0)
            {
                int videotracks = vegas.Project.Tracks.Count(x => x.GetType() == typeof(VideoTrack));
                int audiotracks = vegas.Project.Tracks.Count(x => x.GetType() == typeof(AudioTrack));

                presence.details = "Editing";
                if (videotracks > 0 && audiotracks == 0)
                {
                    presence.state = "Video Only";
                    presence.partySize = videotracks;
                    presence.partyMax = videotracks;
                }
                else if (videotracks > 0 && audiotracks > 0)
                {
                    presence.state = "Video and Audio";
                    presence.partySize = videotracks;
                    presence.partyMax = audiotracks + videotracks;
                }
                else if (videotracks == 0 && audiotracks > 0)
                {
                    presence.state = "Audio Only";
                    presence.partySize = audiotracks;
                    presence.partyMax = audiotracks;
                }
                DiscordRpc.UpdatePresence(ref presence);
            }
            else
            {
                presence.details = "No tracks";
                DiscordRpc.UpdatePresence(ref presence);
            }
        }

        public void TogglePresence(Vegas vegas)
        {
            if (_myConfig.CurrentConfig.PresenceEnabled)
            {
                RichPresenceToggle rpct = new RichPresenceToggle(false);
                rpct.ShowDialog(vegas.MainWindow);
                idleTimer.Stop();
                _myConfig.CurrentConfig.PresenceEnabled = false;
                DiscordRpc.Shutdown();
            }
            else
            {
                RichPresenceToggle rpct = new RichPresenceToggle(true);
                rpct.ShowDialog(vegas.MainWindow);
                idleTimer.Start();
                _myConfig.CurrentConfig.PresenceEnabled = true;
                resetPresence(ref presence, vegas);
                DiscordRpc.Initialize("434711433112977427", ref callbacks, true, string.Empty);
                UpdateTrackNumber(vegas);
            }
        }

        void ReadyCallback()
        {
            lfile.AddLogEntry(DateTime.Now.ToLongTimeString() + " - Discord's ready");
            lfile.Close();
        }

        void DisconnectedCallback(int errorCode, string message)
        {
            lfile.AddLogEntry(DateTime.Now.ToLongTimeString() + " - Discord Disconnected! (" + errorCode + "-" + message + ")");
            lfile.Close();
        }

        void ErrorCallback(int errorCode, string message)
        {
            lfile.AddLogEntry(DateTime.Now.ToLongTimeString() + " - Discord Error! (" + errorCode + "-" + message + ")");
            lfile.Close();
        }
    }
}
