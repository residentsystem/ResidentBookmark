namespace ResidentBookmark.Pages
{
    public class LabelModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Labels";       
        
        private readonly ResidentBookmarkContext _context;

        public List<Website> ListOfWebsitesFromLabels { get; set; } = new List<Website>();

        public List<KeyValuePair<string, int>> ListOfLabelsWebsiteCount = new List<KeyValuePair<string, int>>();

        public string QueryString { get; set; }

        public string LabelDescription { get; set; }

        public string SortOptionQueryString { get; set; }

        public string LabelEmptyMessage { get; set; }
        
        public bool ShowLabelEmptyMessage => !string.IsNullOrEmpty(LabelEmptyMessage);

        public int NumberOfWebsites { get; set; }

        public LabelModel (ResidentBookmarkContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            // Get querystring from the GET HTTP request.
            QueryString = HttpContext.Request.Query["handler"].ToString();

            QueryService query = new QueryService();

            // Retrieve label description.
            LabelDescription = await query.RetrieveLabelDescriptionFromQueryString(_context, QueryString);

            // Retrieve and get count of all websites attached to a label.
            ListOfWebsitesFromLabels = await query.RetrieveWebsitesFromLabelName(_context, QueryString);
            NumberOfWebsites = ListOfWebsitesFromLabels.Count();

            // Store label and associated amount of websites as key/value pairs.
            ListOfLabelsWebsiteCount.Add(new KeyValuePair<string, int>(QueryString, NumberOfWebsites));

            if (NumberOfWebsites == 0)
            {
                LabelEmptyMessage = "This section is empty.";
            }
            else
            {
                // Get sorting option from querystring.
                if (!String.IsNullOrEmpty(HttpContext.Request.Query["sort"]))
                {
                    SortOptionQueryString = HttpContext.Request.Query["sort"].ToString();

                    // Sort all websites from labels only if the querystring contain a value.
                    SortWebsiteService sort = new SortWebsiteService();
                    ListOfWebsitesFromLabels = sort.SortWebsite(ListOfWebsitesFromLabels, SortOptionQueryString);
                }
            }
        }
    }
} 