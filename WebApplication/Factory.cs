using AutoMapper;
using Data;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class Factory
    {
        public static UserService InstantiateUserService()
        {
            return new UserService
            {
                Repository = new UserRepository
                {
                    _mapper = new AutoMap
                    {
                        _mapper = new MapperConfiguration(cfg =>
                        {

                            cfg.CreateMap<UserRequestDTO, User>();
                            cfg.CreateMap<User, UserResponseDTO>();

                        }).CreateMapper()
                    }
                },

                Operation = new OperationExecution()
            };
        }
    }
}
