namespace ResidentBookmark.Services
{
    public class QueryService
    {
        public async Task<List<Label>> RetrieveAllLabels(BookmarkContext database)
        {
            List<Label> labels = await database.Labels.ToListAsync();

            if (labels == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<List<Label>>(labels);
            }
        }

        public async Task<List<Website>> RetrieveAllWebsitesIncludeLabel(BookmarkContext database)
        {
            List<Website> websites = await database.Websites.Include(Website => Website.Label).ToListAsync();

            if (websites == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<List<Website>>(websites);
            }
        }

        public async Task<List<Website>> RetrieveWebsitesFromLabelName(BookmarkContext database, string querystring)
        {
            List<Website> websites = await database.Websites.Where(l => l.Label != null && l.Label.Name == querystring)
            .Include(l => l.Label)
            .ToListAsync();

            if (websites == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<List<Website>>(websites);
            }
        }

        public async Task<int> RetrieveLabelIdFromQueryString(BookmarkContext database, string querystring)
        {
            Label label = await database.Labels.Where(l => l.Name == querystring).SingleAsync();

            if (label == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<int>(label.LabelId);
            }
        }

        public async Task<string> RetrieveLabelDescriptionFromQueryString(BookmarkContext database, string querystring)
        {
            Label label = await database.Labels.Where(l => l.Name == querystring).SingleAsync();

            if (label.Description != null)
            {
                return await Task.FromResult<string>(label.Description);
            }
            else 
            {
                throw new FindInvalidOperationException();
            }
        }
    }
}