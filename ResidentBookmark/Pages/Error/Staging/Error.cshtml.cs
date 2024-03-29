namespace ResidentBookmark.Pages.Error.Staging
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Error";

        private IConfiguration _configuration;

        private IDatabaseConnection _database;

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string? Referrer { get; set; }

        public bool ShowReferrer => !string.IsNullOrEmpty(Referrer); 

        public string? ExceptionMessage { get; set; }

        public bool ShowExceptionMessage => !string.IsNullOrEmpty(ExceptionMessage);

        public string? MySqlExeptionMessage { get; set; }
        
        public bool ShowMySqlExeptionMessage => !string.IsNullOrEmpty(MySqlExeptionMessage);

        public ErrorModel(IConfiguration configuration, IDatabaseConnection database)
        {
            _configuration = configuration;
            _database = database;
        }

        public void OnGet()
        {
            // Bind the content of default configuration file "appsettings.json" to an instance of DatabaseSettings. 
            //DatabaseEnvironment connectionstring = _configuration.GetSection("ConnectionString").Get<DatabaseEnvironment>();

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            MySqlExeptionMessage = _database.MySqlConnectionStatus(_database.GetConnectionString());

            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is FindArgumentNullException)
            {
                ExceptionMessage = "Could not FIND this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is FindInvalidOperationException)
            {
                ExceptionMessage = "Could not FIND this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is DeleteArgumentNullException)
            {
                ExceptionMessage = "Could not DELETE this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is EditArgumentNullException)
            {
                ExceptionMessage = "Could not EDIT this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is EditNullReferenceException)
            {
                ExceptionMessage = "Could not EDIT this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is SettingFileNullReferenceException)
            {
                ExceptionMessage = "Configuration file was not found!!";
            }

            if (exceptionHandlerPathFeature?.Error is TitleNullReferenceException)
            {
                ExceptionMessage = "Title setting set as null. Verify the settings and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is ShowLimitNullReferenceException)
            {
                ExceptionMessage = "ShowLimit setting set as null or value set to 0. Verify the settings and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is SortWebsiteNullReferenceException)
            {
                ExceptionMessage = "SortWebsite setting set as null or contain a typo. Verify the settings and try again.";
            }
        }

        public void OnPost()
        {
            // Bind the content of default configuration file "appsettings.json" to an instance of DatabaseSettings. 
            //DatabaseEnvironment connectionstring = _configuration.GetSection("ConnectionString").Get<DatabaseEnvironment>();

            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            MySqlExeptionMessage = _database.MySqlConnectionStatus(_database.GetConnectionString());

            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>(); 

            if (exceptionHandlerPathFeature?.Error is DeleteArgumentNullException)
            {
                ExceptionMessage = "Could not DELETE this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is DeleteInvalidOperationException)
            {
                ExceptionMessage = "Could not DELETE this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is DbUpdateConcurrencyException)
            {
                ExceptionMessage = "Could not UPDATE this item. Verify that the item still exist and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is SettingFileNullReferenceException)
            {
                ExceptionMessage = "Configuration file was not found!!";
            }

            if (exceptionHandlerPathFeature?.Error is TitleNullReferenceException)
            {
                ExceptionMessage = "Title setting set as null. Verify the settings and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is ShowLimitNullReferenceException)
            {
                ExceptionMessage = "ShowLimit setting set as null or value set to 0. Verify the settings and try again.";
            }

            if (exceptionHandlerPathFeature?.Error is SortWebsiteNullReferenceException)
            {
                ExceptionMessage = "SortWebsite setting set as null or contain a typo. Verify the settings and try again.";
            }
        }
    }
}