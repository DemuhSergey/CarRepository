using Car.DAL.EF;

namespace Car.DAL.Migrations.Car
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Car";
        }

        protected override void Seed(CarContext context)
        {
            context.Marks.AddOrUpdate(t=>t.Name, CarData.GetMarks().ToArray());
            context.SaveChanges();

            context.Models.AddOrUpdate(t=>t.Name, CarData.GetModels(context).ToArray());
            context.SaveChanges();

            context.Cars.AddOrUpdate(t=>t.Id, CarData.GetCars(context).ToArray());
            context.SaveChanges();
        }
    }
}
