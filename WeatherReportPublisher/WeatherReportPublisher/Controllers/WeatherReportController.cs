using Microsoft.AspNetCore.Mvc;
using WeatherReport.Domain.Service.WeatherReport;
using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Api.Controllers
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
                    //var teste = new WeatherReportEntity()
                    //{
                    //    Id = 1
                    //};
                    //_weatherReportService.PostWeather(teste);


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
