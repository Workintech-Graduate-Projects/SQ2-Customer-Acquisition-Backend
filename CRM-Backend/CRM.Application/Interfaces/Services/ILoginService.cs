using CRM.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces.Services
{
    public interface ILoginService
    {
        public Task<string> Login(UserDto user);
    }
}
