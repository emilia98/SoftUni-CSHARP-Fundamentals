using System;
using System.Linq;

namespace _08.CustomListSorter
{
    public static class Sorter
    {
        public static T[] Sort<T>(CustomList<T> list) where T : IComparable<T>
        {
            return list.CList.OrderBy(x => x).ToArray();
        }
    }
}