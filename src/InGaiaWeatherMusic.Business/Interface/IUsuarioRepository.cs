using InGaiaWeatherMusic.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InGaiaWeatherMusic.Business.Interface
{
    public interface IUsuarioRepository
    {
        Usuario ObterUsuario(string nome, string senha);
    }
}
