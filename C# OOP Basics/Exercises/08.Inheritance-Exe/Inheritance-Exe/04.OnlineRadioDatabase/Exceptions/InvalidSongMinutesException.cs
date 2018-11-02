namespace _04.OnlineRadioDatabase
{
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        private string message = "Song minutes should be between 0 and 14.";
        
        public override string CustomMessage
        {
            get { return this.message; }
        }
    }
}