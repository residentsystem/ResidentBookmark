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
            // Bind the content of default configuration file "appsettings.json" to an instance of BookmarkSettings. 
            Setting settings = _configuration.GetSection("BookmarkSettings").Get<Setting>();

            if (!TestTitleSetting(settings.Title))
            {
                //throw new TitleNullReferenceException();
                settings.Title = "No Title";
                return settings;
            }
            else if (!TestShowLimitSetting(settings.ShowLimit))
            {
                throw new ShowLimitNullReferenceException();
            }
            else if (!TestSortWebsiteSetting(settings.SortWebsite))
            {
                throw new SortWebsiteNullReferenceException();
            }
            else
            {
                return settings;
            }
        }

        public bool TestTitleSetting(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TestShowLimitSetting(int showlimit)
        {
            return showlimit.Equals(0) ? false : true;
        }

        public bool TestSortWebsiteSetting(Dictionary<string, string> sortwebsite)
        {

            if (sortwebsite.Count == 0)
            {
                return false;
            }
            else if (sortwebsite["date"].Equals("date"))
            {
                return true;
            }
            else if (sortwebsite["website"].Equals("website"))
            {
                return true;
            }
            else if (sortwebsite["label"].Equals("label"))
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