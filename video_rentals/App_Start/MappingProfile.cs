using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using video_rentals.Models;
using video_rentals.Dtos;

namespace video_rentals.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to Dto

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();



            //Dtos to Domain

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}