using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace musicWPF
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public partial class Player : Window
    {
        Point playerPos = new Point();
        MediaPlayer player = new MediaPlayer();
        Uri currentlyPlaying = null;
		bool isDragged = false;
        
        void playlistButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaylistOpen)
            {
                _playlist.Hide();
                isPlaylistOpen = false;
            }
            else
            {
                playerPos.X = this.Left + this.Width;
                playerPos.Y = this.Top;
                _playlist.Left = playerPos.X;
                _playlist.Top = playerPos.Y;
                _playlist.Show();
                isPlaylistOpen = true;
            }
        }
        
        void Player_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        
        void window1_LocationChanged(object sender, EventArgs e)
        {
                playerPos.X = this.Left + this.Width;
                playerPos.Y = this.Top;
                _playlist.Left = playerPos.X;
                _playlist.Top = playerPos.Y;
        }
        
        public void Play(Song song)
        {
			posSlider.Value = 0;
            currentlyPlaying = song._fileName;
            player.Open(song._fileName);
			player.Play();
			SongArtist = song.SongArtist;
			SongTitle = song.SongTitle;
			var timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += new EventHandler(timer_Tick);
			timer.Start();
			player.MediaEnded += player_MediaEnded;
        }

		private void timer_Tick(object sender, EventArgs e)
			{
			if (player.NaturalDuration.HasTimeSpan && isDragged == false)
				{
				posSlider.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
				posSlider.Value = player.Position.TotalSeconds;
				}
			}

		void StopButton_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }
        
        void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentlyPlaying != null)
            {
                player.Play();
            }
            else if (_playlist.SongList.Count > 0)
            {
                Play(_playlist.SongList[0]);
            }
        }
        
        void player_MediaEnded(object sender, EventArgs e)
        {
            PlayNext();
        }
        
        void PlayNext()
        {
            int songIndex = 0;
            for(int i = 0; i < _playlist.SongList.Count; i++)
            {
                if (currentlyPlaying == _playlist.SongList[i]._fileName)
                {
                    songIndex = i;
                }
            }
            if (songIndex < _playlist.SongList.Count - 1)
            {
                Play(_playlist.SongList[songIndex + 1]);
            }
        }
        
        void PlayPrev()
        {
            int songIndex = 0;
            for(int i = 0; i < _playlist.SongList.Count; i++)
            {
                if (currentlyPlaying == _playlist.SongList[i]._fileName)
                {
                    songIndex = i;
                }
            }
            if (songIndex > 0)
            {
                Play(_playlist.SongList[songIndex - 1]);
            }
        }
        
        void NextButton_Click(object sender, RoutedEventArgs e)
        {
            PlayNext();
        }
        void PrevButton_Click(object sender, RoutedEventArgs e)
        {
            PlayPrev();
        }
    }
}
