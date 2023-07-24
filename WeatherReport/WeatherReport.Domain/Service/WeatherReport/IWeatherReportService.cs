using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Domain.Service.WeatherReport
{
    public interface IWeatherReportService
    {
        Task<WeatherReportEntity> GetWeatherReport(string cityId);
    }
}
