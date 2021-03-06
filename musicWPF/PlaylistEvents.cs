﻿using System;
using System.Windows;
using Microsoft.Win32;
using WinForms = System.Windows.Forms;
using System.IO;

namespace musicWPF
	{
	public partial class Playlist : Window
		{
		// Events for the playlist window.

		//----------------------BUTTON-CLICKS-------------------------

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

		void addFileButton_Click(object sender, RoutedEventArgs e)
			{
			try
				{
				var openFile = new OpenFileDialog();
				openFile.Filter = "Supported files (*.mp3, *.wav, *.wma, *.aac) | *.mp3; *.wav; *.wma; *.aac";
				if (openFile.ShowDialog() == true)
					{
					Uri file = new Uri(openFile.FileName);
					if (file.IsFile)
						{
						var song = new Song(file, openFile.FileName, currentSong);
						songList.Add(song);
						currentSong++;
						}
					}
				}

			catch (Exception file_e)
				{
				string error = "Error when opening file: " + file_e.ToString();
				MessageBox.Show(error);
				}
			}

		void addFolderButton_Click(object sender, RoutedEventArgs e)
			{
		    var openFolder = new WinForms.FolderBrowserDialog();
		    if (openFolder.ShowDialog() == WinForms.DialogResult.OK)
    		    {
    		    string filePath = openFolder.SelectedPath;
    		    AddFolder(filePath);
    		    }
			}

		void clearButton_Click(object sender, RoutedEventArgs e)
			{
			songList.Clear();
			currentSong = 1;
			}

		//-----------------------------MISC-EVENTS----------------------------------------

		private void window1_Activated(object sender, EventArgs e)
			{
			playerWindow.Activate();
			}

		void ListBoxItem_MouseDoubleClick(object sender, RoutedEventArgs e)
			{
			PlayerHelper.Play(songList[listBox1.SelectedIndex], playerWindow);
			}
		}
	}
