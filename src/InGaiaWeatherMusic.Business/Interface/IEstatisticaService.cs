using InGaiaWeatherMusic.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InGaiaWeatherMusic.Business.Interface
{
    public interface IEstatisticaService
    {
        List<Estatistica> ObterDadosEstatistico();
    }
}
