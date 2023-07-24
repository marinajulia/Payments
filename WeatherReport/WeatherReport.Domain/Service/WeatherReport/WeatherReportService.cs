using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Domain.Service.WeatherReport
{
    public class WeatherReportService : IWeatherReportService
    {
        private readonly IWeatherReportRepository _weatherReport;
        public WeatherReportService(IWeatherReportRepository weatherReport)
        {
            _weatherReport = weatherReport;
        }
        public async Task<WeatherReportEntity> GetWeatherReport(string cityId)
        {
            return await _weatherReport.GetWeatherReport(cityId);
        }
    }
}
