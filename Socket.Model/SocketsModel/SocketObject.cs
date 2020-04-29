using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Socket.Models
{
    /// <summary>
    /// Socket基类(抽象类)
    /// 抽象3个方法,初始化Socket(含一个构造),停止,启动方法.
    /// 此抽象类为TcpServer与TcpClient的基类,前者实现后者抽象方法.
    /// 作用: 纯属闲的蛋疼,不写个OO的我感觉不会写代码了...What The Fuck...
    /// </summary>
    public abstract class SocketObject
    {
        //IPAddress类提供了对IP地址的转换、处理等功能。其Parse方法可将IP地址字符串转换为IPAddress实例。
        public abstract void InitSocket(IPAddress ipaddress, int port);

        public abstract void InitSocket(string ipaddress, int port);

        public abstract void Start();

        public abstract void Stop();
    }
}
