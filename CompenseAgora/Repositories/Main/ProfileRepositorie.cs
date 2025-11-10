using CompenseAgora.Data;
using CompenseAgora.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompenseAgora.Repositories.Main
{
    public class ProfileRepositorie : IProfileRepositorie
    {
        private readonly DataEFContext _context;

        public ProfileRepositorie(DataEFContext context)
        {
            _context = context;
        }

        public async Task<bool> ProfileExistsAsync(string username)
        {
            try
            {
                var user = await _context.Profile.FirstOrDefaultAsync(o => o.Name == username);

                if (user != null)
                    return true;

                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<int> PasswordIsCorrectAsync(string username, string password)
        {
            try
            {
                var user = await _context.Profile.FirstOrDefaultAsync(o => o.Name == username && o.Password == password);

                if (user != null)
                    return user.Id;

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
