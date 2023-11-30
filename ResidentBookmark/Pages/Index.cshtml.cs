namespace ResidentBookmark.Pages
{
    public class IndexModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Home";

        private readonly BookmarkContext database;

        private readonly ISettingService _settingservice;

        public List<Label> ListOfAllLabels { get; set; } = new List<Label>();

        public List<Website> ListOfAllWebsites { get; set; } = new List<Website>();

        public string? SortOptionQueryString { get; set; }

        public Setting Settings 
        { 
            get {
                // Get list of options from default configuration file.
                return _settingservice.GetBookmarkSettings();
            } 
        }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ISettingService settingService, BookmarkContext database)
        {
            _logger = logger;
            _settingservice = settingService;
            this.database = database;
        }

        public async Task OnGet()
        {
            // Retrieve the list of all labels from the database.
            QueryService query = new QueryService();
            ListOfAllLabels = await query.RetrieveAllLabels(database);
            
            // Get list of all websites, including labels.
            ListOfAllWebsites = await query.RetrieveAllWebsitesIncludeLabel(database);

            // Sort all websites based on configuration option.
            SortWebsiteService sort = new SortWebsiteService();

            if (Settings != null)
            {
                string? sortoption = Settings.SortWebsite;
                if (sortoption != null)
                {
                    ListOfAllWebsites = sort.SortWebsite(ListOfAllWebsites, sortoption);
                }
            }

            // Get sorting option from querystring.
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["sort"]))
            {
                SortOptionQueryString = HttpContext.Request.Query["sort"].ToString();

                // Sort all websites if the querystring contain a value. 
                if (!String.IsNullOrEmpty(SortOptionQueryString))
                {
                    ListOfAllWebsites = sort.SortWebsite(ListOfAllWebsites, SortOptionQueryString);
                }

                // Sort all labels if the querystring contain a value. 
                ListOfAllLabels = sort.SortLabel(ListOfAllLabels, SortOptionQueryString);
            }
        }
    }
}
