using AdminMicroServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.Interface
{
    public interface IJWTMangerRepository 
    {
        Tokens Authenticate(LoginViewModel users, bool IsRegister);
    }
}
