using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cars.Data.Models
{
  public  class Car
    {
        public int Id { get; set; }

        [ForeignKey("MakeId")]
        public int MakeId { get; set; }
        public Make Make { get; set; }

        [ForeignKey("ModelId")]
        public int ModelId { get; set; }
        public Model Model { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int YearOfBuilding { get; set; }

        public int HorsePower { get; set; }

        public string TypeOfEngine { get; set; }

        public string TypeOfGearbox { get; set; }

        public string Category { get; set; }

        public bool Image { get; set; }
    }
}
