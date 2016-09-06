﻿using System;
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
			player.Volume = 0.5;
			
			posSlider.AddHandler(MouseLeftButtonUpEvent,
					  new MouseButtonEventHandler(timeSlider_MouseLeftButtonUp),
					  true);
			}
        
        public void SetPlaylist(Playlist playlist)
        {
            _playlist = playlist;
        }

		private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
			{
			player.Volume = volumeSlider.Value;
			}

		private void timeSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
			{
			var TotalTime = player.NaturalDuration.TimeSpan;
			if (TotalTime.TotalSeconds > 0)
				{
				player.Position = TimeSpan.FromSeconds(posSlider.Value/* * TotalTime.TotalSeconds*/);
				}
			}
		}
}