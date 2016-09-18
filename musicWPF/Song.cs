using System;
using TagLib;

namespace musicWPF
	{
	public class Song
		{
		// The song class. 

		public Uri _fileName;
		private string _songTitle;
		private string _songNumber;
		private string _songArtist;
		private string _filePath;

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

		public string FilePath
			{
			get
				{
				return _filePath;
				}
			}

		public Song(Uri fileUri, string fileString, int songNumber)
			{
			_filePath = fileString;
			File tagFile = File.Create(fileString);
			_songNumber = songNumber.ToString() + ".";
			_songTitle = tagFile.Tag.Title;
			if (_songTitle == null)
				{
				_songTitle = System.IO.Path.GetFileNameWithoutExtension(fileString);
				}
			else
				{
				_songArtist = tagFile.Tag.FirstPerformer + " - ";
				}
			_fileName = fileUri;
			}
		}
	}
