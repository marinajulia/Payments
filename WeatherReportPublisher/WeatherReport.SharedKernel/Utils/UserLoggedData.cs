namespace WeatherReport.SharedKernel.Utils
{
    public class UserLoggedData
    {
        private readonly List<DataToken> _data;
        public UserLoggedData()
        {
            _data = new List<DataToken>();
        }

        public void Add(int idUsuario)
        {
            _data.Add(new DataToken
            {
                Id_Usuario = idUsuario
            });
        }

        public DataToken GetData()
        {
            return _data.FirstOrDefault();
        }
    }

    public class DataToken
    {
        public int Id_Usuario { get; set; }
    }
}
