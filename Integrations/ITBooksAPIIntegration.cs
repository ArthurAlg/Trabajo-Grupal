using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Trabajo_Grupal.DTO;

namespace Trabajo_Grupal.Integrations
{
    public class ITBooksAPIIntegration
    {
        private readonly ILogger<ITBooksAPIIntegration> _logger;
        private const string API_URL="https://api.itbook.store/1.0/search/mongo";
        private readonly HttpClient httpClient;

        public ITBooksAPIIntegration(ILogger<ITBooksAPIIntegration> logger){
            _logger = logger;
            httpClient = new HttpClient();
        }

        public async Task<List<SearchResultDTO>> GetBooks()
        {
            string requestUrl = $"{API_URL}";

            List<SearchResultDTO> searchResult = new List<SearchResultDTO>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    searchResult = await response.Content.ReadFromJsonAsync<List<SearchResultDTO>>() ?? new List<SearchResultDTO>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"Error al llamar a la API: {ex.Message}");
            }
            return searchResult;
        }
    }
}