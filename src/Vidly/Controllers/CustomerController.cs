using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Controllers;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> mteja = new List<Customer>()
            {
                new Customer{ Id = 1, Name="fredrick" },
                new Customer{ Id = 2, Name="wagathegi" },
                new Customer{ Id = 1, Name="kamau" }
            };
           
            return View(mteja);
        }
    }
}