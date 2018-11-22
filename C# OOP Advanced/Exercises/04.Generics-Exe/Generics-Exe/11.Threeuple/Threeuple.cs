using System;

namespace _11.Threeuple
{
    public class Threeuple<TItem1, TItem2, TItem3>
    {
        public TItem1 Item1 { get; private set; }

        public TItem2 Item2 { get; private set; }

        public TItem3 Item3 { get; private set; }

        public Threeuple(TItem1 item1, TItem2 item2, TItem3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public override string ToString()
        {
            return String.Format("{0} -> {1} -> {2}", this.Item1, this.Item2, this.Item3);
        }
    }
}