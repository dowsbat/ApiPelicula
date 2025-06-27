using ApiPelicula.Models;
using FluentValidation;

namespace ApiPelicula.Validators
{
    public class MovieValidator : AbstractValidator<MovieInput>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Titulo)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(m => m.Director)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);
            RuleFor(m => m.Sinopsis)
                .NotNull()
                .NotEmpty()
                .MinimumLength(25)
                .MaximumLength(500);
            RuleFor(m => m.Rating)
                .NotEmpty()
                .NotNull()
                .LessThan(0)
                .GreaterThan(10);
            RuleFor(m => m.Estreno)
                .NotEmpty()
                .NotNull()
                .LessThan(1800)
                .GreaterThan(DateTime.Today.Year);
            RuleFor(m => m.GeneroId)
                .NotNull();
        }
    }
}
