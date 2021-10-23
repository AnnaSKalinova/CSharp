using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public DateModifier(DateTime fisrtDate, DateTime secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }
        public DateTime FirstDate { get; }
        public DateTime SecondDate { get; }

        public int Difference(DateTime firstDate, DateTime secondDate)
        {
            int diff = Math.Abs((firstDate - secondDate).Days);
            return diff;
        }
    }
}
