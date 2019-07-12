using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cars.Data.Models
{
   public class Model
    {
        [Key]
        public int ModelId { get; set; }

        public string NameOfModel { get; set; }

        public int? MakeId { get; set; }

        public Make Make { get; set; }
    }
}
