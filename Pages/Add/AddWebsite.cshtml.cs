using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResidentBookmark.Data;
using ResidentBookmark.Models;
using ResidentBookmark.Services;

namespace ResidentBookmark.Pages
{
    public class AddWebsiteModel : PageModel
    {
        public string PageTitle = "Resident Bookmark - Add Website";

        private readonly ResidentBookmarkContext _context;

        // Bind variable with properties of the Website model class.
        [BindProperty]
        public Website Website { get; set; }

        public string QueryString { get; set; }

        public int LabelId;

        [TempData]
        public string Message { get; set; }

        // Get the current date to be sent as part of the page form.
        public string Date = DateTime.Now.ToString("MM/dd/yyyy");

        public AddWebsiteModel (ResidentBookmarkContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // Get querystring from the GET HTTP request.
            QueryString = HttpContext.Request.Query["handler"].ToString();

            // Retrieve id of the label contained in the querystring.
            QueryService query = new QueryService();
            LabelId = await query.RetrieveLabelIdFromQueryString(_context, QueryString);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Websites.AddAsync(Website);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}