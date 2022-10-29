using Operator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator.Services
{
    public class LoginService: LoginRepository
    {
        public Task<UserInfo> Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
