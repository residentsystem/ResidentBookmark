namespace ResidentBookmark.Pages
{
    public class EditWebsiteModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Edit Website";

        private readonly BookmarkContext database;

        [BindProperty]
        public Website? Website { get; set; }

        public int LabelId { get; set; } 

        [TempData]
        public string? Message { get; set; }

        public EditWebsiteModel (BookmarkContext database)
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
                throw new EditArgumentNullException();
            }
            else
            {
                LabelId = Website.LabelId;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Website != null)
            {
                Website.Date = DateTime.Now;

                database.Websites.Attach(Website).State = EntityState.Modified;
                database.Websites.Update(Website);
            }

            // Retrieve the task result that represent the number of state entries written to the database. 
            // Expecting one entry to be saved, otherwise throw an exception.
            int savechangeid = await database.SaveChangesAsync();

            if (savechangeid != 1)
            {
                Exception innerException = new Exception();
                throw new DbUpdateConcurrencyException("Could not save. Verify that the item still exist and try again.", innerException);
            }
            
            return RedirectToPage("../Index");
        }
    }
}