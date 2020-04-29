using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Sockets.Applictions.Applictions
{
    /// <summary>
    /// Tcp同步服务端,SocketObject继承抽象类
    /// 服务端采用TcpListener封装.
    /// 使用Semaphore 来控制并发,每次处理5个.最大处理5000 
    /// </summary>
    public class TcpServer:
    {

    }
}
