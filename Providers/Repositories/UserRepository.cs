using System;
using System.Linq;
using CookieReaders.Models;
using CookieReaders.Models.Entities;

namespace CookieReaders.Providers.Repositories
{
    public interface IUserRepository
    {
        CookieUserItem Register(RegisterVm model);
        CookieUserItem Validate(LoginVm model);
    }

    public class UserRepository : IUserRepository
    {
        private CookieReadersContext _db;

        public UserRepository(CookieReadersContext db)
        {
            _db = db;
        }

        public CookieUserItem Validate(LoginVm model)
        {
            var emailRecords = _db.Users.Where(x => x.EmailAddress == model.EmailAddress);

            var results = emailRecords.AsEnumerable()
            .Where(m => m.PasswordHash == Hasher.GenerateHash(model.Password, m.Salt))
            .Select(m => new CookieUserItem
            {
                UserId = m.Id,
                EmailAddress = m.EmailAddress,
                Name = m.Name,
                CreatedUtc = m.CreatedUtc
            });

            return results.FirstOrDefault();
        }

        public CookieUserItem Register(RegisterVm model)
        {
            var salt = Hasher.GenerateSalt();
            var hashedPassword = Hasher.GenerateHash(model.Password, salt);

            var user = new CookieUser
            {
                Id = Guid.NewGuid(),
                EmailAddress = model.EmailAddress,
                PasswordHash = hashedPassword,
                Salt = salt,
                Name = "Some User",
                CreatedUtc = DateTime.UtcNow
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return new CookieUserItem
            {
                UserId = user.Id,
                EmailAddress = user.EmailAddress,
                Name = user.Name,
                CreatedUtc = user.CreatedUtc
            };
        }
    }
}