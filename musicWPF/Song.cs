/*
 * Created by SharpDevelop.
 * User: IstvanT
 * Date: 09/03/2016
 * Time: 13:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;


namespace musicWPF
{
    /// <summary>
    /// Description of Song.
    /// </summary>
    public class Song
    {
        public Uri _fileName;
        private string _songTitle;
        private string _songNumber;
        private string _songArtist;
        
        public string SongNumber
        {
            get
            {
                return _songNumber;
            }
        }
        public string SongTitle
        {
            get
            {
                return _songTitle;
            }
        }
        
        public string SongArtist
        {
            get
            {
                return _songArtist;
            }
        }
        
        public Song(Uri filename, int songNumber)
        {
            _songNumber = songNumber.ToString();
            _songTitle = filename.ToString();
            _songArtist = filename.ToString();
            _fileName = filename;
        }
    }
}
