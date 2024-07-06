namespace VegasDiscordRPC {
    public class Config {
        public DisplayDetailType DisplayDetailType { get; set; } = DisplayDetailType.TRACKS;
        public float IdleTimeout { get; set; } = 300;
        public bool IdleEnabled { get; set; } = true;
        public bool PresenceEnabled { get; set; } = true;
        public bool UseStartupTime { get; set; } = false;
    }
}