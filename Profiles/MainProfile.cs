using ApiPelicula.Models;
using ApiPelicula.ViewModels;
using AutoMapper;

namespace ApiPelicula.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<GeneroInput, Genero>();
            // primero fuente y luego destinop
            CreateMap<MovieInput, Movie>();
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dst => dst.Genero, opt => opt.MapFrom(m => m.Genero.Nombre))
                .ForMember(dst => dst.Duracion, opt => opt.MapFrom(m => m.Duracion / 60 + " Horas con " + m.Duracion % 60 + " Minutos "));
        }
    }
}
