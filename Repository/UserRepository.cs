using Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserResponseDTO GetUserByUserName(string username)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var user = dbContext.User
                        .Where(u => u.UserName == username)
                        .FirstOrDefault();
                    return _mapper.Mapping<User, UserResponseDTO>(user);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}
