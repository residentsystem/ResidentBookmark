using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResidentBookmark.Configurations;
using ResidentBookmark.Data;
using ResidentBookmark.Interfaces;
using ResidentBookmark.Models;
using ResidentBookmark.Services;

namespace ResidentBookmark.Pages
{
    public class IndexModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Home";

        private readonly ResidentBookmarkContext _context;

        private readonly IBookmarkService _bookmark;

        public List<Label> ListOfAllLabels { get; set; } = new List<Label>();

        public List<Website> ListOfAllWebsites { get; set; } = new List<Website>();

        public string SortOptionQueryString { get; set; }

        public BookmarkSettings BookmarkSettings { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ResidentBookmarkContext context, IBookmarkService bookmark)
        {
            _logger = logger;
            _context = context;
            _bookmark = bookmark;
        }

        public async Task OnGet()
        {
            // Get list of options from default configuration file.
            BookmarkSettings = _bookmark.GetBookmarkSettings();

            // Retrieve the list of all labels from the database.
            QueryService query = new QueryService();
            ListOfAllLabels = await query.RetrieveAllLabels(_context);
            
            // Get list of all websites, including labels.
            ListOfAllWebsites = await query.RetrieveAllWebsitesIncludeLabel(_context);

            // Sort all websites based on configuration option.
            SortWebsiteService sort = new SortWebsiteService();
            ListOfAllWebsites = sort.SortWebsite(ListOfAllWebsites, BookmarkSettings.SortWebsite);

            // Get sorting option from querystring.
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["sort"]))
            {
                SortOptionQueryString = HttpContext.Request.Query["sort"].ToString();

                // Sort all websites if the querystring contain a value. 
                ListOfAllWebsites = sort.SortWebsite(ListOfAllWebsites, SortOptionQueryString);

                // Sort all labels if the querystring contain a value. 
                ListOfAllLabels = sort.SortLabel(ListOfAllLabels, SortOptionQueryString);
            }
        }
    }
}
