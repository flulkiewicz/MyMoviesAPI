﻿using AutoMapper.Internal;
using AutoMapper;
using MyMoviesAPI.Models;
using MyMoviesAPI.Dtos.MovieDtos;

namespace MyMoviesAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieDto>();
        }
    }
}