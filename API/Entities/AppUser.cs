using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
	public class AppUser
	{
		public int Id { get; set; }
		public String Username { get; set; }

		public byte[] PasswordHash {get; set;}
    public byte[] PaswordSalt { get; set;}


  }
}