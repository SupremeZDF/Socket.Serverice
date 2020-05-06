using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sockets.Applictions;

namespace Socket.Serverice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RsaJiaMiController : ControllerBase
    {
        [HttpGet]
        public void Run() 
        {
        
            RsaJiaMiApplication.RSACryptography();
            RsaJiaMiApplication.RSAjieMi();
        }

        [HttpGet]
        public void Getkey()
        {
            RsaJiaMiApplication.GetKey();
            RsaJiaMiApplication.Encryption();
        }

    }
}