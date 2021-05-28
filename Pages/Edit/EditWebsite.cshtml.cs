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
    public class EditWebsiteModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Edit Website";

        private readonly ResidentBookmarkContext _context;

        [BindProperty]
        public Website Website { get; set; }

        public int LabelId { get; set; } 

        [TempData]
        public string Message { get; set; }

        public EditWebsiteModel (ResidentBookmarkContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the first website related to specified id. Return an exception if the website is not found. 
            Website = await _context.Websites.FirstOrDefaultAsync(w => w.WebsiteId == id);

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
            Website.Date = DateTime.Now;

            _context.Websites.Attach(Website).State = EntityState.Modified;
            _context.Websites.Update(Website);

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