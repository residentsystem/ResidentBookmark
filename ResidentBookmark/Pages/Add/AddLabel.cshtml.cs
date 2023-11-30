namespace ResidentBookmark.Pages
{
    public class AddLabelModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Add Label";

        private readonly BookmarkContext database;

        // Bind variable with properties of the Label model class.
        [BindProperty]
        public Label? Label { get; set; }

        [TempData]
        public string? Message { get; set; }

        public AddLabelModel (BookmarkContext database)
        {
            this.database = database;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Label != null)
            {
                await database.Labels.AddAsync(Label);
            }

            await database.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}