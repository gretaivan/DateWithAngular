using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

/*
* Is a class that established the EntityFramework conenction between the Entity and DB
*/
namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){

        }
        public DbSet<AppUser> Users { get; set; }

    }
}