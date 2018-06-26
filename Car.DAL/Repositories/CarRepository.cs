using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Car.DAL.Entities;
using Car.DAL.Interfaces;


namespace Car.DAL.Repositories
{
    public class CarRepository: IRepository<Entities.Car>
    {
        private EF.CarContext db;

        public CarRepository(EF.CarContext context)
        {
            this.db = context;
        }

        public IEnumerable<Entities.Car> GetAll()
        {
            return db.Cars;
        }

        public Entities.Car Get(int name)
        {
            return db.Cars.Find(name);
        }

        public void Create(Entities.Car car)
        {
            db.Cars.Add(car);
        }

        public void Update(Entities.Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }
    }
}
