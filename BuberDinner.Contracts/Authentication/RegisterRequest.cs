namespace BuberDinner.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string EMail,
    string Password
);