using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hematogenix.Core.Interfaces
{
    public interface IAppService<TDto>
    {
        TDto GetById(int id);
        IList<TDto> GetAll();
        int Insert(TDto dto);
        void Update(TDto dto);
        void Delete(int id);
    }
}
