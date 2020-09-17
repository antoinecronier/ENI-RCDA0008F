using Demo9.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo9.Models
{
    public class Personne
    {
        private long id;
        private string firstname;
        private string lastname;

        public long Id { get => id; set => id = value; }

        [Required]
        [MyValidation]
        public string Firstname { get => firstname; set => firstname = value; }
        [Required]
        [System.ComponentModel.DataAnnotations.MinLength(4,ErrorMessage = "Non")]
        [System.ComponentModel.DataAnnotations.MaxLength(8)]
        public string Lastname { get => lastname; set => lastname = value; }
    }
}