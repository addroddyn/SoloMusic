using System;
using System.Text;
using System.Windows;
using WinForms = System.Windows.Forms;
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
		
		private void AddFolder(string filePath)
		{
		    try
                {
                foreach (string fileName in Directory.EnumerateFiles(filePath))
                    {
                    if (fileName.Contains(".mp3") || fileName.Contains(".wav") || fileName.Contains(".wma") || fileName.Contains(".aac"))
                        {
                        Uri file = new Uri(fileName);
                        if (file.IsFile)
                            {
                            var song = new Song(file, fileName, currentSong);
                            songList.Add(song);
                            currentSong++;
                            }
                        }
                    }
                foreach (string dirName in Directory.EnumerateDirectories(filePath))
                    {
                    AddFolder(dirName);
                    }
                }
            catch (Exception folder_e)
                {
                string error = "Error when opening folder: " + folder_e.ToString();
                MessageBox.Show(error);
                }
		  }
		}
	}
