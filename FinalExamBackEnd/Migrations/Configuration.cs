namespace FinalExamBackEnd.Migrations
{
    using FinalExamBackEnd.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalExamBackEnd.DAL.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        
        protected override void Seed(FinalExamBackEnd.DAL.RestaurantContext context)
        {
            var staffs = new List<Staff>
            {
                new Staff { FirstName = "Seidagalimov",   LastName = "Serik", Mail = "Serik@gmail.com",
                    HireDate = DateTime.Parse("2016-05-01") },
                new Staff { FirstName = "Tolysbaeva",   LastName = "Sharafat", Mail = "Sharafat@gmail.com",
                    HireDate = DateTime.Parse("2016-05-01") },
                new Staff { FirstName = "Oraz",   LastName = "Azamat", Mail = "Aza@gmail.com",
                    HireDate = DateTime.Parse("2016-05-01") }
            };
            staffs.ForEach(s => context.Staffs.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{ FirstName = "Dinara", LastName = "Tusupova", Mail = "Dinara@gmail.com", Accumulation = 20000},
                new Client{ FirstName = "Goshan", LastName = "Nurbek", Mail = "Goha@gmail.com", Accumulation = 30000},
                new Client{ FirstName = "Danil", LastName = "Parshukov", Mail = "Danil@gmail.com", Accumulation = 40000}

            };
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
            new Department{ DepName = "Administration"},
            new Department{ DepName = "Human Resources"},
            new Department{ DepName = "Accounting"},
            new Department{ DepName = "Products"}

            };

            foreach (Department d in departments)
            {
                var DepartmentInDataBase = context.Departments.Where(
                    s =>
                         s.ID == d.ID &&
                         s.ID == d.ID).SingleOrDefault();
                if (DepartmentInDataBase == null)
                {
                    context.Departments.Add(d);
                }
            }
            context.SaveChanges();
        }
    }
}
