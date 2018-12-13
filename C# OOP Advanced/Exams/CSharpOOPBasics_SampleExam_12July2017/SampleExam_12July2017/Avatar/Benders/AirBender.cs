//namespace Avatar
//{
    public class AirBender : Bender
    {
        private double aerialIntegrity;

        public double AerialIntegrity
        {
            get { return this.aerialIntegrity; }
            set { this.aerialIntegrity = value; }
        }

        public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
        {
            this.AerialIntegrity = aerialIntegrity;
        }
    }
//}