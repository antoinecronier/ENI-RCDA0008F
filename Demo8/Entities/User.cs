using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo8.Entities
{
    public class User
    {
        private long id;
        private string firstname;
        private string lastname;
        private DateTime dayOfBirth;

        public long Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime DayOfBirth { get => dayOfBirth; set => dayOfBirth = value; }
    }
}