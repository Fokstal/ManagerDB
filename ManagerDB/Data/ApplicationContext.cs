﻿using System;
using ManagerDB.Model;
using Microsoft.EntityFrameworkCore;

namespace ManagerDB.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=CompanyDB; Trusted_Connection=True;");
		}
	}
}
