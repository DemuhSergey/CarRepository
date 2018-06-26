using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.Models;

namespace PL.Extenstions
{
    public static class CarServiceExtensions
    {
        public static List<CarViewModel> GetCarsList(this ICarService service ,IEnumerable<CarDto> carsDto, string mark, string model)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDto, CarViewModel>()).CreateMapper();
            var cars = mapper.Map<IEnumerable<CarDto>, List<CarViewModel>>(carsDto);

            foreach (var car in cars)
            {
                car.MarkName = service.GetModel(car.ModelName).MarkName;
            }

            if (mark != "Все машины" && mark != null)
            {
                cars = cars.Where(p => p.ModelName == model && p.MarkName == mark).ToList();
            }

            return cars;
        }
    }
}