using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResidentBookmark.Data;
using ResidentBookmark.Models;
using ResidentBookmark.Services;

namespace ResidentBookmark.Pages
{
    public class EditLabelModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Edit Label";

        private readonly ResidentBookmarkContext _context;

        [BindProperty]
        public Label Label { get; set; }

        public int LabelId { get; set; } 

        [TempData]
        public string Message { get; set; }

        public EditLabelModel (ResidentBookmarkContext context)
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
            Label = await _context.Labels.FirstOrDefaultAsync(l => l.LabelId == id);

            if (Label == null)
            {
                throw new EditNullReferenceException();
            }
            else 
            {
                LabelId = Label.LabelId;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Labels.Attach(Label).State = EntityState.Modified;
            _context.Labels.Update(Label);

            // Retrieve the task result that represent the number of state entries written to the database. 
            // Expecting one entry to be saved, otherwise throw an exception.
            int savechangeid = await _context.SaveChangesAsync();

            if (savechangeid != 1)
            {
                Exception innerException = new Exception();
                throw new DbUpdateConcurrencyException("Could not save. Verify that the item still exist and try again.", innerException);
            }
            
            return RedirectToPage("../Index");
        }
    }
}