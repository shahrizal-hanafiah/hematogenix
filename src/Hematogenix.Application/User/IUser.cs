using Hematogenix.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.Application
{
    public interface IUser
    {
        bool RegisterUser(RegisterDto registerDto);
    }
}
