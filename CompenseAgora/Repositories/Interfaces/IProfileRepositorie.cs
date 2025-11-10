namespace CompenseAgora.Repositories.Interfaces
{
    public interface IProfileRepositorie
    {
        Task<int> PasswordIsCorrectAsync(string username, string password);
        Task<bool> ProfileExistsAsync(string username);
    }
}
