using System;
using System.Collections.Generic;
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
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
    }
}