using System;

namespace _10.Tuple
{
    public class Tuple<TItem1, TItem2>
    {
        public TItem1 Item1 { get; private set; }

        public TItem2 Item2 { get; private set; }

        public Tuple(TItem1 item1, TItem2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public override string ToString()
        {
            return String.Format("{0} -> {1}", this.Item1, this.Item2);
        }
    }
}