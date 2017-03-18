using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstMVC.DAL
{
    public class CustomerDAL :DbContext 
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("tblCustomers");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}