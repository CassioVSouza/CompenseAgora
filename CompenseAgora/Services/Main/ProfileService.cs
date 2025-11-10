using CompenseAgora.Enums;
using CompenseAgora.Models;
using CompenseAgora.Repositories.Interfaces;
using CompenseAgora.Services.Interfaces;

namespace CompenseAgora.Services.Main
{
    public class ProfileService : IProfileService
    {

        private readonly IProfileRepositorie _profileRepo;
        private readonly SessionState _session;

        public ProfileService(IProfileRepositorie profile, SessionState session) {
            _profileRepo = profile;
            _session = session;
        }


        public async Task<EAnswerLogin> ConfirmLoginAndCreateSessionAsync(string user, string password)
        {
            try
            {
                if (!await _profileRepo.ProfileExistsAsync(user))
                    return EAnswerLogin.ErrorUser;

                var idUser = await _profileRepo.PasswordIsCorrectAsync(user, password);

                if (idUser == 0)
                    return EAnswerLogin.ErrorPassword;

                _session.Name = user;
                _session.Id = idUser;

                return EAnswerLogin.Success;
            }
            catch (Exception) {
                return EAnswerLogin.GeneralError;
            }
        }
    }
}
