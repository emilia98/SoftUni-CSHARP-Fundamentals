//namespace Avatar
//{
    public class AirMonument : Monument
    {
        private int airAffinity;

        public int AirAffinity
        {
            get { return this.airAffinity; }
            set
            {
                this.airAffinity = value;
            }
        }

        public AirMonument(string name, int airAffinity) : base(name)
        {
            this.AirAffinity = airAffinity;
        }
    }
//}
