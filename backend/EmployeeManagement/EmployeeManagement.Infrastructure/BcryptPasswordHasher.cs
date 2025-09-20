using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Infrastructure;

public class BcryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
    public bool Verify(string Password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(Password, hashedPassword);
}
