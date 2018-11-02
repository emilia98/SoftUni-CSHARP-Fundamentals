using System;

namespace _04.OnlineRadioDatabase
{
    class Song
    {
        private static int maxSeconds = 14 * 60 + 59; 
        private string artist;
        private string title;
        private string length;

        public Song(string artist, string title, string length)
        {
            this.Artist = artist;
            this.Title = title;
            this.Length = length;
        }

        public string Artist
        {
            get { return this.artist; }
            set
            {
                if(String.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                this.artist = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }
                this.title = value;
            }
        }

        public string Length
        {
            get { return this.length; }
            set
            {
                if(String.IsNullOrEmpty(value))
                {
                    throw new InvalidSongLengthException();
                }
                
                var time = value.Split(':');

                if(time.Length < 2)
                {
                    throw new InvalidSongLengthException();
                }

                int minutes = -1;
                int seconds = -1;

                if(int.TryParse(time[0], out minutes) == false || int.TryParse(time[1], out seconds) == false)
                {
                    throw new InvalidSongLengthException();
                }

                int totalSeconds = minutes * 60 + seconds;

                if(minutes < 0 || minutes > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                if(seconds < 0 || seconds > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                if(totalSeconds < 0 || totalSeconds > maxSeconds)
                {
                    throw new InvalidSongLengthException();
                }

                this.length = value;
            }
        }
    }
}