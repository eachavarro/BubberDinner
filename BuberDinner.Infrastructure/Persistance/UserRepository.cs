using BubberDinner.Application.Common.Interfaces.Persistance;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users =  new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.Where(u=>u.Email == email).FirstOrDefault();
    }
}
