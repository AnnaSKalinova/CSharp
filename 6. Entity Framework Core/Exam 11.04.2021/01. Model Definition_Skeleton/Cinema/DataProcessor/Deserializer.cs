namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";

        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";

        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<string> moviesAdded = new List<string>();

            var jsonData = JsonConvert.DeserializeObject<MoviesImportDto[]>(jsonString);

            foreach (var jsonMovie in jsonData)
            {
                if (!IsValid(jsonMovie) || moviesAdded.Contains(jsonMovie.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = jsonMovie.Title,
                    Genre = jsonMovie.Genre,
                    Duration = jsonMovie.Duration,
                    Rating = jsonMovie.Rating,
                    Director = jsonMovie.Director
                };

                moviesAdded.Add(movie.Title);
                context.Movies.Add(movie);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported {jsonMovie.Title} with genre {jsonMovie.Genre} and rating {jsonMovie.Rating:F2}!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProjectionImportDto[]), new XmlRootAttribute("Projections"));

            StringReader stringReader = new StringReader(xmlString);

            var xmlProjections = (ProjectionImportDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var xmlProjection in xmlProjections)
            {
                if (!IsValid(xmlProjection))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dateTime;
                bool isDateTimeValid = DateTime.TryParseExact(xmlProjection.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

                if (!isDateTimeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = xmlProjection.MovieId,
                    DateTime = dateTime
                };

                context.Projections.Add(projection);
                context.SaveChanges();

                DateTime outputDateTime;
                bool isOutputDateTimeValid = DateTime.TryParseExact(projection.DateTime.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out outputDateTime);

                var movie = context.Movies.FirstOrDefault(m => m.Id == xmlProjection.MovieId);

                sb.AppendLine($"Successfully imported projection {movie.Title} on {outputDateTime}!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));

            StringReader stringReader = new StringReader(xmlString);

            var xmlCustomers = (CustomerImportDto[])xmlSerializer.Deserialize(stringReader);

            foreach (var xmlCustomer in xmlCustomers)
            {
                if (!IsValid(xmlCustomer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = xmlCustomer.FirstName,
                    LastName = xmlCustomer.LastName,
                    Age = xmlCustomer.Age,
                    Balance = xmlCustomer.Balance
                };

                foreach (var xmlTicket in xmlCustomer.Tickets)
                {
                    if (!IsValid(xmlTicket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        ProjectionId = xmlTicket.ProjectionId,
                        Price = xmlTicket.Price
                    };

                    customer.Tickets.Add(ticket);
                }

                context.Customers.Add(customer);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported customer {customer.FirstName} {customer.LastName} with bought tickets: {customer.Tickets.Count}!");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}