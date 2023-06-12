using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMoviesAPI.Data;
using MyMoviesAPI.Dtos.MovieDtos;
using MyMoviesAPI.Models;

namespace MyMoviesAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MovieService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetMovieDto>> AddMovie(AddMovieDto movieDto)
        {
            var response = new ServiceResponse<GetMovieDto>();

            var movie = _mapper.Map<Movie>(movieDto);

            _context.Add(movie);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetMovieDto>(movie);
            response.Message = "Film został dodany do bazy.";

            return response;
        }

        public async Task<ServiceResponse<List<GetMovieDto>>> GetMovies()
        {
            var response = new ServiceResponse<List<GetMovieDto>>();

            var movies = await _context.Movies.ToListAsync();

            response.Data = movies.Select(_mapper.Map<GetMovieDto>).ToList();
            response.Message = "Lista filmów w bazie danych";

            return response;
        }
    }
}
