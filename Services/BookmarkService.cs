namespace ResidentBookmark.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IConfiguration _configuration;

        public BookmarkService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BookmarkSettings GetBookmarkSettings()
        {
            // Bind the content of default configuration file "appsettings.json" to an instance of BookmarkSettings. 
            BookmarkSettings settings = _configuration.GetSection("BookmarkSettings").Get<BookmarkSettings>();

            // Throw an exception when an option is null or empty.
            if (settings == null)
            {
                throw new ConfigurationNullReferenceException();
            }
            else if (string.IsNullOrEmpty(settings.Title))
            {
                throw new ConfigurationNullReferenceException();
            }
            else if (string.IsNullOrEmpty(settings.ShowLimit) || settings.ShowLimit == "0")
            {
                throw new ConfigurationNullReferenceException();
            }
            else if (string.IsNullOrEmpty(settings.SortWebsite))
            {
                throw new ConfigurationNullReferenceException();
            }
            else
            {
                return settings;
            }
        }                    
    }
}