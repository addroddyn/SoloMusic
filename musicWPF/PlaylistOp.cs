using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


namespace musicWPF
{
    /// <summary>
    /// Description of PlaylistOp.
    /// </summary>
    public partial class Playlist : Window
    {
        public int currentSong = 1;
        
        void addFileButton_Click(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Uri file = new Uri(openFile.FileName);
                var song = new Song(file, currentSong);
                songList.Add(song);
                currentSong++;
            }
        }
        
        void addFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var openFolder = new WinForms.FolderBrowserDialog();
            if (openFolder.ShowDialog() == WinForms.DialogResult.OK)
            {
                foreach (string fileName in Directory.EnumerateFiles(openFolder.SelectedPath))
                {
                    Uri file = new Uri(fileName);
                    var song = new Song(file, currentSong);
                    songList.Add(song);
                    currentSong++;
                }
                foreach (string dirName in Directory.EnumerateDirectories(openFolder.SelectedPath))
                {
                    foreach (string fileName in Directory.EnumerateFiles(dirName))
                    {
                        Uri file = new Uri(fileName);
                        var song = new Song(file, currentSong);
                        songList.Add(song);
                        currentSong++;
                    }
                }
            }
        }
        
        void clearButton_Click(object sender, RoutedEventArgs e)
        {
            songList.Clear();
            currentSong = 1;
        }
        
        void ListBoxItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            playerWindow.Play(songList[listBox1.SelectedIndex]);
        }
    }
}
