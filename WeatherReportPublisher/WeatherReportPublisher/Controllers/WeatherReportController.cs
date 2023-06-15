using Microsoft.AspNetCore.Mvc;

namespace WeatherReport.Api.Controllers
{
    [ApiController]
    [Route("api/weatherreport")]
    public class WeatherReportController : Controller
    {
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
