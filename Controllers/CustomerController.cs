using MyFirstMVC.DAL;
using MyFirstMVC.ModelBinders;
using MyFirstMVC.Models;
using MyFirstMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer c = new Customer { FirstName="Avishag" , LastName="Saban", CustomerNumber="1111"};
            return View("customer",c);
        }
        public ActionResult Enter()
        {
            return View(new Customer());
        }
        public ActionResult SearchCustomer()
        {
            CustomersViewModel custViewModel = new CustomersViewModel();
            custViewModel.customer = new Customer();
            // CustomerDAL cDAL = new CustomerDAL();
            custViewModel.custs = new List<Customer> ();//cDAL.Customers.ToList<Customer>();
            return View(custViewModel);
        }
        public ActionResult GetCustomersByJson()
        {
            return Json(new CustomerDAL().Customers.ToList<Customer>(),
                        JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public ActionResult Submit()
        {
            Customer custObj = new Customer();
            CustomerDAL cDAL = new CustomerDAL();
            custObj.FirstName = Request.Form["FirstName"].ToString();
            custObj.LastName = Request.Form["LastName"].ToString();
            custObj.CustomerNumber = Request.Form["CustomerNumber"].ToString();
            if (ModelState.IsValid && NotEmpty(custObj))
            {               
                cDAL.Customers.Add(custObj);
                cDAL.SaveChanges();       
            }
            
             return GetCustomersByJson();

        }
        private Boolean NotEmpty(Customer c)
        {
            return c.FirstName != "" && c.LastName != "" && c.CustomerNumber != "";
        }
        [HttpPost]
        public ActionResult FindCustomer(CustomersViewModel oldCVM)
        {
            CustomersViewModel newCVN = new CustomersViewModel();
            //String stringSearch = Request.Form["FirstName"];
            CustomerDAL cDAL = new CustomerDAL();

            newCVN.custs = (from x in cDAL.Customers
                            where x.FirstName.Contains(oldCVM.customer.FirstName)
                            select x).ToList<Customer>();
            newCVN.customer = new Customer();
       
            return View("SearchCustomer", newCVN);

        }
    }
}