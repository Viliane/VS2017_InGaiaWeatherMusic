using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InGaiaWeather.Model;
using InGaiaWeather.Model.Spotify.Categoria;
using InGaiaWeather.Model.Spotify.ItensPlayList;
using InGaiaWeatherMusic.API.Util;
using InGaiaWeatherMusic.API.ViewModel;
using InGaiaWeatherMusic.Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InGaiaWeatherMusic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEstatisticaService _estatisticaService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _cidadeRepository;

        public ValuesController(IConfiguration configuration, IUsuarioRepository usuarioRepository, IMapper mapper, IEstatisticaService estatisticaService, ICidadeRepository cidadeRepository)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _mapper = mapper;
            _estatisticaService = estatisticaService;
            _cidadeRepository = cidadeRepository;
        }

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Login([FromBody] UsuarioViewModel usuario)
        {
            var usuarioRepository = _mapper.Map<UsuarioViewModel>(_usuarioRepository.ObterUsuario(usuario.Nome, usuario.Senha));

            if (usuarioRepository == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = FuncoesUteis.GenerateToken(usuarioRepository, _configuration["Secret"]);

            return new
            {
                token = token
            };
        }

        [HttpGet("{cidade}")]
        [Authorize()]
        public ActionResult<List<MusicaViewModel>> Get(string cidade)
        {
            string urlWeather = _configuration["UrlWeather"].Replace("{cidade}", cidade);
            Root root = FuncoesUteis.GetRequestRestAPI<Root>(urlWeather);


            string token = FuncoesUteis.GetAccessToken(_configuration["UrlSpotify"], _configuration["ClienId"], _configuration["SecretId"]);
            string urlCategoria = string.Empty;

            if (root.main.temp > 25)
            {
                urlCategoria = _configuration["UrlCategoria"].Replace("{categoria}", "pop");
            }
            else if (root.main.temp > 10 && root.main.temp < 25)
            {
                urlCategoria = _configuration["UrlCategoria"].Replace("{categoria}", "rock");
            }
            else
            {
                urlCategoria = _configuration["UrlCategoria"].Replace("{categoria}", "focus");
            }

            Categoria categoria = FuncoesUteis.GetRequestRespApiUseToken<Categoria>(urlCategoria, token);

            string urlItemPlayList = _configuration["UrlItemPlaylist"].Replace("{id}", categoria.playlists.items[0].id);

            ItensPlayList playlist = FuncoesUteis.GetRequestRespApiUseToken<ItensPlayList>(urlItemPlayList, token);

            List<MusicaViewModel> musicas = new List<MusicaViewModel>();

            foreach (var item in playlist.items)
            {
                MusicaViewModel musica = new MusicaViewModel();
                musica.NomeMusica = item.track.name;
                musica.NomeArtista = item.track.artists[0].name;

                musicas.Add(musica);
            }

            _cidadeRepository.Adicionar(cidade);

            return musicas;
        }

        [HttpGet("estatistica-cidades-consultadas")]
        public ActionResult<List<EstatisticaViewModel>> ObterEstatisticasCidadesConsultadas()
        {
            var estatisticas = _mapper.Map<List<EstatisticaViewModel>>(_estatisticaService.ObterDadosEstatistico());

            return estatisticas;
        }
    }
}
