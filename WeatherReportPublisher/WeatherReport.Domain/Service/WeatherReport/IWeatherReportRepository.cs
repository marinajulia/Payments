using User.Domain.Service.WeatherReport.Entities;

namespace User.Domain.Service.WeatherReport
{
    public interface IWeatherReportRepository
    {
        void PostWeather(WeatherReportEntity weatherReport); //tem que mandar as credenciais do usuario tbm
    }
}
