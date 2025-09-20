namespace EmployeeManagement.Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string Password, string hashedPassword);
}
