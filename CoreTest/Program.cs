using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustListen.Core.AudioPlayer;

namespace CoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer bass = new BassAudioPlayer();
            PlayerTester(bass);

        }

        private static void PlayerTester(AudioPlayer player)
        {
            Console.WriteLine("Test start.");
            Console.WriteLine("Testing local audio file.");

            //player.Open("D:\\CloudMusic\\泠鸢yousa - 勾指起誓.mp3");
            player.OpenUrl("http://music.163.com/song/media/outer/url?id=415787008");
            player.Play();
            Console.WriteLine("Play");
            Debug.Assert(player.PlayState == PlayState.Playing);
            System.Threading.Thread.Sleep(2 * 1000);

            player.Pause();
            Console.WriteLine("Pasue");
            Debug.Assert(player.PlayState == PlayState.Paused);
            System.Threading.Thread.Sleep(1 * 1000);

            player.Play();
            Console.WriteLine("Play");
            System.Threading.Thread.Sleep(2 * 1000);

            Console.WriteLine("Seeking.");
            player.Seek(20);
            Console.WriteLine("Position=" + player.Position);
            Console.WriteLine("Length=" + player.Length);
            System.Threading.Thread.Sleep(5 * 1000);

            Console.WriteLine("Testing remote audio file.");


            Console.WriteLine("Testing local audio file.");

            Console.WriteLine("Testing local audio file.");
        }
    }
}
