using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sockets.Applictions;

namespace Socket.Serverice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// 启动服务端 Sockets
        /// </summary>
        [HttpPost]
        public void StartServervice() 
        {
            Sockets.Applictions.SocketServer socket = new SocketServer(8888);
            socket.StartListen();
        }
    }
}
