using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVC.ViewModel
{
    public class CustomersViewModel
    {
        public Customer customer { get; set; }
        public List<Customer> custs { get; set; }
        
    }
}