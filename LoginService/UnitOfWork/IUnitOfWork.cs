using LoginService.LoginRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.UnitOfWork
{
    public interface IUnitOfWork
    {
        ILoginService Log_inService { get; }
    }
}
