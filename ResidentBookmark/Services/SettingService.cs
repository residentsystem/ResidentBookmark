namespace ResidentBookmark.Services
{
    public class SettingService : ISettingService
    {
        private readonly IConfiguration _configuration;

        public SettingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Throw an error if a setting is missing or misconfigured.

        public Setting GetBookmarkSettings()
        {
            // Bind the content of default configuration file "bookmarkSettings.json" to an instance of BookmarkSettings. 
            Setting? settings = _configuration.GetSection("BookmarkSettings").Get<Setting>();

            /* Test Title */

            if (!(settings?.Title is string))
            {
                throw new TitleNullReferenceException();
            }

            if (string.IsNullOrEmpty(settings?.Title))
            {
                if (settings != null)
                settings.Title = "No Name";
            }

            /* Test ShowLimit */

            if (!(settings?.ShowLimit is int))
            {
                throw new ShowLimitNullReferenceException();
            }

            if (string.IsNullOrEmpty(settings.ShowLimit.ToString()))
            {
                settings.ShowLimit = 1;
            }

            if (settings.ShowLimit < 1)
            {
                settings.ShowLimit = 1;
            }
            else if (settings.ShowLimit > 20)
            {
                settings.ShowLimit = 20;
            }

            /* Test SortWebsite */

            if (!TestSortWebsiteSetting(settings.SortWebsite))
            {
                //throw new SortWebsiteNullReferenceException();
                settings.SortWebsite = "date";
            }

            return settings;
        }

        public bool TestSortWebsiteSetting(string? sortwebsite)
        {
            if (string.IsNullOrEmpty(sortwebsite))
            {
                return false;
            }

            else if (sortwebsite.Equals("date"))
            {
                return true;
            }
            else if (sortwebsite.Equals("website"))
            {
                return true;
            }
            else if (sortwebsite.Equals("label"))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }                    
    }
}