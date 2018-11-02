using System;

namespace _04.OnlineRadioDatabase
{
    class InvalidSongException : Exception
    {
        private string message = "Invalid song.";

        public virtual string CustomMessage
        {
            get { return this.message; }
        }
    }
}