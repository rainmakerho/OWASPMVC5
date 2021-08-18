using MyStore.Domain.Entities;
using System.Collections.Generic;

namespace MyStore.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void SaveUser(User user);
        User DeleteUser(int userID);

        void NotifyUser(string email, string subject, string body);

        User GetUserFromResetToken(string token);
    }
}
