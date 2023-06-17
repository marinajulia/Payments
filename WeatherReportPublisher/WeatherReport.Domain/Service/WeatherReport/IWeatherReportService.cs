
using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Domain.Service.WeatherReport
{
    public interface IWeatherReportService
    {
        void PostWeather(WeatherReportEntity weatherReport); //tem que mandar as credenciais do usuario tbm
    }
}
