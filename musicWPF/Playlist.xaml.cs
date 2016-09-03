/*
 * Created by SharpDevelop.
 * User: IstvanT
 * Date: 9/3/2016
 * Time: 12:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
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
        ObservableCollection<string> songList = new ObservableCollection<string>();
        public ObservableCollection<string> SongList
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
            this.Hide();
            var playerWindow = new Player(this);
            playerWindow.Show();
        }
    }
}