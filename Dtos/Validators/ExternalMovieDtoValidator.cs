﻿using FluentValidation;
using MyMoviesAPI.Dtos.MovieDtos;

namespace MyMoviesAPI.Dtos.Validators
{
    public class ExternalMovieDtoValidator : AbstractValidator<ExternalMovieDto>
    {
        public ExternalMovieDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Director)
                .NotEmpty().WithMessage("Dodaj reżysera filmu.")
                .MaximumLength(40);

            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Dodaj rok produkcji filmu.")
                .InclusiveBetween(1900, 2200);

            RuleFor(x => x.Rate)
                .NotEmpty()
                .InclusiveBetween(0, 10);
        }
    }
}
