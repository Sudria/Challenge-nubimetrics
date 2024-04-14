using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SudriaGonzalo.Models;
using System.Collections.Generic;
using System.Text;

namespace SudriaGonzalo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Desafio4Controller : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Desafio4Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet("/[controller]")]
        public async Task<IActionResult> ApiCall()
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiCurrencies = "https://api.mercadolibre.com/currencies/";
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Data");
            string filePath1 = Path.Combine(folderPath, "Currencys.json");
            string filePath2 = Path.Combine(folderPath, "currency_conversions.csv");

            List<float> ratios = new List<float>();

            try
            {
                HttpResponseMessage responseApiCurrencies = await httpClient.GetAsync(apiCurrencies);
                if (responseApiCurrencies.IsSuccessStatusCode)
                {
                    string contentCurrencies = await responseApiCurrencies.Content.ReadAsStringAsync();
                    List<CurrencyModel> resultCurrencyModel = JsonConvert.DeserializeObject<List<CurrencyModel>>(contentCurrencies);
                    List<Task> tasks = new List<Task>();
                    foreach (CurrencyModel currency in resultCurrencyModel)
                    {
                        string apiCurrencyConversion = $"https://api.mercadolibre.com/currency_conversions/search?from={currency.Id}&to=USD";
                        Task<HttpResponseMessage> conversionTask = httpClient.GetAsync(apiCurrencyConversion);
                        tasks.Add(conversionTask.ContinueWith(async t =>
                        {
                            HttpResponseMessage responseCurrencyConversion = await t;

                            if (responseCurrencyConversion.IsSuccessStatusCode)
                            {
                                string contentCurrencyConversion = await responseCurrencyConversion.Content.ReadAsStringAsync();
                                CurrencyConverterModel currencyConverterModel = JsonConvert.DeserializeObject<CurrencyConverterModel>(contentCurrencyConversion);
                                currency.Todolar = currencyConverterModel;
                                ratios.Add(currencyConverterModel.Ratio);
                            }
                        }));
                    }
                    await Task.WhenAll(tasks);
                    string contentCurrenciesJson = JsonConvert.SerializeObject(resultCurrencyModel, Formatting.Indented);
                    string contentRatios = JsonConvert.SerializeObject(ratios, Formatting.Indented);
                    await WriteTextAsync(filePath2, contentRatios);
                    await WriteTextAsync(filePath1, contentCurrenciesJson);
                    return Ok();
                }
                else
                {
                    // La solicitud de la lista de monedas falló
                    return BadRequest("La solicitud de la lista de monedas falló.");
                }
            }
            catch (Exception ex)
            {
                // Captura de excepciones generales
                return StatusCode(500, $"Error: {ex.Message}");
            }



            static async Task WriteTextAsync(string filePath, string content)
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                using (StreamWriter writer = new StreamWriter(stream, new UTF8Encoding(false)))

                {

                    byte[] encodedText = System.Text.Encoding.Unicode.GetBytes(content);


                    await writer.WriteAsync(content);
                }
            }

        }
    }
}
