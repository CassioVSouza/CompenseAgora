using CompenseAgora.Enums;

namespace CompenseAgora.Services.Interfaces
{
    public interface IProfileService
    {
        Task<EAnswerLogin> ConfirmLoginAndCreateSessionAsync(string user, string password);
    }
}
