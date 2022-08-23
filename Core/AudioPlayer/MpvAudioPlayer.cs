using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JustListen.Core.AudioPlayer
{
    public class MpvAudioPlayer : AudioPlayer
    {

        public override double Length { get => throw new NotImplementedException(); }
        public override double Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override PlayState PlayState { get => throw new NotImplementedException(); }

        public MpvAudioPlayer()
        {
            if (!File.Exists(DataPath.MPV_FILE_PATH))
                throw new FileNotFoundException("Can't load mpv player.", DataPath.MPV_FILE_PATH);
            throw new NotImplementedException();
        }

        public override void Open(string path)
        {
            throw new NotImplementedException();
        }

        public override void OpenUrl(string url)
        {
            throw new NotImplementedException();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Play()
        {
            throw new NotImplementedException();
        }

        public override void Seek(double position)
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
