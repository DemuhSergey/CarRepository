using System.Collections.Generic;
using System.Data.Entity;
using Car.DAL.Entities;

namespace Car.DAL.EF
{
    public class CarContext : DbContext
    {
        public CarContext(string connectionString)
            : base(connectionString)
        {
            
        }

        public virtual DbSet<Entities.Car> Cars { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Model> Models { get; set; }
    }
}