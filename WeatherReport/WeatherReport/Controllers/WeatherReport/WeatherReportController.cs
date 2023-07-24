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
                    var weatherReport = await _weatherReportService.GetWeatherReport(cityId);
                    return Ok(weatherReport);
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