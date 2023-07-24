using Newtonsoft.Json;
using WeatherReport.Domain.Service.WeatherReport;
using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Infra.Repositories.WeatherReport
{
    public class WeatherReportRepository : IWeatherReportRepository
    {
        public async Task<WeatherReportEntity> GetWeatherReport(string cityId)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://brasilapi.com.br/api/cptec/v1/clima/previsao/{cityId}");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherReportEntity? weatherReport = JsonConvert.DeserializeObject<WeatherReportEntity>(responseBody);

                return weatherReport;
            }
        }
    }
}
