using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    internal class Exercises
    {
        private DbContext Context;

        public Exercises(DbContext context)
        {
            Context = context;
        }

        internal void Run()
        {
            SoftUniContext context = (SoftUniContext)Context;

            string exerciseResult =
            //GetEmployeesFullInformation(context);
            //GetEmployeesWithSalaryOver50000(context);
            //GetEmployeesFromResearchAndDevelopment(context);
            //AddNewAddressToEmployee(context);
            //GetEmployeesInPeriod(context);
            //GetAddressesByTown(context);
            //GetEmployee147(context);
            //GetDepartmentsWithMoreThan5Employees(context);
            //GetLatestProjects(context);
            //IncreaseSalaries(context);
            //GetEmployeesByFirstNameStartingWithSa(context);
            //DeleteProjectById(context);
            RemoveTown(context);


            Console.WriteLine(exerciseResult);
        }

        private static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                }).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return result.ToString();
        }
        private static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50_000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(e => e.FirstName)
                .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return result.ToString();
        }
        private static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new { e.FirstName, e.LastName, DepartmentName = e.Department.Name, e.Salary })
                .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.DepartmentName} {e.Salary:f2}");
            }

            return result.ToString();
        }
        private static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            var nakovEmployee = context.Employees.Single(x => x.LastName == "Nakov");

            nakovEmployee.Address = address;

            context.SaveChanges();

            //var addressTexts = context.Employees.Select(e => e.Address.AddressText)
            //                                    .OrderByDescending(x => x.AddressId)
            //                                    .Take(10)
            //                                    .ToList();

            var addressTexts = context.Employees.OrderByDescending(x => x.AddressId)
                                                .Select(e => e.Address.AddressText)
                                                .Take(10)
                                                .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var addressText in addressTexts)
            {
                result.AppendLine(addressText);
            }

            return result.ToString();
        }
        private static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeesWithProjects2001to2003 = context.Employees.Where(e => e.Projects
                                .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                             .Take(10)
                             .Select(e => new
                             {
                                 e.FirstName,
                                 e.LastName,
                                 ManagerFirstName = e.Manager.FirstName,
                                 ManagerLastName = e.Manager.LastName,
                                 e.Projects,
                             })
                             .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var e in employeesWithProjects2001to2003)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    if (p.EndDate != null)
                    {
                        result.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")}");
                    }
                    else
                    {
                        result.AppendLine($"--{p.Name} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - not finished");
                    }
                }
            }

            return result.ToString();
        }
        private static string GetAddressesByTown(SoftUniContext context)
        {
            // Find all addresses, ordered by the number of employees who live there(descending), 
            // then by town name(ascending) and finally by address text(ascending).
            // Take only the first 10 addresses.
            // For each address return it in the format 
            // "<AddressText>, <TownName> - <EmployeeCount> employees"

            var addresses = context.Addresses.OrderByDescending(a => a.Employees.Count)
                                             .ThenBy(a => a.Town.Name)
                                             .ThenBy(a => a.AddressText)
                                             .Take(10)
                                             .Select(a => new
                                             {
                                                 a.AddressText,
                                                 TownName = a.Town.Name,
                                                 EmployeeCount = a.Employees.Count
                                             })
                                             .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var a in addresses)
            {
                result.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return result.ToString();
        }
        private static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.Where(e => e.EmployeeId == 147)
                                            .Select(e => new
                                            {
                                                e.FirstName,
                                                e.LastName,
                                                e.JobTitle,
                                                Projects = e.Projects.OrderBy(p => p.Name).ToList()
                                            })
                                            .Single();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in employee.Projects)
            {
                result.AppendLine($"{p.Name}");
            }

            return result.ToString();
        }
        private static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var depts = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    d.Employees
                }).ToList();

            StringBuilder result = new StringBuilder();
            foreach (var d in depts)
            {
                result.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString();
        }
        private static string GetLatestProjects(SoftUniContext context)
        {
            var last10Projects = context.Projects.OrderByDescending(p => p.StartDate).OrderBy(p => p.Name).ToList();
            StringBuilder result = new StringBuilder();
            foreach (var project in last10Projects)
            {
                result.AppendLine($"{project.Name}\n{project.Description}\n{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return result.ToString();
        }
        private static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employeesWithIncreasedSalary = context.Employees.Where(e => departments.Contains(e.Department.Name))
                                                                .OrderBy(e => e.FirstName)
                                                                .ThenBy(e => e.LastName)
                                                                .ToList();
            StringBuilder result = new StringBuilder();
            foreach (var e in employeesWithIncreasedSalary)
            {
                e.Salary *= 1.12M;
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            context.SaveChanges();

            return result.ToString();
        }
        private static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesStartingWithSa = context.Employees.Where(e => e.FirstName.Substring(0, 2).ToLower() == "sa")
                                                           .Select(e => new
                                                           {
                                                               e.FirstName,
                                                               e.LastName,
                                                               e.JobTitle,
                                                               e.Salary,
                                                           })
                                                           .OrderBy(e => e.FirstName)
                                                           .ThenBy(e => e.LastName)
                                                           .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var e in employeesStartingWithSa)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return result.ToString();
        }
        private static string DeleteProjectById(SoftUniContext context)
        {
            return ":(";
        }
        private static string RemoveTown(SoftUniContext context)
        {
            var town = new Town
            {
                Name = "Seattle",
            };

            // Remove Address foreign keys from other tables

            context.Addresses.RemoveRange(context.Addresses.Where(a => a.Town == town));

            context.Towns.Remove(town);


            context.SaveChanges();


            return ":(";
        }
    }
}
