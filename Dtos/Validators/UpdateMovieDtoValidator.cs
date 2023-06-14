using FluentValidation;
using MyMoviesAPI.Dtos.MovieDtos;

namespace MyMoviesAPI.Dtos.Validators
{
    public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
    {
        public UpdateMovieDtoValidator()
        {
            RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200).WithMessage("Tytuł nie może być dłuższy niż 200 znaków");

            RuleFor(x => x.Director)
                .NotEmpty().WithMessage("Dodaj reżysera filmu.")
                .MaximumLength(40).WithMessage("Nazwisko reżysera na pewno nie jest takie długie :)");

            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Dodaj rok produkcji filmu.")
                .InclusiveBetween(1900, 2200).WithMessage("Rok nie może być większy niż 2200 i mniejszy niż 1900.");

            RuleFor(x => x.Rate)
                .NotEmpty().WithMessage("Dodaj ocenę filmu. Od 0-10, liczba musi byc całkowita.")
                .InclusiveBetween(0, 10).WithMessage("Ocena musi być w przedziale od 0 do 10.");
        }
    }
}
