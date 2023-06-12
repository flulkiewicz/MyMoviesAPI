﻿using Microsoft.AspNetCore.Mvc;
using MyMoviesAPI.Dtos.MovieDtos;
using MyMoviesAPI.Models;
using MyMoviesAPI.Services;

namespace MyMoviesAPI.Controllers
{
    [ApiController]
    [Route("/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> GetMovies()
        {
            return Ok(await _movieService.GetMovies());
        }

        [HttpGet("/fetch")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> FetchMovies()
        {
            return Ok(await _movieService.FetchMovies());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> AddMovie(AddMovieDto dto)
        {
            return Ok(await _movieService.AddMovie(dto));
        }
    }
}
