using System;
using System.Linq;

namespace _09.CustomListIterator
{
    public static class Sorter
    {
        public static T[] Sort<T>(CustomList<T> list) where T : IComparable<T>
        {
            return list.Elements.OrderBy(x => x).ToArray();
        }
    }
}