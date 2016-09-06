using System;
using System.Windows.Threading;

namespace musicWPF
	{
	static class PlayerHelper
		{
		// Helper class for the various player window operations.

		public static void Play(Song song, Player playerWindow)
			{
			playerWindow.posSlider.Value = 0;
			playerWindow.currentlyPlaying = song._fileName;
			playerWindow.player.Open(song._fileName);
			playerWindow.player.Play();
			playerWindow.SongArtist = song.SongArtist;
			playerWindow.SongTitle = song.SongTitle;
			var timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(0.5);
			timer.Tick += new EventHandler(playerWindow.timer_Tick);
			timer.Start();
			playerWindow.player.MediaEnded += playerWindow.player_MediaEnded;
			}

		public static void PlayNext(Player playerWindow)
			{
			int songIndex = 0;

			for (int i = 0; i < playerWindow.playlist.SongList.Count; i++)
				{
				if (playerWindow.currentlyPlaying == playerWindow.playlist.SongList[i]._fileName)
					{
					songIndex = i;
					}
				}
			if (songIndex < playerWindow.playlist.SongList.Count - 1)
				{
				Play(playerWindow.playlist.SongList[songIndex + 1], playerWindow);
				}
			}

		public static void PlayPrev(Player playerWindow)
			{
			int songIndex = 0;

			for (int i = 0; i < playerWindow.playlist.SongList.Count; i++)
				{
				if (playerWindow.currentlyPlaying == playerWindow.playlist.SongList[i]._fileName)
					{
					songIndex = i;
					}
				}
			if (songIndex > 0)
				{
				Play(playerWindow.playlist.SongList[songIndex - 1], playerWindow);
				}
			}

		public static void ChangeLocation(Player playerWindow, Playlist playlistWindow)
			{
			playerWindow.playerPos.X = playerWindow.Left + playerWindow.Width;
			playerWindow.playerPos.Y = playerWindow.Top;
			playerWindow.playlist.Left = playerWindow.playerPos.X;
			playerWindow.playlist.Top = playerWindow.playerPos.Y;
			}

		}
	}
