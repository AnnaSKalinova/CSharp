using System;

namespace _01.OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int numOfBooks = int.Parse(Console.ReadLine());

            string currentBook = Console.ReadLine();
            int bookCounter = 0;
            bool isBookFound = false;

            while (bookCounter < numOfBooks)
            {
                if (currentBook == favouriteBook)
                {
                    isBookFound = true;
                    break;
                }
                else
                {
                    bookCounter++;
                    currentBook = Console.ReadLine();
                }
            }

            if (isBookFound)
            {
                Console.WriteLine($"You checked {bookCounter} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {bookCounter} books.");
            }
        }
    }
}
