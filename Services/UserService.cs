using AutoMapper;
using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class UserService 
    {
        public IUserRepository Repository { get; set; }
        public OperationExecution Operation { get; set; }


        public OperationResult<UserResponseDTO> GetUserByUserName(string username)
        {
            Func<UserResponseDTO> getUser = () =>
            {
                return Repository.GetUserByUserName(username);

            };

            return Operation.ExecuteOperation(getUser);
        }

        public OperationResult<List<UserResponseDTO>> GetAllUsers()
        {
            Func<List<UserResponseDTO>> getAllUsers = () =>
            {
                return Repository.GetAll<User, UserResponseDTO>();
            };

            return Operation.ExecuteOperation(getAllUsers);
        }

        public OperationResult CreateUser(UserRequestDTO userRequested)
        {
            //check if username exists. We don't want redundant usernames as they should be unique
            var checkUserExistanceOperation = GetUserByUserName(userRequested.UserName);
            if (checkUserExistanceOperation.HasSucceeded && checkUserExistanceOperation.Result != null)
            {
                return new OperationResult(new Exception("Username already exists."));
            }
            // register time of creation
            userRequested.CreatedAt = DateTime.Now;

            // generate user id
            userRequested.ID = Guid.NewGuid();

            Action createUser = () =>
            {
                Repository.Create<UserRequestDTO, User>(userRequested);

            };

            return Operation.ExecuteOperation(createUser);
        }

    }
}
