
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Utils.Logged
{
    public class LoggerServices : ILoggedService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoggerServices(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string UsuarioCodigo
        {
            get {

                return httpContextAccessor.HttpContext?.User?.FindFirst("user").Value; ;
            }
        }


        public string UsuarioRol
        {
            get
            {

                return httpContextAccessor.HttpContext?.User?.FindFirst("rol").Value; ;
            }
        }
       
    }
}
