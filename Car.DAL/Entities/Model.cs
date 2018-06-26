using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DAL.Entities
{
    public class Model
    {
        [Key]
        [MaxLength(30)]
        public string Name { get; set; }

        public string MarkName { get; set; }
        public Mark Mark { get; set; }

        public List<Car> Cars { get; set; }
    }
}
