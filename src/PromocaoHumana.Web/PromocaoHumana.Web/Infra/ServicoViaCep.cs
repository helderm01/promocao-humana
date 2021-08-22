using System.Net.Http;
using Newtonsoft.Json;
using PromocaoHumana.Web.Domain.Exceptions;
using PromocaoHumana.Web.Models;

namespace PromocaoHumana.Web.Infra
{
    public class ServicoViaCep
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private HttpClient CriarHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient("ServicoViaCep");

            return httpClient;
        }

        public ServicoViaCep(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public CepViewModel ObterEndereco(string cep)
        {
            var httpCliente = CriarHttpClient();

            var resultado = httpCliente.GetAsync($"ws/{cep}/json").Result;

            var resposta = resultado.Content.ReadAsStringAsync().Result;

            if (!resultado.IsSuccessStatusCode)
                throw new ViaCepException(resposta);

            return JsonConvert.DeserializeObject<CepViewModel>(resposta);
        }
    }
}