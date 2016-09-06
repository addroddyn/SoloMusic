using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace musicWPF
	{
	public partial class Player : Window, INotifyPropertyChanged
		{
		// Initialize player window, set up interface and public/bound variables.

		public Playlist playlist;
		public string _songArtist;
		public string _songTitle = "created by addroddyn";
		bool isPlaylistOpen = false;
		public Point playerPos = new Point();
		public MediaPlayer player = new MediaPlayer();
		public Uri currentlyPlaying = null;

		public Player()
			{
			InitializeComponent();
			Closing += Player_Closing;
			this.DataContext = this;
			player.Volume = 0.5;
			posSlider.AddHandler(MouseLeftButtonUpEvent, new MouseButtonEventHandler(timeSlider_MouseLeftButtonUp), true);
			}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
			{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
			}

		public string SongArtist
			{
			set
				{
				_songArtist = value;
				OnPropertyChanged("SongArtist");
				}
			get
				{
				return _songArtist;
				}
			}

		public string SongTitle
			{
			set
				{
				_songTitle = value;
				OnPropertyChanged("SongTitle");
				}
			get
				{
				return _songTitle;
				}
			}
		}
	}