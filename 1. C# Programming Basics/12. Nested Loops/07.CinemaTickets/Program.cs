using System;

namespace _07.CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = movie = Console.ReadLine();
            double freeSeats = 0.0;
            string ticketType = string.Empty;

            double totalTickets = 0;
            int studentTicketsCounter = 0;
            int standartTicketsCounter = 0;
            int kidTicketCounter = 0;
            
            while (!movie.Equals("Finish"))
            {
                freeSeats = double.Parse(Console.ReadLine());
                ticketType = Console.ReadLine();

                int ticketsCounter = 0;

                while (!ticketType.Equals("End"))
                {
                    ticketsCounter++;
                    totalTickets++;

                    if (ticketType.Equals("standard"))
                    {
                        standartTicketsCounter++;
                    }
                    else if (ticketType.Equals("student"))
                    {
                        studentTicketsCounter++;
                    }
                    else if (ticketType.Equals("kid"))
                    {
                        kidTicketCounter++;
                    }
                    if (freeSeats <= ticketsCounter)
                    {
                        break;
                    }

                    ticketType = Console.ReadLine();
                }

                Console.WriteLine($"{movie} - {(ticketsCounter / freeSeats * 100):f2}% full.");

                movie = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(studentTicketsCounter / totalTickets * 100):f2}% student tickets.");
            Console.WriteLine($"{(standartTicketsCounter / totalTickets * 100):f2}% standard tickets.");
            Console.WriteLine($"{(kidTicketCounter / totalTickets * 100):f2}% kids tickets.");
        }
    }
}
