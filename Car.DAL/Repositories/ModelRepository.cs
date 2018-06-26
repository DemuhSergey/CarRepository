using System.Collections.Generic;
using System.Linq;
using Car.DAL.EF;
using Car.DAL.Entities;


namespace Car.DAL.Repositories
{
    public class ModelRepository
    {
        private CarContext db;
        public ModelRepository(CarContext context)
        {
            db = context;
        }
        public IEnumerable<Model> GetAll()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Models;
        }

        public Model GetModel(string name)
        {
            var temp = db.Models.FirstOrDefault(x => x.Name == name);
            return temp;
        }

        public Model Get(string model)
        {
            return db.Models.Find(model);
        }
    }
}
