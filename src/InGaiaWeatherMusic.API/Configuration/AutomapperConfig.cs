using AutoMapper;
using InGaiaWeatherMusic.API.ViewModel;
using InGaiaWeatherMusic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGaiaWeatherMusic.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Estatistica, EstatisticaViewModel>().ReverseMap();
        }
    }
}
