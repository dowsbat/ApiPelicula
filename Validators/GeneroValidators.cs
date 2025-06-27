
using ApiPelicula.Models;
using FluentValidation;

namespace ApiPelicula.Validators

{
    public class GeneroValidators : AbstractValidator<GeneroInput>
    {
        public GeneroValidators()
        {
            RuleFor(g => g.Nombre)
                .NotEmpty()
                .MaximumLength(50)
                .NotNull()
                .MinimumLength(5);
            
        }
    }
}
