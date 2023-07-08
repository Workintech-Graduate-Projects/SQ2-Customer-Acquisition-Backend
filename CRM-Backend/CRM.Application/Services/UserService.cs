using AutoMapper;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Repositories;
using CRM.Application.Interfaces.Services;
using CRM.Domain.Entities;
using CRM_Common.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDto> AddAsync(UserDto entity)
        {

            var passwordHashed = PasswordHashHelper.CreatePasswordHash(entity.Password);

            User user = mapper.Map<UserDto, User>(entity);
            user.PasswordHash = passwordHashed;
            await userRepository.AddAsync(user);

            return entity;
        }

        public async Task<UserDto> Update(UserDto entity)
        {
            User user = mapper.Map<UserDto, User>(entity);
            await userRepository.Update(user);

            return entity;
        }
 
    }
}

