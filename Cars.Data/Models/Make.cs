using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cars.Data.Models
{
  public  class Make
    {
        [Key]
        public int MakeId { get; set; }

        public string NameOfMake { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
