using System;
using System.Text;
using System.Windows;
using System.IO;


namespace musicWPF
	{
	public partial class Playlist : Window
		{
		// Non-event methods for the playlist window

		private void CheckForPlaylist()
			{
			try
				{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\playlist_musicWPF.txt";
				if (File.Exists(path))
					{
					string[] files = File.ReadAllLines(path, Encoding.UTF8);
					foreach (string line in files)
						{
						Uri file = new Uri(line);
						if (file.IsFile)
							{
							var song = new Song(file, line, currentSong);
							songList.Add(song);
							currentSong++;
							}
						}
					}
				}
			catch (Exception ex)
				{
				string error = "error when loading playlist: " + ex.ToString();
				MessageBox.Show(error);
				}
			}
		}
	}
