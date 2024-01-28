using LoginService.LoginRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ILoginService _loginService;

        public UnitOfWork(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public ILoginService Log_inService => new Log_inService();

    }
}
