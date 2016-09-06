using System.Windows;
using System.Collections.ObjectModel;

namespace musicWPF
	{
	public partial class Playlist : Window
		{
		// Initialize playlist window and the song list

		Player playerWindow = new Player();
		ObservableCollection<Song> songList = new ObservableCollection<Song>();
		public int currentSong = 1;

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

		public ObservableCollection<Song> SongList
			{
			get
				{
				return songList;
				}
			}
		}
	}