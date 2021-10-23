namespace _08.Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public Threeuple(TFirst firstValue, TSecond secondValue, TThird thirdValue)
        {
            this.FirstValue = firstValue;
            this.SecondValue = secondValue;
            this.ThirdValue = thirdValue;
        }
        public TFirst FirstValue { get; set; }
        public TSecond SecondValue { get; set; }
        public TThird ThirdValue { get; set; }

        public override string ToString()
        {
            return $"{this.FirstValue} -> {this.SecondValue} -> {this.ThirdValue}";
        }
    }
}
