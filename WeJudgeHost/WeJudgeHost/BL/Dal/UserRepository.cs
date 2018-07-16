using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeJudgeHost.BL.Dal.Entities;

namespace WeJudgeHost.BL.Dal
{
    public class UserRepository
    {
        private WeJadgeIdentityContext _context;

        public UserRepository(WeJadgeIdentityContext context)
        {
            _context = context;
        }



       public User Authenticate(string email, string pass)
        {
            using (_context)
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
                    return null;

                var user = _context.Users.SingleOrDefault(x => x.Email == email);

                // check if username exists
                if (user == null)
                    return null;

                // check if password is correct
                if (!VerifyPasswordHash(pass, user.PasswordHash, user.PasswordSalt))
                    return null;

                // authentication successful
                return (User)user;
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
