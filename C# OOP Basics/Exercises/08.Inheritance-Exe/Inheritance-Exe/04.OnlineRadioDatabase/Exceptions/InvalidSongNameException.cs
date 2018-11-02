namespace _04.OnlineRadioDatabase
{
    class InvalidSongNameException : InvalidSongException
    {
        private string message = "Song name should be between 3 and 30 symbols.";
        
        public override string CustomMessage
        {
            get { return this.message; }
        }
    }
}