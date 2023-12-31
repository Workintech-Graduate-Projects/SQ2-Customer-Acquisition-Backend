﻿using CRM.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserDto entity);
        Task<UserDto> Update(UserDto entity);
    }
}
