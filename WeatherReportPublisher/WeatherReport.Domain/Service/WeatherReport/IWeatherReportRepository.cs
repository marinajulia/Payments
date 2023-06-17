using WeatherReport.Domain.Service.WeatherReport.Entities;

namespace WeatherReport.Domain.Service.WeatherReport
{
    public interface IWeatherReportRepository
    {
        void PostWeather(WeatherReportEntity weatherReport); //tem que mandar as credenciais do usuario tbm
    }
}
