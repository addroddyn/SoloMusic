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
using System.Collections.ObjectModel;
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
    public partial class Player : Window
    {
        Playlist _playlist;
        bool isPlaylistOpen = false;

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