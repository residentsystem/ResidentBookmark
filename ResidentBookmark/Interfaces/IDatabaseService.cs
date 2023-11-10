namespace ResidentBookmark.Interfaces
{
    public interface IDatabaseService
    {
        string GetConnectionString();
        
        string GetConnectionString(DatabaseEnvironment connectionstring);
        
        string MySqlConnectionStatus(string connectionstring);
    }
}