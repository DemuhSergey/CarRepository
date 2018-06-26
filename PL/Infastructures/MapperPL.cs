using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;
using PL.Models;

namespace PL.Infastructures
{
    public static class MapperPL
    {
        public static CarViewModel ToCarViewModel(this CarDto car, string mark)
        {
            return new CarViewModel
            {
                Id = car.Id,
                ModelName = car.ModelName,
                Image = car.Image,
                Color = car.Color,
                Price = car.Price,
                Transmission = car.Transmission,
                Valume = car.Valume,
                MarkName = mark
            };
        }

        public static CarDto ToCarDto(this CarViewModel car)
        {
            return new CarDto
            {
                Id = car.Id,
                ModelName = car.ModelName,
                Image = car.Image,
                Color = car.Color,
                Price = car.Price,
                Transmission = car.Transmission,
                Valume = car.Valume
            };
        }
    }
}