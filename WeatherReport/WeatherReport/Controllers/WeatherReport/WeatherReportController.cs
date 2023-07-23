using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherReport.Domain.Service.WeatherReport;
using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Api.Controllers.WeatherReport
{
    [ApiController]
    [Route("api/weatherreport")]
    public class WeatherReportController : Controller
    {
        private readonly IWeatherReportService _weatherReportService;
        public WeatherReportController(IWeatherReportService weatherReportService)
        {
            _weatherReportService = weatherReportService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string cityId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityId}");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var objeto = JsonConvert.DeserializeObject<WeatherReportEntity>(responseBody);

                    //if (objeto != null)
                    //    _weatherReportService.PostWeather(objeto);

                    return Ok(responseBody);
                }
                catch (HttpRequestException)
                {
                    return BadRequest();
                }
            }
        }
    }
}
//4750