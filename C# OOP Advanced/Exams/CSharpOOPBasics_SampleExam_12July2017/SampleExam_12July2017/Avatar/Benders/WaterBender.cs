//namespace Avatar
//{
    public class WaterBender : Bender
    {
        private double waterClarity;

        public double WaterClarity
        {
            get { return this.waterClarity; }
            set { this.waterClarity = value; }
        }

        public WaterBender(string name, int power, double waterClarity) : base(name, power)
        {
            this.WaterClarity = waterClarity;
        }
    }
//}