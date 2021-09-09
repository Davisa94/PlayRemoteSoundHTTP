using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlayRemoteSoundServer
{
    public class PlayLocalSound
    {
        public static bool Play(string filename)
        {
            SoundPlayer player = new()
            {
                SoundLocation = filename
            };
            player.Load();
            player.Play();
            return true;
        }
        public static void PlayAll(string filename)
        {
            using (var audioFile = new AudioFileReader(filename))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }

}
