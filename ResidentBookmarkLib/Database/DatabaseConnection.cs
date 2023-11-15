namespace ResidentBookmarkLib.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        //private IConfiguration _configuration;

        private IWebHostEnvironment _environment;

        private MySqlConnection connection;
        
        public string Message { get; set; }

        public DatabaseConnection(IConfiguration configuration, IWebHostEnvironment environment)
        {
            //_configuration = configuration;
            _environment = environment;
        }

        // Retrieve connection string from environment variable

        public string GetConnectionString()
        {
            if (_environment.IsDevelopment()) {
                return Environment.GetEnvironmentVariable("CONNSTR_BOOKMARK_DEV");
            }
            else if (_environment.IsStaging()) {
                return Environment.GetEnvironmentVariable("CONNSTR_BOOKMARK_STG");
            }
            else {
                return Environment.GetEnvironmentVariable("CONNSTR_BOOKMARK_PRD");
            }
        }

        // Retrieve connection string from configuration file to be used based on current environment

        public string GetConnectionString(DatabaseEnvironment connectionstring)
        {
            if (_environment.IsDevelopment()) {
                return connectionstring.Development;
            }
            else if (_environment.IsStaging()) {
                return connectionstring.Staging;
            }
            else {
                return connectionstring.Production;
            }
        }

        public string MySqlConnectionStatus(string connectionstring)
        {
            try
            {
                connection = new MySqlConnection(connectionstring);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Message = $"MySql Error {ex.Number}: Cannot connect to the server. Contact your administrator.";
                        break;
                    case 1042:
                        Message = $"MySql Error {ex.Number}: Unable to connect to any of the specified MySQL hosts. Contact your administrator.";
                        break;
                    case 1045:
                        Message = $"MySql Error {ex.Number}: Invalid username/password, please try again.";
                        break;
                    default:
                        Message = $"MySql Error {ex.Number}: Unknown error when trying to connect to the server. Contact your administrator.";
                        break;
                }
            }
            return Message;
        }
    }
}