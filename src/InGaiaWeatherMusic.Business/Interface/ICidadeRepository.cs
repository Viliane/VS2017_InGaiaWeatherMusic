using System;
using System.Collections.Generic;
using System.Text;

namespace InGaiaWeatherMusic.Business.Interface
{
    public interface ICidadeRepository
    {
        void Adicionar(string cidade);

        List<string> ObterCidades();
    }
}
