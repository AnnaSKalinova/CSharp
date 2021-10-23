using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                queue.Enqueue(orders[i]);
            }

            int biggestOrder = queue.Max();
            Console.WriteLine(biggestOrder);
            bool isOrdersComplete = true;

            for (int i = 0; i < orders.Length; i++)
            {
                quantityOfFood -= queue.Peek();
                if (quantityOfFood < 0)
                {
                    isOrdersComplete = false;   
                    break;
                }
                queue.Dequeue();
            }
            if (!isOrdersComplete)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", queue));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
