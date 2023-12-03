using BubberDinner.Application.Common.Interfaces.Persistance;
using BubberDinner.Domain.Entities;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("User with given email does not exists.");
        }

        if (user.Password != password){
            throw new Exception("Password is not correct");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult (
            user, 
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1 Validate if the user does not exists in tbe db
        if(_userRepository.GetUserByEmail(email) is not null){
            throw new Exception("User with given e-mail already exists.");
        }

        //2 Create a user (generate unique ID) and persist in the DB
        var user = new User{ 
            Email = email, 
            FirstName = firstName, 
            LastName = lastName, 
            Password = password
        };

        _userRepository.Add(user);
        //3 Create token
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        
        return new AuthenticationResult(
            user, 
            token
        );
    }
}