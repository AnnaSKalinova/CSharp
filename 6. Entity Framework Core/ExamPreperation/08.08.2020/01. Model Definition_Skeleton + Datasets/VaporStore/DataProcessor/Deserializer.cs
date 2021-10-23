namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();
			var data = JsonConvert
				.DeserializeObject<IEnumerable<GameImportModel>>(jsonString);

            foreach (var jsonGame in data)
            {
                if (!IsValid(jsonGame) || !jsonGame.Tags.Any())
                {
					output.AppendLine("Invalid Data");
					continue;
                }

				var genre = context.Genres.FirstOrDefault(g => g.Name == jsonGame.Genre);
                if (genre == null)
                {
					genre = new Genre { Name = jsonGame.Genre };
                }

				var developer = context.Developers.FirstOrDefault(d => d.Name == jsonGame.Developer)
					?? new Developer { Name = jsonGame.Developer };

				var game = new Game
				{
					Name = jsonGame.Name,
					Genre = genre,
					Developer = developer,
					Price = jsonGame.Price,
					ReleaseDate = jsonGame.ReleaseDate.Value
				};

                foreach (var jsonTag in jsonGame.Tags)
                {
					var tag = context.Tags.FirstOrDefault(t => t.Name == jsonTag)
						?? new Tag { Name = jsonTag };

					game.GameTags.Add(new GameTag { Tag = tag });
                }

				context.Add(game);
				context.SaveChanges();
				output.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags");
            }
			
			return output.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var output = new StringBuilder();
			var data = JsonConvert.DeserializeObject<IEnumerable<UserImportModel>>(jsonString);

            foreach (var jsonUser in data)
            {
                if (!IsValid(jsonUser))
                {
					output.AppendLine("Invalid Data");
					continue;
                }

                foreach (var card in jsonUser.Cards)
                {
                    if (!IsValid(card))
                    {
						output.AppendLine("Invalid Data");
						continue;
                    }
                }

				var user = new User
				{
					Age = jsonUser.Age,
					Email = jsonUser.Email,
					FullName = jsonUser.FullName,
					Username = jsonUser.Username,
					Cards = jsonUser.Cards.Select(c => new Card
					{
						Cvc = c.CVC,
						Type = c.Type.Value,
						Number = c.Number
					})
					.ToArray(),
				};

				context.Users.Add(user);
				context.SaveChanges();
                output.AppendLine($"Imported {jsonUser.Username} with {jsonUser.Cards.Count()} cards");
            }
			
			return output.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder output = new StringBuilder();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseImportModel[]), new XmlRootAttribute("Purchases"));

			StringReader stringReader = new StringReader(xmlString);

			PurchaseImportModel[] purchaseDtos = (PurchaseImportModel[])xmlSerializer.Deserialize(stringReader);

            foreach (var xmlPurchase in purchaseDtos)
            {
                if (!IsValid(xmlPurchase))
                {
					output.AppendLine("Invalid Data");
					continue;
                }

				var game = context.Games.FirstOrDefault(g => g.Name == xmlPurchase.Title);

				var card = context.Cards.FirstOrDefault(c => c.Number == xmlPurchase.Card);

				DateTime date;
				bool isDateValid = DateTime.TryParseExact(xmlPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

				if (game == null || card == null)
				{
					output.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase
				{
					Game = game,
					Type = xmlPurchase.Type.Value,
					ProductKey = xmlPurchase.Key,
					Card = card,
					Date = date
				};

				context.Purchases.Add(purchase);
				context.SaveChanges();
				output.AppendLine($"Imported {game.Name} for {purchase.Card.User.Username}");
            }

			return output.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}