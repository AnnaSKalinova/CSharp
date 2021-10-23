using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            string result = RemoveTown(context);

            Console.WriteLine(result);
        }

        // Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = newAddress;
            context.SaveChanges();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.AddressId,
                    e.Address
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Address.AddressText}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                            .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            ProjectStartDate = ep.Project.StartDate,
                            ProjectEndDate = ep.Project.EndDate,
                        })
                })
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    var startDate = p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = p.ProjectEndDate != null
                    ? p.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                    : "not finished";
                    sb.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.EmployeeId,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        { 
                            ProjectName = ep.Project.Name
                        })
                })
                .Where(e => e.EmployeeId == 147)
                .FirstOrDefault();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in employee.Projects.OrderBy(p => p.ProjectName))
            {
                sb.AppendLine(p.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                { 
                    d.Name,
                    d.Manager.FirstName,
                    d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        { 
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle
                        })
                })
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.FirstName} {d.LastName}");

                foreach (var e in d.Employees
                                   .OrderBy(e => e.FirstName)
                                   .ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10);

            foreach (var p in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            decimal salaryIncrease = 0.12m;

            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => departments.Contains(e.Department.Name))
                .ToList();

            foreach (var e in employees)
            {
                e.Salary += e.Salary * salaryIncrease;
            }

            context.SaveChanges();

            var employeesWithIncreasedSalaries = context
                .Employees
                .Select(e => new
                { 
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                    DepartmentName = e.Department.Name
                })
                .Where(e => departments.Contains(e.DepartmentName))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employeesWithIncreasedSalaries)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                { 
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var project = context
                .Projects
                .Find(2);
            var ep = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .FirstOrDefault();

            context.EmployeesProjects.Remove(ep);
            context.Projects.Remove(project);
            context.SaveChanges();

            var projects = context
                .Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10);

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context
                .Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addresses = context
                .Addresses
                .Where(a => a.TownId == town.TownId)
                .ToList();

            foreach (var e in context.Employees)
            {
                if (addresses.Contains(e.Address))
                {
                    e.Address = null;
                }
            }

            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{addresses.Count} addresses in {town.Name} were deleted";
        }
    }
}
