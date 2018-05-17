﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using video_rentals.Models;
using video_rentals.Dtos;


namespace video_rentals.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController(){

            _context = new ApplicationDbContext();

            }

        //Get  /api/movie
        public IEnumerable<MovieDto> GetMovie()
        {
            return _context.Movie.Include(m=>m.Genre).ToList().Select(Mapper.Map<Movie,MovieDto>);
        }


        //Get  / api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }


        //Post / api/movie

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }  


        //PUT / api/movie/1

            [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto,movieInDb);

           

            _context.SaveChanges();

            return Ok();
        }

        //Delete / api/movie/

            [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
