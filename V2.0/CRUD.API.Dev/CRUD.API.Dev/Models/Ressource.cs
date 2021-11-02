using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Dev.Models
{
   public  class Ressource
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name can only be 50 caractere")]
        public string Name { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public string DocPath { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Doctype { get; set; }
    }
}
