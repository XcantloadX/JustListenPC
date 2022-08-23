using System;
using System.Collections.Generic;
using System.Text;
using ManagedBass;

namespace JustListen.Core.AudioPlayer
{
    public class BassAudioPlayer : AudioPlayer
    {
        private int bassHandle = 0;

        public BassAudioPlayer()
        {
            if (!Bass.Init())
                throw new ManagedBass.BassException();
        }

        public override double Length { get => Bass.ChannelBytes2Seconds(bassHandle, Bass.ChannelGetLength(bassHandle)); }
        public override double Position
        {
            get => Bass.ChannelBytes2Seconds(bassHandle, Bass.ChannelGetPosition(bassHandle));
            set => Bass.ChannelSetPosition(bassHandle, Bass.ChannelSeconds2Bytes(bassHandle, value));
        }
        public override PlayState PlayState 
        {
            get
            {
                PlaybackState playbackState = Bass.ChannelIsActive(Handle);
                switch (playbackState)
                {
                    case PlaybackState.Stopped:
                        return PlayState.Stopped;
                    case PlaybackState.Playing:
                        return PlayState.Playing;
                    case PlaybackState.Stalled:
                        return PlayState.Buffering;
                    case PlaybackState.Paused:
                        return PlayState.Paused;
                    default:
                        return PlayState.Unknown;
                }
            }
        }

        /// <summary>
        /// BASS 句柄。BASS channel handle.
        /// </summary>
        public int Handle { get => bassHandle; }

        public override void Open(string path)
        {
            bassHandle = Bass.CreateStream(path, 0, 0, BassFlags.Mono);
            if (bassHandle == 0)
                throw new BassException("Failed to load file " + path);
        }


        /// <summary>
        /// <inheritdoc/>
        /// <para>
        /// 注意：将自动应用系统代理。
        /// Note: system proxy will automatically be applied.
        /// </para>
        /// 
        /// </summary>
        public override void OpenUrl(string url)
        {
            bassHandle = Bass.CreateStream(url, 0, BassFlags.Mono, null);
            if (bassHandle == 0)
                throw new BassException("Failed to load file " + url);
        }

        public override void Pause()
        {
            bool ret = Bass.ChannelPause(bassHandle);
            if (!ret)
                throw new BassException("Failed to pause music.");
        }

        public override void Play()
        {
            bool ret = Bass.ChannelPlay(bassHandle);
            if (!ret)
                throw new ManagedBass.BassException();
        }

        public override void Seek(double position)
        {
            bool ret = Bass.ChannelSetPosition(bassHandle, Bass.ChannelSeconds2Bytes(bassHandle, position));
            if (!ret)
                throw new BassException("Failed to seek music.");
        }

        public override void Stop()
        {
            bool ret = Bass.ChannelStop(bassHandle);
            if (!ret)
                throw new BassException("Failed to stop music.");
        }

    }

    public class BassException : Exception
    {
        public BassException(string message) : base(message + "\n" + Bass.LastError)
        {
        }
    }
}
