using System;
using Car.DAL.Repositories;

namespace Car.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Entities.Car> Cars { get; }
        ModelRepository Models { get; }
        MarkRepository Marks { get; }
        void Save();
    }
}
