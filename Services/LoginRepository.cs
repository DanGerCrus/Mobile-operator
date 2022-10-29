using Operator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Services
{
    internal interface LoginRepository
    {
        Task<UserInfo> Login(string username, string password);
    }
}
