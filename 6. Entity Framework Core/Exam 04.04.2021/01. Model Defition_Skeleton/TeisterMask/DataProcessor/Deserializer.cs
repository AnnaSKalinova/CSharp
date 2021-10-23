namespace TeisterMask.DataProcessor
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
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ProjectImportModel[]), new XmlRootAttribute("Projects"));

            StringReader stringReader = new StringReader(xmlString);

            ProjectImportModel[] projectDtos = (ProjectImportModel[])xmlSerializer.Deserialize(stringReader);

            foreach (var xmlProject in projectDtos)
            {
                if (!IsValid(xmlProject))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                
                bool isOpenDateValid = DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isOpenDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate;

                if (!String.IsNullOrEmpty(xmlProject.DueDate))
                {
                    DateTime dueDateProject;
                    bool isDueDateValid = DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateProject);

                    if (!isDueDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateProject;
                }
                else
                {
                    dueDate = null;
                }

                var project = new Project
                {
                    Name = xmlProject.Name,
                    DueDate = dueDate,
                    OpenDate = openDate
                };

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    if (!IsValid(xmlTask))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime openDateTask;
                    bool isOpenDateTaskValid = DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDateTask);

                    DateTime dueDateTask;
                    bool isDueDateTaskValid = DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateTask);

                    if (!isOpenDateTaskValid || !isDueDateTaskValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (openDateTask < project.OpenDate || dueDateTask > project.DueDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = xmlTask.Name,
                        OpenDate = openDateTask,
                        DueDate = dueDateTask,
                        ExecutionType = (ExecutionType)xmlTask.ExecutionType,
                        LabelType = (LabelType)xmlTask.LabelType
                    };

                    project.Tasks.Add(task);
                }

                context.Projects.Add(project);
                context.SaveChanges();
                output.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count()));
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();
            var data = JsonConvert.DeserializeObject<EmployeesImportModel[]>(jsonString);

            foreach (var jsonEmployee in data)
            {
                if (!IsValid(jsonEmployee))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone
                };

                foreach (var jsonId in jsonEmployee.Tasks.Distinct())
                {
                    if (!IsValid(jsonId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var jsonTask = context.Tasks
                        .FirstOrDefault(t => t.Id == jsonId);

                    if (jsonTask == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new EmployeeTask
                    {
                        Employee = employee,
                        Task = jsonTask
                    };

                    employee.EmployeesTasks.Add(task);
                }

                context.Employees.Add(employee);
                context.SaveChanges();
                output.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count()} tasks.");
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