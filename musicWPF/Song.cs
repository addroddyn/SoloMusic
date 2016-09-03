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
        private MediaPlayer control = new MediaPlayer();
        private Uri _song;
        private TimeSpan pos;
        public string songName;
        
        public Song(Uri filename)
        {
            songName = filename.ToString();
            _song = filename;
            control.Open(_song);
        }
        
        public void Play()
        {
            control.Play();
        }
        
        public void Stop()
        {
            control.Stop();
        }
        
        public void SetPosition()
        {
            pos = control.Position;
        }
        
        public TimeSpan GetPosition()
        {
            return pos;
        }
        
        public void Close()
        {
            control.Close();
        }
    }
}
