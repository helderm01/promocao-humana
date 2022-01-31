using System;
using System.Net.Http;
using Newtonsoft.Json;
using PromocaoHumana.Web.Domain.Exceptions;
using PromocaoHumana.Web.Models;

namespace PromocaoHumana.Web.Infra
{
    public class ServicoViaCep
    {
        public CepViewModel ObterEndereco(string cep)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://viacep.com.br/")
            };
            
            var resultado = httpClient.GetAsync($"ws/{cep}/json").Result;

            var resposta = resultado.Content.ReadAsStringAsync().Result;

            if (!resultado.IsSuccessStatusCode)
                throw new ViaCepException(resposta);

            return JsonConvert.DeserializeObject<CepViewModel>(resposta);
        }
    }
}