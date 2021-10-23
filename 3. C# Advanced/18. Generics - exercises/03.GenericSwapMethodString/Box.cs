using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
    {
        public Box(List<T> values)
        {
            this.Values = values;
        }
        public List<T> Values { get; set; }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            var swappedValue = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = swappedValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }
            return sb.ToString();
        }
    }
}
