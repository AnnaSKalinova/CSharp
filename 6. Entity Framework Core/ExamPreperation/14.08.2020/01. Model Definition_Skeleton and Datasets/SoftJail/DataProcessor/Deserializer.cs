namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            var jsonData = JsonConvert.DeserializeObject<DepartmentImportDto[]>(jsonString);

            foreach (var jsonDepartment in jsonData)
            {
                if (!IsValid(jsonDepartment))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = jsonDepartment.Name
                };

                bool isCellsNumberValid = true;

                foreach (var jsonCell in jsonDepartment.Cells)
                {
                    if (!IsValid(jsonCell))
                    {
                        isCellsNumberValid = false;
                        break;
                    }

                    var cell = new Cell
                    {
                        CellNumber = jsonCell.CellNumber,
                        HasWindow = jsonCell.HasWindow
                    };

                    department.Cells.Add(cell);
                }

                if (!department.Cells.Any() || !isCellsNumberValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                context.Departments.Add(department);
                context.SaveChanges();
                output.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            var jsonData = JsonConvert.DeserializeObject<PrisonerImputDto[]>(jsonString);

            foreach (var jsonPrisoner in jsonData)
            {
                if (!IsValid(jsonPrisoner))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(jsonPrisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                DateTime? releaseDate;
                if (jsonPrisoner.ReleaseDate != null)
                {
                    DateTime releaseDateProject;
                    bool isReleaseDateValid = DateTime.TryParseExact(jsonPrisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateProject);

                    if (!isReleaseDateValid)
                    {
                        output.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateProject;
                }
                else
                {
                    releaseDate = null;
                }

                var prisoner = new Prisoner
                {
                    FullName = jsonPrisoner.FullName,
                    Nickname = jsonPrisoner.Nickname,
                    Age = jsonPrisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = jsonPrisoner.Bail,
                    CellId = jsonPrisoner.CellId
                };

                foreach (var jsonMail in jsonPrisoner.Mails)
                {
                    if (!IsValid(jsonMail))
                    {
                        output.AppendLine("Invalid Data");
                        continue;
                    }

                    var mail = new Mail
                    {
                        Description = jsonMail.Description,
                        Sender = jsonMail.Sender,
                        Address = jsonMail.Address
                    };

                    prisoner.Mails.Add(mail);
                }

                context.Prisoners.Add(prisoner);
                context.SaveChanges();
                output.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var output = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<OfficerImportDto>), new XmlRootAttribute("Officers"));

            StringReader stringReader = new StringReader(xmlString);

            var officerDtos = (List<OfficerImportDto>)xmlSerializer.Deserialize(stringReader);

            foreach (var xmlOfficer in officerDtos)
            {
                if (!IsValid(xmlOfficer))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                object positionObj;
                bool isPositionValid = Enum.TryParse(typeof(Position), xmlOfficer.Position, out positionObj);

                if (!isPositionValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                object WeaponObj;
                bool isWeaponValid = Enum.TryParse(typeof(Weapon), xmlOfficer.Weapon, out WeaponObj);

                if (!isWeaponValid)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = xmlOfficer.Name,
                    Salary = xmlOfficer.Money,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)WeaponObj,
                    DepartmentId = xmlOfficer.DepartmentId
                };

                foreach (var xmlPrisoner in xmlOfficer.Prisoners)
                {
                    if (!IsValid(xmlPrisoner))
                    {
                        output.AppendLine("Invalid Data");
                        continue;
                    }

                    var prisoner = new OfficerPrisoner
                    {
                        Officer = officer,
                        PrisonerId = xmlPrisoner.Id
                    };

                    officer.OfficerPrisoners.Add(prisoner);
                }

                context.Officers.Add(officer);
                context.SaveChanges();
                output.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count()} prisoners)");
            }

            return output.ToString().TrimEnd();
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