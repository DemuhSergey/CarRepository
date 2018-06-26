using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL.Services;

namespace PL.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Цена:")]
        public decimal Price { get; set; }
        [Display(Name = "Картинка машины:")]
        public byte[] Image { get; set; }
        [Display(Name = "Объем:")]
        public string Valume { get; set; }
        [Display(Name = "Цвет:")]
        public string Color { get; set; }
        [Display(Name = "Коробка передач:")]
        public string Transmission { get; set; }
        [Display(Name = "Модель:")]
        public string ModelName { get; set; }
        [Display(Name = "Марка:")]
        public string MarkName { get; set; }
    }
}