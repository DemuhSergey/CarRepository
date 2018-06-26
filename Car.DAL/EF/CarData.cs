using System.Collections.Generic;
using Car.DAL.Entities;

namespace Car.DAL.EF
{
    public class CarData
    {
        public static List<Mark> GetMarks()
        {
            var marks = new List<Mark>
            {
                new Mark{Name = "BMW"},
                new Mark {Name = "Audi"},
                new Mark {Name = "Volvo"}
            };
            return marks;
        }

        public static List<Model> GetModels(CarContext context)
        {
            var models = new List<Model>
            {
                new Model { Name = "X5", MarkName = context.Marks.Find("BMW").Name },
                new Model { Name = "X6", MarkName = context.Marks.Find("BMW").Name },
                new Model { Name = "M3", MarkName = context.Marks.Find("BMW").Name },
                new Model() { Name = "A6", MarkName = context.Marks.Find("Audi").Name },
                new Model() { Name = "A4", MarkName = context.Marks.Find("Audi").Name },
                new Model() { Name = "XC60", MarkName = context.Marks.Find("Volvo").Name }
            };
            return models;
        }

        public static List<Entities.Car> GetCars(CarContext context)
        {
            var cars = new List<Entities.Car>
            {
                new Entities.Car { Color = "Красный", Price = 25000, ModelName = context.Models.Find("X5").Name },
                new Entities.Car { Color = "Черный", Price = 23000, ModelName = context.Models.Find("X5").Name },
                new Entities.Car { Color = "Красный", Price = 25000, ModelName = context.Models.Find("A6")?.Name },
                new Entities.Car { Color = "Желтый", Price = 18000, ModelName = context.Models.Find("xc60").Name }
            };

            return cars;
        }
    }
}
