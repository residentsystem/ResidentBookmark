namespace ResidentBookmark.Services
{
    public class SortWebsiteService
    {
        public List<Website> ListOfWebsites { get; set; } = new List<Website>();

        public List<Label> ListOfLabels { get; set; } = new List<Label>();

        public List<Website> SortWebsite(List<Website> listofwebsites, string sortingoption) 
        {
            if (sortingoption == "date")
            {
                // Sort websites based on date.
                ListOfWebsites = listofwebsites.OrderByDescending(x => x.Date).ToList();
            }
            else if (sortingoption == "website")
            {
                // Sort websites by name.
                ListOfWebsites = listofwebsites.OrderBy(x => x.Name).ToList();
            }
            else
            {
                ListOfWebsites = listofwebsites;
            }
            return ListOfWebsites;
        }

        public List<Label> SortLabel(List<Label> listoflabels, string sortingoption)
        {
            // Sort labels by name.
            if (sortingoption == "label")
            {
                ListOfLabels = listoflabels.OrderBy(x => x.Name).ToList();
            }
            else 
            {
                ListOfLabels = listoflabels;
            }
            return ListOfLabels;
        }
    }
}