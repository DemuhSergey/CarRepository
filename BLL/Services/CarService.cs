using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Car.DAL.Entities;
using Car.DAL.Interfaces;

namespace BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _database;
        private string _sortStatus;

        public CarService(IUnitOfWork uow)
        {
           
            _database = uow;
        }

        public CarDto GetCar(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car.DAL.Entities.Car, CarDto>()).CreateMapper();
            return mapper.Map<Car.DAL.Entities.Car, CarDto>(_database.Cars.Get(id));
        }

        public ModelDto GetModel(string mark)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Model, ModelDto>()).CreateMapper();
            return mapper.Map<Model, ModelDto>(_database.Models.GetModel(mark));;
        }
        public List<MarkDto> GetMarks()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Mark, MarkDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Mark>, List<MarkDto>>(_database.Marks.GetAll());
        }
        public List<ModelDto> GetModels()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Model, ModelDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Model>, List<ModelDto>>(_database.Models.GetAll());
        }
        public void AddCar(CarDto carDto)
        {
            var model = _database.Models.Get(carDto.ModelName);
            if (model == null)
                throw new ValidationException("Модель не найдена", "");

            var car = new Car.DAL.Entities.Car
            {
                Price = carDto.Price,
                Image = carDto.Image,
                Transmission = carDto.Transmission,
                Color = carDto.Color,
                ModelName = carDto.ModelName,
                Valume = carDto.Valume
            };

            _database.Cars.Create(car);
            _database.Save();
        }
        public void UpdateCar(CarDto carDto)
        {
            var model = _database.Models.Get(carDto.ModelName);
            if (model == null)
                throw new ValidationException("Машина не найдена", "");

            var car = new Car.DAL.Entities.Car
            {
                Id = carDto.Id,
                Price = carDto.Price,
                Image = carDto.Image,
                Transmission = carDto.Transmission,
                Color = carDto.Color,
                ModelName = carDto.ModelName,
                Valume = carDto.Valume
            };

            _database.Cars.Update(car);
            _database.Save();
        }
        public IEnumerable<CarDto> SortCar(string status)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car.DAL.Entities.Car, CarDto>()).CreateMapper();
            var cars = mapper.Map<IEnumerable<Car.DAL.Entities.Car>, List<CarDto>>(_database.Cars.GetAll());

            if (status != null)
            {
                _sortStatus = status;
            }

            switch (_sortStatus)
            {
                case "По возрастанию":
                    return cars.OrderBy(car => car.Price);
                case "По убыванию":
                    return cars.OrderByDescending(car => car.Price);
                 default:
                     return cars;
            }
        }
        public SelectList GetSortStatuses()
        {
            return new SelectList(new List<string>
            {
                "Не сортировать", "По возрастанию", "По убыванию"
            });
        }

        public byte[] GetCarImage(HttpPostedFileBase uploadImage)
        {
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }

            return imageData;
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
