﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DAL.Entities
{
    public class Mark
    {
        [Key]
        [MaxLength(30)]
        public string Name { get; set; }

        public List<Model> Models { get; set; }
    }
}
