using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SudriaGonzalo.Models;

namespace SudriaGonzalo_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Desafio2Controller : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public Desafio2Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet("/[controller]/busqueda/{termino}")]
        public async Task<IActionResult> ApiCall(String termino)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://api.mercadolibre.com/sites/MLA/";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + $"search?q={termino}");

                if (response.IsSuccessStatusCode && response!= null)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    
                    SearchModel result = JsonConvert.DeserializeObject<SearchModel>(content);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("La solicitud falló.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); 
            }
        }

    }
}