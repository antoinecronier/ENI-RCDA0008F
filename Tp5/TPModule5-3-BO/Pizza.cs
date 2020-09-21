using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule5_3_BO
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string Nom { get; set; }

        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public double MyProperty { get; set; }
    }
}
