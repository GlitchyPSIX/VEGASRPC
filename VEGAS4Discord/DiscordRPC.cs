using System.Runtime.InteropServices;

//
// Discord Rpc Wrapper for .NET Framework (DTZxPorter) 12/26/2017
// Wrapper created using the open-source discord-rpc extension at:
// https://github.com/discordapp/discord-rpc
//

namespace DiscordRpcNet
{
    public class DiscordRpc
    {
        private const string DiscordDll = "discord-rpc.dll";

        [DllImport(DiscordDll, EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Initialize(string applicationId, ref EventHandlers handlers, bool autoRegister, string optionalSteamId);
        [DllImport(DiscordDll, EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdatePresence(ref RichPresence presence);
        [DllImport(DiscordDll, EntryPoint = "Discord_Respond", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Respond(string userid, ReplyValue reply);
        [DllImport(DiscordDll, EntryPoint = "Discord_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunCallbacks();
        [DllImport(DiscordDll, EntryPoint = "Discord_Shutdown", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Shutdown();

        public enum ReplyValue : int
        {
            No = 0,
            Yes = 1,
            Ignore = 2
        }

        [System.Serializable]
        public struct JoinRequest
        {
            public string userId;
            public string username;
            public string discriminator;
            public string avatar;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReadyCallback();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DisconnectedCallback(int errorCode, string message);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ErrorCallback(int errorCode, string message);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void JoinGameCallback(string joinSecret);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpectateGameCallback(string spectateSecret);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void JoinRequestCallback(ref JoinRequest request);

        [System.Serializable]
        public struct RichPresence
        {
            public string state; /* max 128 bytes */
            public string details; /* max 128 bytes */
            public long startTimestamp;
            public long endTimestamp;
            public string largeImageKey; /* max 32 bytes */
            public string largeImageText; /* max 128 bytes */
            public string smallImageKey; /* max 32 bytes */
            public string smallImageText; /* max 128 bytes */
            public string partyId; /* max 128 bytes */
            public int partySize;
            public int partyMax;
            public string matchSecret; /* max 128 bytes */
            public string joinSecret; /* max 128 bytes */
            public string spectateSecret; /* max 128 bytes */
            public byte instance;
        }

        public struct EventHandlers
        {
            public ReadyCallback readyCallback;
            public DisconnectedCallback disconnectedCallback;
            public ErrorCallback errorCallback;
            public JoinGameCallback joinCallback;
            public SpectateGameCallback spectateCallback;
            public JoinRequestCallback joinRequestCallback;
        }
    }
}