using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResidentBookmark.Data;
using ResidentBookmark.Models;
using ResidentBookmark.Services;

namespace ResidentBookmark.Pages
{
    public class DeleteLabelModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Delete Label";

        private readonly BookmarkContext database;

        // Bind variable with properties of the Label model class.
        [BindProperty]
        public Label? Label { get; set; }

        [TempData]
        public string? Message { get; set; }

        public DeleteLabelModel (BookmarkContext database)
        {
            this.database = database;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the first label related to specified id. Return an exception if the label is not found. 
            Label = await database.Labels.FirstOrDefaultAsync(w => w.LabelId == id);

            if (Label == null)
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

            // Retrieve a single label to be removed related to specified id, including all related websites. 
            // Return an exception if the label is not found. 
            Label = database.Labels.Include(w => w.Websites).SingleOrDefault(l => l.LabelId == id);

            if (Label == null)
            {
                throw new DeleteInvalidOperationException();
            }
            else
            {
                database.Remove(Label);
                await database.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
        }
    }
}