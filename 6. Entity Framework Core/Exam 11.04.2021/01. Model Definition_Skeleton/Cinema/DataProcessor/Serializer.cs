namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            throw new NotImplementedException();
            //var totalIncome = context.Projections
            //                        .Sum(p => p.Tickets.Sum(t => t.Price));

            //var json = context.Movies
            //    .ToArray()
            //    .Where(m => m.Rating >= rating)
            //    .Where(m => m.Projections.Any(p => p.Tickets.Count > 0))
            //    .Select(m => new MoviesExportDto
            //    {
            //        MovieName = m.Title,
            //        Rating = m.Rating,
            //        TotalIncomes = totalIncome,
            //        Customers = m.Projections
            //        .ToArray()
            //         .Where(p => p.MovieId == m.Id)
            //         .Select(p => p.Tickets
            //                        .Where(t => t.ProjectionId == p.Id)
            //                        .Select(t => new MovieCustomerExportDto
            //                        {
            //                            FirstName = t.Customer.FirstName,
            //                            LastName = t.Customer.LastName,
            //                            Balance = t.Customer.Balance
            //                        }))
            //                        .ToArray()
            //    })
            //    .Take(10)
            //    .OrderByDescending(m => m.Rating)
            //    .ThenByDescending(m => m.TotalIncomes)
            //    .ToArray();
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            throw new NotImplementedException();
            //StringBuilder output = new StringBuilder();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerExportDto[]), new XmlRootAttribute("Customers"));

            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty);

            //StringWriter stringWriter = new StringWriter(output);

            //var customers = context.Customers
            //    .ToArray()
            //    .Where(c => c.Age >= age)
            //    .Select(c => new CustomerExportDto
            //    { 
            //        FirstName = c.FirstName,
            //        LastName = c.LastName,
            //        SpentMoney = c.Tickets.Sum(t => t.Price),
            //        SpentTime = c.Tickets
            //            .Where(t => t.CustomerId == c.Id)
            //            .Select(p => p.ProjectionId == c.Id)
            //            .Sum(p => p.)
            //            .ToArray()
            //    })
                
        }
    }
}