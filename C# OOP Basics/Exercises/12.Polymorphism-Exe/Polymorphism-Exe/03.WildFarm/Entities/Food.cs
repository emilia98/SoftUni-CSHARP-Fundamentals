namespace _03.WildFarm
{
    public abstract class Food
    {
        public int Quantity { get; }

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}