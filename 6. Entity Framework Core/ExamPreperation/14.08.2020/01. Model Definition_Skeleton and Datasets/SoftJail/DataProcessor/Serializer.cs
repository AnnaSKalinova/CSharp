namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prosiners = context.Prisoners
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new PrisonerExportDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(o => new PrisonerOfficerExportDto
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers
                        .Select(o => o.Officer.Salary).Sum(), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(prosiners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            StringBuilder output = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PrisonerInboxExportDto[]), new XmlRootAttribute("Prisoners"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringWriter stringWriter = new StringWriter(output);

            var inputPrisoners = prisonersNames
                .Split(",")
                .ToArray();

            var prisoners = context.Prisoners
                .ToArray()
                .Where(p => inputPrisoners.Contains(p.FullName))
                .Select(p => new PrisonerInboxExportDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new PrisonerInboxMessageExportDto
                        {
                            Description = string.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, prisoners, namespaces);

            return output.ToString().TrimEnd();
        }
    }
}