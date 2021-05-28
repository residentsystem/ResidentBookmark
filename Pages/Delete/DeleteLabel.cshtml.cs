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

        private readonly ResidentBookmarkContext _context;

        // Bind variable with properties of the Label model class.
        [BindProperty]
        public Label Label { get; set; }

        [TempData]
        public string Message { get; set; }

        public DeleteLabelModel (ResidentBookmarkContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the first label related to specified id. Return an exception if the label is not found. 
            Label = await _context.Labels.FirstOrDefaultAsync(w => w.LabelId == id);

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
            Label = _context.Labels.Include(w => w.Websites).SingleOrDefault(l => l.LabelId == id);

            if (Label == null)
            {
                throw new DeleteInvalidOperationException();
            }
            else
            {
                _context.Remove(Label);
                await _context.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
        }
    }
}