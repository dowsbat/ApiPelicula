using ApiPelicula.Models;
using ApiPelicula.ViewModels;
using AutoMapper;

namespace ApiPelicula.Profiles
{
    public class MainProfile :Profile
    {
        public MainProfile()
        {
            CreateMap<GeneroInput, Genero>();
            // primero fuente y luego destinop
            CreateMap<MovieInput, Movie>();
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(m => m.Genero.Nombre));
        }
    }
}
