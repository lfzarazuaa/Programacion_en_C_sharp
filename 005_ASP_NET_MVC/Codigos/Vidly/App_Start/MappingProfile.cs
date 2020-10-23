using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile() // Constructor.
        {
            Mapper.CreateMap<Customer, CustomerDto>(); // Asignar valores de Customer a CustomerDto.
            Mapper.CreateMap<CustomerDto, Customer>(); // Asignar valores de CustomerDto a Customer.
            
            Mapper.CreateMap<Movie, MovieDto>(); // Asignar valores de Movie a MovieDto.
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.DateAdded, opt => opt.Ignore()); // Asignar valores de MovieDto a Movie.

            Mapper.CreateMap<MembershipType, MembershipTypeDto>(); // Asignar valores de MembershipType a MembershipTypeDto. 
            Mapper.CreateMap<MembershipTypeDto, MembershipType>(); // Asignar valores de MembershipTypeDto a MembershipType. 
        }
    }
}