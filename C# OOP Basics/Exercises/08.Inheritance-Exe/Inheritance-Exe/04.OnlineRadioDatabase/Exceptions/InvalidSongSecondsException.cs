namespace _04.OnlineRadioDatabase
{
    class InvalidSongSecondsException : InvalidSongLengthException
    {
        private string message = "Song seconds should be between 0 and 59.";
        
        public override string CustomMessage
        {
            get { return this.message; }
        }
    }
}