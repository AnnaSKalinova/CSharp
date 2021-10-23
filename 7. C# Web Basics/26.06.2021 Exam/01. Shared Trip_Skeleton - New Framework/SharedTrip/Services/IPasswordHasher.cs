namespace SharedTrip.Controllers
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}