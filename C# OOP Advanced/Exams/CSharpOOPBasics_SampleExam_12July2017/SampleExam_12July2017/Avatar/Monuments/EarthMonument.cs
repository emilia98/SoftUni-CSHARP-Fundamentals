//namespace Avatar
//{
    public class EarthMonument : Monument
    {
        private int earthAffinity;

        public int EarthAffinity
        {
            get { return this.earthAffinity; }
            set
            {
                this.earthAffinity = value;
            }
        }

        public EarthMonument(string name, int earthAffinity) : base(name)
        {
            this.EarthAffinity = earthAffinity;
        }
    }
//}