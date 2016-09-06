using System;
using System.Text;
using System.Windows;
using System.IO;

namespace musicWPF
	{
	public partial class Player : Window
		{
		// Non-event methods for the player window that are simpler here than in the helper class.

		private void SavePlaylist()
			{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\playlist_musicWPF.txt";
			var stream = new FileStream(path, FileMode.Create);

			StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024);
			writer.AutoFlush = true;
			foreach (Song song in playlist.SongList)
				{
				writer.WriteLine(song.FilePath);
				}
			}

		public void SetPlaylist(Playlist playlist)
			{
			this.playlist = playlist;
			}
		}
	}
