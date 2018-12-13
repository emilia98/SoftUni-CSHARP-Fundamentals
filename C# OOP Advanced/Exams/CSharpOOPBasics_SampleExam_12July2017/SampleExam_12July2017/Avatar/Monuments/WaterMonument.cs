//namespace Avatar
//{
    public class WaterMonument : Monument
    {
        private int waterAffinity;

        public int WaterAffinity
        {
            get { return this.waterAffinity; }
            set
            {
                this.waterAffinity = value;
            }
        }

        public WaterMonument(string name, int waterAffinity) : base(name)
        {
            this.WaterAffinity = waterAffinity;
        }
    }
//}