using MyMoviesAPI.Dtos.MovieDtos;
using MyMoviesAPI.Models;

namespace MyMoviesAPI.Services
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<GetMovieDto>>> GetMovies();
        Task<ServiceResponse<GetMovieDto>> GetMovieById(int id);
        Task<ServiceResponse<GetMovieDto>> AddMovie(AddMovieDto movieDto);
        Task<ServiceResponse<List<GetMovieDto>>> FetchMovies();
    }
}
