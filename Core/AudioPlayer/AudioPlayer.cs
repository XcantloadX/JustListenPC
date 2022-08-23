using System;

namespace JustListen.Core.AudioPlayer
{
    /// <summary>
    /// 音频播放器的基类。
    /// Base class for audio players
    /// </summary>
    public abstract class AudioPlayer
    {
        /// <summary>
        /// 音频长度。 The length of audio file
        /// </summary>
        public abstract double Length { get; }

        /// <summary>
        /// 当前播放位置。 Current position
        /// </summary>
        public abstract double Position { get; set; }

        /// <summary>
        /// 当前播放状态。
        /// </summary>
        public abstract PlayState PlayState { get; }

        /// <summary>
        /// 打开音频文件. Open audio file.
        /// </summary>
        /// <param name="path">文件路径。File path.</param>
        public abstract void Open(string path);
        /// <summary>
        /// 打开网络文件。Open remote audio file.
        /// </summary>
        /// <param name="url">地址。Audio url.</param>
        public abstract void OpenUrl(string url);
        /// <summary>
        /// 播放音频。Play or resume.
        /// </summary>
        public abstract void Play();
        /// <summary>
        /// 暂停。Pause
        /// </summary>
        public abstract void Pause();
        public abstract void Stop();

        /// <summary>
        /// 改变播放进度。Seek.
        /// </summary>
        /// <param name="position">秒。In seconds.</param>
        public abstract void Seek(double position);
    }
}

/// <summary>
/// 音频播放器状态。
/// Current player state.
/// </summary>
public enum PlayState
{
    /// <summary>
    /// 已停止/未播放
    /// </summary>
    Stopped,
    /// <summary>
    /// 播放中
    /// </summary>
    Playing,
    /// <summary>
    /// 已暂停
    /// </summary>
    Paused,
    /// <summary>
    /// 正在缓冲
    /// </summary>
    Buffering,
    /// <summary>
    /// 未知
    /// </summary>
    Unknown
}
