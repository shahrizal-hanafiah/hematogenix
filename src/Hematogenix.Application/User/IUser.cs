using Hematogenix.Core.Interfaces;
using Hematogenix.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.Application
{
    public interface IUser:IAppService<UserDto>
    {
    }
}
