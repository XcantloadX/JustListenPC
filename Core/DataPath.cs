using System;
using System.Collections.Generic;
using System.Text;

namespace JustListen.Core
{
    /// <summary>
    /// 项目里用到的路径。
    /// File paths used in project.
    /// </summary>
    public class DataPath
    {
#if RELEASE
        public static readonly string BASE_PATH = ".\\";
#elif DEBUG
        public static readonly string BASE_PATH = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\";
#endif

        public static readonly string MPV_FILE_PATH = BASE_PATH + "lib\\mpv-2.dll";

        public static readonly string FMOD_FILE_PATH = BASE_PATH + "lib\\fmod.dll";

        public static readonly string BASS_FILE_PATH = BASE_PATH + "lib\\BASS.dll";

        public static readonly string PLUGIN_PATH = BASE_PATH + "plugins\\";

        public static readonly string CACHE_PATH = BASE_PATH + "cache\\";

        public static readonly string CURRENT_PLAYLIST_PATH = CACHE_PATH + "playlist.xml";
    }
}
