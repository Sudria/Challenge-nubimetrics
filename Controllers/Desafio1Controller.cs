using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SudriaGonzalo_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Desafio1Controller : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public Desafio1Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet("/[controller]/paises/{pais}")]
        public async Task<IActionResult> ApiCall(String pais)
        {
            var httpClient = _httpClientFactory.CreateClient();
            pais = pais.ToUpper();
            string apiUrl = "https://api.mercadolibre.com/classified_locations/countries";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl + $"/{pais}");

                if (response.IsSuccessStatusCode)
                {
                    if (pais == "AR")
                    {
                    string content = await response.Content.ReadAsStringAsync();
                    return Ok(content);
                    }
                    else
                    {
                    return Unauthorized("error 401 unauthorized de http");
                    }
                }
                else
                {
                    return BadRequest("La solicitud a la API falló.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}