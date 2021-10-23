using System;
using System.Collections.Generic;

namespace _6.GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }
        public List<T> Values { get; set; }

        public int CountOfGreaterElements(double valueToComapre)
        {
            int count = 0;
            foreach (var value in this.Values)
            {
                if (value.CompareTo(valueToComapre) == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
