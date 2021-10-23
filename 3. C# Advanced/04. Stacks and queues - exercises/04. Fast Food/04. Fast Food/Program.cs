using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantityOfFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                var currentOrder = orders[i];
                queue.Enqueue(currentOrder);
            }

            Console.WriteLine(orders.Max());

            while (true)
            {
                if (queue.Any())
                {
                    var currentOrder = queue.Peek();
                    if (currentOrder <= quantityOfFood)
                    {
                        queue.Dequeue();
                        quantityOfFood -= currentOrder;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
            }
            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
