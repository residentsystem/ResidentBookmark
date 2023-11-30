namespace ResidentBookmark.Pages
{
    public class DeleteWebsiteModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Delete Website";

        private readonly BookmarkContext database;

        // Bind variable with properties of the Website model class.
        [BindProperty]
        public Website? Website { get; set; }

        [TempData]
        public string? Message { get; set; }

        public DeleteWebsiteModel (BookmarkContext database)
        {
            this.database = database;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the first website related to specified id. Return an exception if the website is not found.
            Website = await database.Websites.FirstOrDefaultAsync(w => w.WebsiteId == id);

            if (Website == null)
            {
                throw new DeleteArgumentNullException();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve a single website to be removed related to specified id. 
            // Return an exception if the website is not found.
            Website = await database.Websites.FindAsync(id);

            if (Website == null)
            {
                throw new DeleteArgumentNullException();
            }
            else
            {
                database.Websites.Attach(Website);
                database.Websites.Remove(Website);
                await database.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
        }
    }
}