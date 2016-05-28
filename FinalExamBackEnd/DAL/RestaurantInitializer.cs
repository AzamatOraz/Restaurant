using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FinalExamBackEnd.Models;

namespace FinalExamBackEnd.DAL
{
    public class RestaurantInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RestaurantContext>
    {

        protected override void Seed(RestaurantContext context)
        {
            var staffs = new List<Staff>
            {
                new Staff{FirstName="Serik",LastName="Seidagalimov", Mail = "Serik@gmail.com",HireDate=DateTime.Parse("2016-05-01"), Manager_ID = 1, Department_ID = 1},
                new Staff{FirstName="Sharafat",LastName="Tolysbaeva", Mail = "Sharafat@gmail.com",HireDate=DateTime.Parse("2016-05-01"),Manager_ID = 1 , Department_ID = 1},
                new Staff{FirstName="Azamat",LastName="Oraz",Mail = "Azamat@gmail.com", HireDate=DateTime.Parse("2016-05-01"),Manager_ID = 1, Department_ID = 1}
            };

            staffs.ForEach(s => context.Staffs.Add(s));
            context.SaveChanges();
            var clients = new List<Client>
            {
                new Client{ FirstName = "Dinara", LastName = "Tusupova", Mail = "Dinara@gmail.com",Manager_ID = 1, Accumulation = 20000},
                new Client{ FirstName = "Goshan", LastName = "Nurbek", Mail = "Goha@gmail.com",Manager_ID = 1, Accumulation = 30000},
                new Client{ FirstName = "Danil", LastName = "Parshukov", Mail = "Danil@gmail.com",Manager_ID = 1, Accumulation = 40000}
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();
            var dept = new List<Department>
            {
                new Department{ DepName = "Administration"},
                new Department{ DepName = "Human Resources"},
                new Department{ DepName = "Accounting"},
                new Department{ DepName = "Products"}
            };
            dept.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var menu = new List<Menu>
            {
                new Menu{ FoodType = "Meat"},
                new Menu{ FoodType = "Drinks"},
                new Menu{ FoodType = "Fruits"}
            };
            menu.ForEach(s => context.Menus.Add(s));
            context.SaveChanges();
        }
    }
}

