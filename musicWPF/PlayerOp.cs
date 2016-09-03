/*
 * Created by SharpDevelop.
 * User: IstvanT
 * Date: 09/03/2016
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace musicWPF
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public partial class Player : Window
    {
        void playlistButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaylistOpen)
            {
                _playlist.Hide();
                isPlaylistOpen = false;
            }
            else
            {
                _playlist.Show();
                isPlaylistOpen = true;
            }
        }
        
        void Player_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
