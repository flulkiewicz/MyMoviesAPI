using MyMoviesAPI.Dtos.MovieDtos;
using MyMoviesAPI.Models;

namespace MyMoviesAPI.Services
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<GetMovieDto>>> GetMovies();
        Task<ServiceResponse<GetMovieDto>> AddMovie(AddMovieDto movieDto);
    }
}
