using System;
using Car.DAL.Interfaces;

namespace Car.DAL.Repositories
{
    public class EfUnitOfWork :IUnitOfWork
    {
        private EF.CarContext db;
        private CarRepository _carRepository;
        private MarkRepository _markRepository;
        private ModelRepository _modelRepository;
        public EfUnitOfWork(string connectionString)
        {
            db = new EF.CarContext(connectionString);
        }

        public IRepository<Entities.Car> Cars => _carRepository ?? (_carRepository = new CarRepository(db));
        public ModelRepository Models => _modelRepository ?? (_modelRepository = new ModelRepository(db));
        public MarkRepository Marks => _markRepository ?? (_markRepository = new MarkRepository(db));

        public bool Disposed { get => _disposed; set => _disposed = value; }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
