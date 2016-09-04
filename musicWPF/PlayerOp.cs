/*
 * Created by SharpDevelop.
 * User: IstvanT
 * Date: 09/03/2016
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

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
            currentlyPlaying = song._fileName;
            player.Open(song._fileName);
            player.Play();
            SongArtist = song.SongArtist;
            SongTitle = song.SongTitle;
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
    }
}
