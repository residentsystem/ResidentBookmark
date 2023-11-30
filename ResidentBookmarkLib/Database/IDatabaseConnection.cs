namespace ResidentBookmarkLib.Database
{
    public interface IDatabaseConnection
    {
        string? GetConnectionString();
        
        string? GetConnectionString(DatabaseEnvironment connectionstring);
        
        string? MySqlConnectionStatus(string? connectionstring);
    }
}