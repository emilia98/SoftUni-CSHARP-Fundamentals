//namespace Avatar
//{
    public class FireBender : Bender
    {
        private double heatAggression;

        public double HeatAggression
        {
            get { return this.heatAggression; }
            set { this.heatAggression = value; }
        }

        public FireBender(string name, int power, double heatAggression) : base(name, power)
        {
            this.HeatAggression = heatAggression;
        }
    }
//}