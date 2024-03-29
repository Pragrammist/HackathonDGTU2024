using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonDGTU.Services.Dtos.User;

namespace HackathonDGTU.Services.Services
{
    public interface IAuthService
    {
        UserDto CurrentUser { get; }
    }
}