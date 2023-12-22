namespace ECom.Services.Forecasts.Data
{
    public class DataAccess
    {
        private static DataAccess _ins;
        public static DataAccess Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataAccess();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public ForecastDbContext DB { get; set; }
        private DataAccess()
        {
            DB = new ForecastDbContext();
        }
    }
}
