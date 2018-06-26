using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ICarService
    {
        void AddCar(CarDto car);
        void UpdateCar(CarDto car);
        IEnumerable<CarDto> SortCar(string status);
        byte[] GetCarImage(HttpPostedFileBase uploadImage);
        void Dispose();
        SelectList GetSortStatuses();
        List<ModelDto> GetModels();
        List<MarkDto> GetMarks();
        ModelDto GetModel(string mark);
        CarDto GetCar(int id);
    }
}
