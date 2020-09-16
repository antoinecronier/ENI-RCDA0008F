using Demo8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo8.Models
{
    public class UserVM
    {
        public User User { get; set; }

		public int Age
		{
			get {
				return (DateTime.Today.Year - this.User.DayOfBirth.Year);
			}
		}

	}
}