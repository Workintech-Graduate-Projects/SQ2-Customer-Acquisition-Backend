using AutoMapper;
using CRM.Application.Dtos;
using CRM.Application.Interfaces.Repositories;
using CRM.Application.Interfaces.Services;
using CRM.Domain.Entities;
using CRM_Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public LoginService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<string> Login(UserDto userD)
        {

            var passwordHashed = PasswordHashHelper.CreatePasswordHash(userD.Password);

            var user = await userRepository.GetByUsernameAndPassword(userD.Username, passwordHashed);
            if (user == null)
            {
                throw new Exception("Kullanıcı bilgileri hatalı ya da eksik!");
            }

            UserDto userDto = mapper.Map<User, UserDto>(user);
            var token = TokenHelper.CreateToken(userDto.Username, userDto.RoleId);
            return token;


        }
    }
}
