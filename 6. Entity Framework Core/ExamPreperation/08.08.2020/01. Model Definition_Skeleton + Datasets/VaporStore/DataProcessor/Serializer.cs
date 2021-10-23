namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.ToArray()
				.Where(gr => genreNames.Contains(gr.Name))
				.Select(gr => new
				{
					Id = gr.Id,
					Genre = gr.Name,
					Games = gr.Games
							.Where(gm => gm.Purchases.Any())
							.Select(gm => new
							{
								Id = gm.Id,
								Title = gm.Name,
								Developer = gm.Developer.Name,
								Tags = String.Join(", ", gm.GameTags
										.Select(t => t.Tag.Name)
										.ToArray()),
								Players = gm.Purchases.Count
							})
							.OrderByDescending(gm => gm.Players)
							.ThenBy(gm => gm.Id)
							.ToArray(),
					TotalPlayers = gr.Games.Sum(gm => gm.Purchases.Count)
				})
				.OrderByDescending(gr => gr.TotalPlayers)
				.ThenBy(gr => gr.Id)
				.ToArray();

			var json = JsonConvert.SerializeObject(genres, Formatting.Indented);

			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserExportModel[]), new XmlRootAttribute("Users"));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			StringWriter sw = new StringWriter();

			var users = context.Users
				.ToArray()
				.Where(u => u.Cards.Any(c => c.Purchases.Any()))
				.Select(u => new UserExportModel
				{
					Username = u.Username,
					TotalSpent = u.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price)),
					Purchases = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.Select(p => new UserPurchaseExportModel
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new UserGameExportModel
							{
								Title = p.Game.Name,
								Price = p.Game.Price,
								Genre = p.Game.Genre.Name
							}
						})
						.OrderBy(p => p.Date)
						.ToArray()
				})
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			xmlSerializer.Serialize(sw, users, namespaces);

			return sw.ToString().TrimEnd();
		}
	}
}