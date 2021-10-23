namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static object JsonCOnvert { get; private set; }

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(p => new ProjectExportModel
                {
                    TasksCount = p.Tasks.Count(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ProjectTaskExportModel
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .ToArray()
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProjectExportModel[]), new XmlRootAttribute("Projects"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var writer = new StringWriter(sb);

            serializer.Serialize(writer, projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new EmployeeExportModel
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .ToArray()
                        .Where(et => et.Task.OpenDate >= date)
                        .Select(et => new EmployeeTaskExportModel
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                        .OrderByDescending(t => t.DueDate)
                        .ThenBy(t => t.TaskName)
                        .ToArray()
                })
                .Take(10)
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .ToArray();

            var serializer = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return serializer;
        }
    }
}