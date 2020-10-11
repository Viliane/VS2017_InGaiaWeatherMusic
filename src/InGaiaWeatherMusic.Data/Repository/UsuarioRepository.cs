using InGaiaWeatherMusic.Business.Interface;
using InGaiaWeatherMusic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InGaiaWeatherMusic.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario ObterUsuario(string nome, string senha)
        {
            var usuarios = new List<Usuario>();

            usuarios.Add(new Usuario { Nome = "teste", Senha = "teste", Role = "manager" });
            usuarios.Add(new Usuario { Nome = "teste1", Senha = "teste1", Role = "employee" });
            return usuarios.Where(x => x.Nome.ToLower() == nome.ToLower() && x.Senha == senha).FirstOrDefault();
        }
    }
}
