namespace ResidentBookmark.Models
{
    public class Setting
    {
        public string Title { get; set; }

        public int ShowLimit { get; set; }

        public Dictionary<string, string> SortWebsite { get; set; } = new Dictionary<string, string>
        {
            { "date", "date" },
            { "website", "website" },
            { "label", "label" }
        };
    }
}