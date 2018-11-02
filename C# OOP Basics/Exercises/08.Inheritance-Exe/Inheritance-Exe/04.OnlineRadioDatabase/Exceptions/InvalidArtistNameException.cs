namespace _04.OnlineRadioDatabase
{
    class InvalidArtistNameException : InvalidSongException
    {
        private string message = "Artist name should be between 3 and 20 symbols.";
        
        public override string CustomMessage
        {
            get { return this.message; }
        }
    }
}