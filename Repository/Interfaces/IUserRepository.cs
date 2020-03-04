using Data;

namespace Repository
{
    public interface IUserRepository : IRepository 
    {
        UserResponseDTO GetUserByUserName(string username);
    }
}