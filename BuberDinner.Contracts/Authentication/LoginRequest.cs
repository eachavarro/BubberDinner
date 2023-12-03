namespace BuberDinner.Contracts.Authentication;

public record LoginRequest(
    string EMail,
    string Password
);