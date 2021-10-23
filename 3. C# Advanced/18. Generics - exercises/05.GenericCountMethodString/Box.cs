using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }
        public List<T> Values { get; set; }

        public int CountOfGraterValues(T valueToCompare)
        {
            var countOfGraterValues = 0;
            foreach (var value in this.Values)
            {
                if (valueToCompare.CompareTo(value) == -1)
                {
                    countOfGraterValues++;
                }
            }

            return countOfGraterValues;
        }
    }
}
