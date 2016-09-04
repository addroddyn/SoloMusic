/*
 * Created by SharpDevelop.
 * User: IstvanT
 * Date: 09/03/2016
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Player : Window, INotifyPropertyChanged
    {
        Playlist _playlist;
        string _songArtist = "boop";
        string _songTitle = "beep";
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
        
        void Test()
        {
            MessageBox.Show("boop");
        }
        
        public void SetPlaylist(Playlist playlist)
        {
            _playlist = playlist;
        }
    }
}