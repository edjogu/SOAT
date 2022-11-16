namespace SOATSales.API.Services
{
    public interface IUserService
    {
        public bool IsUser(string email, string password);
    }
}