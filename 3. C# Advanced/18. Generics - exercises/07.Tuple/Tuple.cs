namespace _07.Tuple
{
    public class Tuple<T, Y>
    {
        private T item1;
        private Y item2;

        public Tuple(T item1, Y item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public T Item1 { get; set; }
        public Y Item2 { get; set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
