namespace ResidentBookmark.Pages
{
    public class AddLabelModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Add Label";

        private readonly ResidentBookmarkContext _context;

        // Bind variable with properties of the Label model class.
        [BindProperty]
        public Label Label { get; set; }

        [TempData]
        public string Message { get; set; }

        public AddLabelModel (ResidentBookmarkContext context)
        {
            _context = context;
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

            await _context.Labels.AddAsync(Label);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}