using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using WinForms = System.Windows.Forms;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace musicWPF
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Playlist : Window
		{
		Player playerWindow = new Player();
		ObservableCollection<Song> songList = new ObservableCollection<Song>();

		public ObservableCollection<Song> SongList
			{
			get
				{
				return songList;
				}
			}

		public Playlist()
			{
			InitializeComponent();
			this.DataContext = this;
			this.ShowInTaskbar = false;
			this.Hide();
			CheckForPlaylist();
			playerWindow.SetPlaylist(this);
			playerWindow.Show();
			}

		private void window1_Activated(object sender, EventArgs e)
			{
			playerWindow.Activate();
			}

		private void CheckForPlaylist()
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

		private void deleteSavedPlaylistButton_Click(object sender, RoutedEventArgs e)
			{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\playlist_musicWPF.txt";
			try
				{
				File.Delete(path);
				MessageBox.Show("Saved playlist deleted.");
				}
			catch (Exception ex)
				{
				string error = "error when deleting file: " + ex.ToString();
				MessageBox.Show("Delete failed");
				}
			}
		}
}