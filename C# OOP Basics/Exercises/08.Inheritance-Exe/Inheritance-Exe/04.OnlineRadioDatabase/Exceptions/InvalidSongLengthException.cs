namespace _04.OnlineRadioDatabase
{
    class InvalidSongLengthException : InvalidSongException
    {
        private string message = "Invalid song length.";
        
        public override string CustomMessage
        {
            get { return this.message; }
        }
    }
}