using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Domain.Service.WeatherReport
{
    public class WeatherReportService : IWeatherReportService
    {
        private readonly IWeatherReportRepository _weatherReportRepository;
        public WeatherReportService(IWeatherReportRepository weatherReportRepository)
        {
            _weatherReportRepository = weatherReportRepository;
        }

        public void PostWeather(WeatherReportEntity weatherReport)
        {
            _weatherReportRepository.PostWeather(weatherReport);
        }
    }
}
