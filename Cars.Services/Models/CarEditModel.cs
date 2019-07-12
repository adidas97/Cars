using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Services.Models
{
   public class CarEditModel
    {

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int YearOfBuilding { get; set; }

        public int HorsePower { get; set; }

        public string TypeOfEngine { get; set; }

        public string TypeOfGearbox { get; set; }

        public string Category { get; set; }
    }
}
