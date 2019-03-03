using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using DoseCare.iOS;
using DoseCare.Model;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioPlayerService))]
namespace DoseCare.iOS
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private AVAudioPlayer _audioPlayer = null;
        public Action OnFinishedPlaying { get; set; }

        public AudioPlayerService()
        {

        }
        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        public void Pause()
        {
            _audioPlayer?.Pause();
        }

        public void Play()
        {
            _audioPlayer?.Play();
        }
        public void Play(string pathToAudioFile)
        {
            // Check if _audioPlayer is currently playing  
            if (_audioPlayer != null)
            {
                _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                _audioPlayer.Stop();
            }

            string localUrl = pathToAudioFile;
            _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
            _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
            _audioPlayer.Play();
        }
    }
}