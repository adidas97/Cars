using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Web.Models
{
    public class CreateCarViewModel
    {
        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int YearOfBuilding { get; set; }

        public int HorsePower { get; set; }

        public string TypeOfEngine { get; set; }

        public string TypeOfGearbox { get; set; }

        public string Category { get; set; }

        public IFormFile Image { get; set; }
    }
}
