﻿using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using video_rentals.Dtos;
using video_rentals.Models;


namespace video_rentals.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        // GET/Api/Customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c=>c.MemberShipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }


        // GET/Api/Customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)

                return NotFound();


            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
                
        }

        // Post/Api/Customers

            [HttpPost]
        public IHttpActionResult CreateCustomer( CustomerDto customerDto)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);

            _context.SaveChanges();


            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        // Put/Api/Customers/1

            [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (ModelState.IsValid)
                return BadRequest();


                    var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customerInDb == null)
                return BadRequest();

            Mapper.Map(customerDto, customerInDb);


            _context.SaveChanges();

            return Ok();
        }


        // Delete/Api/Customers/1

            [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customerInDb == null)
                return NotFound();


            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
