using MyMoviesAPI.Dtos.MovieDtos;
using MyMoviesAPI.Models;

namespace MyMoviesAPI.Services
{
    public interface IMovieService
    {
        Task<ServiceResponse<List<GetMovieDto>>> GetMovies();
        Task<ServiceResponse<GetMovieDto>> GetMovieById(int id);
        Task<ServiceResponse<List<GetMovieDto>>> RemoveMovie(int id);
        Task<ServiceResponse<GetMovieDto>> AddMovie(AddMovieDto addMovieDto);
        Task<ServiceResponse<GetMovieDto>> UpdateMovie(UpdateMovieDto updateMovieDto);
        Task<ServiceResponse<List<GetMovieDto>>> FetchMovies();
    }
}
