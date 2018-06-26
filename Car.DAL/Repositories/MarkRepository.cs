using System.Collections.Generic;
using Car.DAL.Entities;

namespace Car.DAL.Repositories
{
    public class MarkRepository
    {
        public EF.CarContext db;

        public MarkRepository(EF.CarContext context)
        {
            this.db = context;
        }

        public IEnumerable<Mark> GetAll()
        {
            return db.Marks;
        }

        public Mark Get(string name)
        {
            return db.Marks.Find(name);
        }
    }
}
