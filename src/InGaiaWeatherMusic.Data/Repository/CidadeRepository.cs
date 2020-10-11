using InGaiaWeatherMusic.Business.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InGaiaWeatherMusic.Data.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        public void Adicionar(string cidade)
        {
            string path = Directory.GetCurrentDirectory().Replace("InGaiaWeatherMusic.API", "InGaiaWeatherMusic.Data\\Repository\\CidadesConsultadas.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(cidade);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(cidade);
                }
            }
        }

        public List<string> ObterCidades()
        {
            string path = Directory.GetCurrentDirectory().Replace("InGaiaWeatherMusic.API", "InGaiaWeatherMusic.Data\\Repository\\CidadesConsultadas.txt"); 
            List<string> listaCidadesConsultadas = new List<string>();

            using (StreamReader sr = File.OpenText(path))
            {
                string linha = string.Empty;
                while ((linha = sr.ReadLine()) != null)
                {
                    listaCidadesConsultadas.Add(linha);
                }
            }

            return listaCidadesConsultadas;
        }
    }
}