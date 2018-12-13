//namespace Avatar
//{
    public class EarthBender : Bender
    {
        private double groundSaturation;

        public double GroundSaturation
        {
            get { return this.groundSaturation; }
            set
            {
                this.groundSaturation = value;
            }
        }

        public EarthBender(string name, int power, double groundSaturation) : base(name, power)
        {
            this.GroundSaturation = groundSaturation;
        }
    }
//}
