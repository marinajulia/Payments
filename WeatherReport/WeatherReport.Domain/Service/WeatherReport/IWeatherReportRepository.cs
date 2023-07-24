using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Domain.Service.WeatherReport
{
    public interface IWeatherReportRepository
    {
        Task<WeatherReportEntity> GetWeatherReport(string cityId);
    }
}
