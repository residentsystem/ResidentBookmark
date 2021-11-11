namespace ResidentBookmark.Services
{
    public class QueryService
    {
        public async Task<List<Label>> RetrieveAllLabels(ResidentBookmarkContext context)
        {
            List<Label> labels = await context.Labels.ToListAsync();

            if (labels == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<List<Label>>(labels);
            }
        }

        public async Task<List<Website>> RetrieveAllWebsitesIncludeLabel(ResidentBookmarkContext context)
        {
            List<Website> websites = await context.Websites.Include(Website => Website.Label).ToListAsync();

            if (websites == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<List<Website>>(websites);
            }
        }

        public async Task<List<Website>> RetrieveWebsitesFromLabelName(ResidentBookmarkContext context, string querystring)
        {
            List<Website> websites = await context.Websites.Where(l => l.Label.Name == querystring)
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

        public async Task<int> RetrieveLabelIdFromQueryString(ResidentBookmarkContext context, string querystring)
        {
            Label label = await context.Labels.Where(l => l.Name == querystring).SingleAsync();

            if (label == null)
            {
                throw new FindArgumentNullException();
            }
            else
            {
                return await Task.FromResult<int>(label.LabelId);
            }
        }

        public async Task<string> RetrieveLabelDescriptionFromQueryString(ResidentBookmarkContext context, string querystring)
        {
            Label label = await context.Labels.Where(l => l.Name == querystring).SingleAsync();

            if (label == null)
            {
                throw new FindInvalidOperationException();
            }
            else 
            {
                return await Task.FromResult<string>(label.Description);
            }
        }
    }
}