using InGaiaWeatherMusic.Business.Interface;
using InGaiaWeatherMusic.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InGaiaWeatherMusic.Business.Services
{
    public class EstatisticaService : IEstatisticaService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public EstatisticaService(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public List<Estatistica> ObterDadosEstatistico()
        {
            List<Estatistica> estatisticas = new List<Estatistica>();
            var cidadesConsultadas = _cidadeRepository.ObterCidades();

            for (int i = 0; i < cidadesConsultadas.Count; i++)
            {
                var existeNaLista = estatisticas.Exists(x => x.Cidade.ToUpper() == cidadesConsultadas[i].ToUpper());

                if (!existeNaLista)
                {
                    estatisticas.Add(new Estatistica { Cidade = cidadesConsultadas[i], quantVisualizada = 1 });
                }
                else
                {
                    var index = estatisticas.FindIndex(x => x.Cidade.ToUpper() == cidadesConsultadas[i].ToUpper());
                    estatisticas[index].quantVisualizada++;
                }
            }

            int Total = estatisticas.Sum(x => x.quantVisualizada);
            foreach (var item in estatisticas)
            {
                var percetual = (item.quantVisualizada * 100) / Total;
                item.Percentual = percetual.ToString() + "%";
            }

            return estatisticas;
        }
    }
}
