using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace musicWPF
{
    public partial class Player : Window, INotifyPropertyChanged
    {
        Playlist _playlist;
        string _songArtist = "created by";
        string _songTitle = "addroddyn";
        bool isPlaylistOpen = false;
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string SongArtist
        {
            private set
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
            private set
            {
                _songTitle = value;
                OnPropertyChanged("SongTitle");
            }
            get
            {
                return _songTitle;
            }
        }
        
        
        public Player()
        {
            InitializeComponent();
            Closing += Player_Closing;
            this.DataContext = this;
        }
        
        public void SetPlaylist(Playlist playlist)
        {
            _playlist = playlist;
        }
    }
}