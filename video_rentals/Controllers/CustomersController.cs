using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using video_rentals.Models;
using System.Data.Entity;
using video_rentals.ViewModels;

namespace video_rentals.Controllers
{
    public class CustomersController : Controller
    {


        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var MembershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModels
            {
                Customer=new Customer(),
                MemberShipTypes = MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModels
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };

                return View("CustomerForm",viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                //Mapper.Map(Customer,CustomerInDB)

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLet = customer.IsSubscribedToNewsLet;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModels
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }


    }
}