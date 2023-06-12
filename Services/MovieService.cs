using AutoMapper;
using Azure;
using Flurl.Http;
using Microsoft.EntityFrameworkCore;
using MyMoviesAPI.Data;
using MyMoviesAPI.Dtos.MovieDtos;
using MyMoviesAPI.Models;
using Newtonsoft.Json;

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

        public async Task<ServiceResponse<List<GetMovieDto>>> GetMovies()
        {
            var response = new ServiceResponse<List<GetMovieDto>>();

            var movies = await _context.Movies.ToListAsync();

            response.Data = movies.Select(_mapper.Map<GetMovieDto>).ToList();
            response.Message = "Lista filmów w bazie danych";

            return response;
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

        
        public async Task<ServiceResponse<List<GetMovieDto>>> FetchMovies()
        {
            var response = new ServiceResponse<List<GetMovieDto>>();


            try
            {
                string apiUrl = "https://filmy.programdemo.pl/MyMovies";
                var result = await apiUrl.GetAsync().ReceiveString();

                if (result == null)
                    throw new Exception("Brak filmów na liście.");

                List<ExternalMovieDto> externalMovies = JsonConvert.DeserializeObject<List<ExternalMovieDto>>(result)!;

                foreach (var externalMovie in externalMovies)
                { 
                    var movie = _context.Movies.Any(x => x.ExternalId == externalMovie.Id);

                    if (movie)
                        continue;

                    var newMovie = new Movie()
                    {
                        Title = externalMovie.Title,
                        Director = externalMovie.Director,
                        Rate = externalMovie.Rate,
                        ExternalId = externalMovie.Id
                    };

                    _context.Movies.Add(newMovie);
                }

                await _context.SaveChangesAsync();

            }
            catch (FlurlHttpException ex)
            {
                response.Success = false;
                response.Message = "Błąd w połączeniu z API:\n" + ex.Message;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Błąd:\n" + ex.Message;
            }

            var movies = await _context.Movies.ToListAsync();

            response.Data = movies.Select(_mapper.Map<GetMovieDto>).ToList();
            response.Message = "Lista filmów po aktualizacji z zewnątrzną bazą danych";

            return response;
        }
        
    }
}
