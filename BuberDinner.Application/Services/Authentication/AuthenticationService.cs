using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult (Guid.NewGuid(), 
        "fName", 
        "lName", 
        "email", 
        "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1 Validate if the user exists in tbe db

        //2 create unique ID

        //3 Create token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        
        return new AuthenticationResult(userId, 
        "fName", 
        "lName", 
        "email", 
        token);
    }
}