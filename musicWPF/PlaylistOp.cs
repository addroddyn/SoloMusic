/*
 * Created by SharpDevelop.
 * User: IstvanT
 * Date: 09/03/2016
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using WinForms = System.Windows.Forms;
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
        void addFileButton_Click(object sender, RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Uri file = new Uri(openFile.FileName);
                var song = new Song(file);
                songList.Add(song.songName);
            }
        }
        void addFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var openFolder = new WinForms.FolderBrowserDialog();
        }
        
        void clearButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
