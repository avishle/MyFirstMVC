using MyFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.ModelBinders
{
    public class CustomerBind : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objConent = controllerContext.HttpContext;
            string firstName = objConent.Request.Form["txtFirstName"];
            string lastName = objConent.Request.Form["txtLastName"];
            string customerNumber = objConent.Request.Form["txtCustomerNumber"];

            Customer c = new Customer { FirstName = firstName, LastName = lastName, CustomerNumber=customerNumber };
            return c;

            //throw new NotImplementedException();
        }
    }
}