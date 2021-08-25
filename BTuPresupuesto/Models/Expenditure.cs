using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BTuPresupuesto.Models
{
    public class Expenditure
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Detail { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
