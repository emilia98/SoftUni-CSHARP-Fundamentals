using System.Collections.Generic;

namespace CustomStack
{
    public interface IStack<T> : IEnumerable<T>
    {
        List<T> Elements { get; }

        void Push(T[] item);

        void Pop();
    }
}
