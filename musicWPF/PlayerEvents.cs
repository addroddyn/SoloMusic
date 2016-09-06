using System;
using System.Windows;
using System.Windows.Input;

namespace musicWPF
	{
	public partial class Player : Window
		{
		// Contains all events that are connected to the player window.

		//--------------------------------BUTTON-CLICKS-------------------------------

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
				PlayerHelper.Play(_playlist.SongList[0], this);
				}
			}

		public void player_MediaEnded(object sender, EventArgs e)
			{
			PlayerHelper.PlayNext(this);
			}

		void NextButton_Click(object sender, RoutedEventArgs e)
			{
			PlayerHelper.PlayNext(this);
			}

		void PrevButton_Click(object sender, RoutedEventArgs e)
			{
			PlayerHelper.PlayPrev(this);
			}

		void playlistButton_Click(object sender, RoutedEventArgs e)
			{
			if (isPlaylistOpen)
				{
				_playlist.Hide();
				isPlaylistOpen = false;
				}
			else
				{
				PlayerHelper.ChangeLocation(this, _playlist);
				_playlist.Show();
				isPlaylistOpen = true;
				}
			}

		//-----------------------------MISC-EVENTS----------------------------------------

		void Player_Closing(object sender, System.ComponentModel.CancelEventArgs e)
			{
			var result = MessageBox.Show("Do you want to save the current playlist?\n(If no changes were made, just click 'No')", "Save Playlist", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.Yes)
				{
				SavePlaylist();
				}
			Environment.Exit(0);
			}

		void window1_LocationChanged(object sender, EventArgs e)
			{
			PlayerHelper.ChangeLocation(this, _playlist);
			}

		public void timer_Tick(object sender, EventArgs e)
			{
			if (player.NaturalDuration.HasTimeSpan)
				{
				posSlider.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
				posSlider.Value = player.Position.TotalSeconds;
				}
			}

		private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
			{
			player.Volume = volumeSlider.Value;
			}

		private void timeSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
			{
			if (player.NaturalDuration.HasTimeSpan)
				{
				var TotalTime = player.NaturalDuration.TimeSpan;
				if (TotalTime.TotalSeconds > 0)
					{
					player.Position = TimeSpan.FromSeconds(posSlider.Value);
					}
				}
			}

		private void window1_Activated(object sender, EventArgs e)
			{
			_playlist.Activate();
			}
		}
	}
