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
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += new EventHandler(playerWindow.timer_Tick);
			timer.Start();
			playerWindow.player.MediaEnded += playerWindow.player_MediaEnded;
			}

		public static void PlayNext(Player playerWindow)
			{
			int songIndex = 0;
			for (int i = 0; i < playerWindow._playlist.SongList.Count; i++)
				{
				if (playerWindow.currentlyPlaying == playerWindow._playlist.SongList[i]._fileName)
					{
					songIndex = i;
					}
				}
			if (songIndex < playerWindow._playlist.SongList.Count - 1)
				{
				Play(playerWindow._playlist.SongList[songIndex + 1], playerWindow);
				}
			}

		public static void PlayPrev(Player playerWindow)
			{
			int songIndex = 0;
			for (int i = 0; i < playerWindow._playlist.SongList.Count; i++)
				{
				if (playerWindow.currentlyPlaying == playerWindow._playlist.SongList[i]._fileName)
					{
					songIndex = i;
					}
				}
			if (songIndex > 0)
				{
				Play(playerWindow._playlist.SongList[songIndex - 1], playerWindow);
				}
			}

		public static void ChangeLocation(Player playerWindow, Playlist playlistWindow)
			{
			playerWindow.playerPos.X = playerWindow.Left + playerWindow.Width;
			playerWindow.playerPos.Y = playerWindow.Top;
			playerWindow._playlist.Left = playerWindow.playerPos.X;
			playerWindow._playlist.Top = playerWindow.playerPos.Y;
			}

		}
	}
