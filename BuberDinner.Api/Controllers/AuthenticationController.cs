using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var result = _authenticationService.Register(registerRequest.FirstName,
                        registerRequest.LastName,
                        registerRequest.Email,
                        registerRequest.Password);

        var response = new AuthenticationResponse(
            result.User.Id, 
            result.User.FirstName, 
            result.User.LastName, 
            result.User.Email, 
            result.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var result = _authenticationService.Login(loginRequest.EMail,
        loginRequest.Password);

        var response = new AuthenticationResponse(
            result.User.Id, 
            result.User.FirstName, 
            result.User.LastName, 
            result.User.Email, 
            result.Token
        );

        return Ok(response);
    }
    
}