namespace ResidentBookmark.Pages
{
    public class AddWebsiteModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Add Website";

        private readonly BookmarkContext database;

        // Bind variable with properties of the Website model class.
        [BindProperty]
        public Website? Website { get; set; }

        public string? QueryString { get; set; }

        public int LabelId;

        [TempData]
        public string? Message { get; set; }

        // Get the current date to be sent as part of the page form.
        public string Date = DateTime.Now.ToString("MM/dd/yyyy");

        public AddWebsiteModel (BookmarkContext database)
        {
            this.database = database;
        }

        public async Task OnGetAsync()
        {
            // Get querystring from the GET HTTP request.
            QueryString = HttpContext.Request.Query["handler"].ToString();

            // Retrieve id of the label contained in the querystring.
            QueryService query = new QueryService();
            LabelId = await query.RetrieveLabelIdFromQueryString(database, QueryString);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Website != null)
            {
                await database.Websites.AddAsync(Website);
                await database.SaveChangesAsync();
            }

            return RedirectToPage("../Index");
        }
    }
}