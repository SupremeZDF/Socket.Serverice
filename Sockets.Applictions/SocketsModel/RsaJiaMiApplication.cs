using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Sockets.Applictions
{
    public class RsaJiaMiApplication
    {

        public static byte[] aa;

        public static void RSACryptography()
        {
            //X509Certificate x509Certificate = new X509Certificate();
            //初始化并加载证书

            X509Certificate2 x509Certificate = new X509Certificate2("C:\\Users\\Administrator\\Desktop\\Folder\\接口规范及Demo\\40-C#版API,示例程序,配置参数\\30-测试环境参数\\config\\test.pfx", "cfca1234", X509KeyStorageFlags.DefaultKeySet);

            //SHA256 a = SHA256.Create();
            //RSA数字加密

            SHA1 sHA = SHA1.Create();

            var t = sHA.ComputeHash(Encoding.UTF8.GetBytes("12312312321321321"));

            //使用加密服务提供程序 (CSP) 提供的 RSA 算法的实现执行不对称加密和解密。 此类不能被继承。
            RSACryptoServiceProvider rSACrypto = new RSACryptoServiceProvider();
            //rSACrypto.FromXmlString(x509Certificate.PrivateKey.ToXmlString(false));

            //包含System.Security.Cryptography的XML字符串。RSA密钥信息。
            //rSACrypto.FromXmlString("<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent><P>0bKKnHLcSY/4BZnrfJ/D2fkTEHdW6xooEiq1hT5u9aCGZXuURoUrANWiUnU7yVvvesoJRVyWjJR6mBmNlMyxxw==</P><Q>/8F1cpltfuMLMlHBtFb5TGoyx/hVn/rzRIsHh4G6OsvXIJqDtFD1sZGJ1epVGvKFlnNHZNAc9XpyKU51iuWnmw==</Q><DP>yGLoaHauobFtXtTmntIBk3OcTzjrm4EEV8/uZKTz3c+HfsToPbeWD5cXJdsXxeUP5XPaBiljSHW+7UhF7rLpEw==</DP><DQ>PzxKGcettw3UGuD0D+7hPO+VFrRkF2Yo9+2YMvz0Ws1Dp6AMqGzMEtd1SRrjaAJG3WgrYtXCEz/vMh9gGLOnuQ==</DQ><InverseQ>mNXK/AXX29L6NOMAvTN99VNzwWVHExNkuPjA5vODRWupe0tnA+fUQiccY2kAZcDhu8+YiBZr5qiX6jqWc2g1bQ==</InverseQ><D>aAI2DR2KhMxYl83QkiJdHxMcT7BxdjJ5owrZ7fyB6isOntVRcscvnFesmPlBZI+z6Hf8EvpT3JTgZHWNlJLZq6pDyNovzC9UXA9RWnIT2WNmvNfh+8bjK6ztIGjMLaQWKxCqqcZ5k+K2J+1tk5RurvLy9byfSL23QUbQM9VJib0=</D></RSAKeyValue>");

            RSAPKCS1SignatureFormatter rSAPKCS = new RSAPKCS1SignatureFormatter(rSACrypto);


            //Sets the private key to use for creating the signature. 设置用于创建签名的密钥

            var bbbb = x509Certificate.PrivateKey.ToString();

            //var ttt = x509Certificate.PrivateKey.KeyExchangeAlgorithm;
            //var fff = x509Certificate.PrivateKey.SignatureAlgorithm;

            rSAPKCS.SetKey(x509Certificate.PrivateKey);

            //设置用于创建签名的散列算法。
            //用于创建签名的散列算法的名称
            rSAPKCS.SetHashAlgorithm("SHA1");

            var d = rSAPKCS.CreateSignature(t);
            aa = d;


            X509Certificate2 ooo = new X509Certificate2("C:\\Users\\Administrator\\Desktop\\Folder\\接口规范及Demo\\40-C#版API,示例程序,配置参数\\30-测试环境参数\\config\\paytest.cer");
            string xmlString =ooo.PublicKey.Key.ToXmlString(false);


            RSACryptoServiceProvider aaaa = new RSACryptoServiceProvider();

            aaaa.FromXmlString(xmlString);

            //aaaa.FromXmlString("<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");


            RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(aaaa);


            //rSAPKCS1SignatureDeformatter.SetKey(ooo.PrivateKey);

            rSAPKCS1SignatureDeformatter.SetHashAlgorithm("SHA1");
            var bl = rSAPKCS1SignatureDeformatter.VerifySignature(t, d);

            StringBuilder stringBuilder = new StringBuilder();




            foreach (var i in d)
            {
                stringBuilder.Append(i.ToString("x2"));
            }
            //4e5b66f93c7f4ab7f19830b2036045a9f7a1364102746641322f71ad83ecd15b4d9741a668d8de90cf433f030c0450819d858f93fddae237f64318f5148560c9f0dab96b798d574cc8be9f8dd5cf00061e031e3332af9e223bc1aff29c380233512b7005848a1378fb6297a0b814d7d38dc872f8112e7aa6c4e3ee03086faa5e
            var v = stringBuilder.ToString();
        }



        public static void RSAjieMi()
        {
            //X509Certificate2 x509Certificate = new X509Certificate2("C:\\Users\\Administrator\\Desktop\\Folder\\接口规范及Demo\\40-C#版API,示例程序,配置参数\\30-测试环境参数\\config\\paytest.cer");
            //string xmlString = x509Certificate.PublicKey.Key.ToXmlString(false);

            RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider();

            //rsacryptoServiceProvider.FromXmlString(xmlString);

            RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rsacryptoServiceProvider);
            rSAPKCS1SignatureDeformatter.SetHashAlgorithm("SHA1");
            SHA1 sHA = SHA1.Create();
            var t = sHA.ComputeHash(Encoding.UTF8.GetBytes("12312312321321321"));

            var c = rSAPKCS1SignatureDeformatter.VerifySignature(t, aa);
        }


        public static void RSACryptographyCreate()
        {
            //X509Certificate x509Certificate = new X509Certificate();
            //初始化并加载证书

            X509Certificate2 x509Certificate = new X509Certificate2("C:\\Users\\Administrator\\Desktop\\Folder\\接口规范及Demo\\40-C#版API,示例程序,配置参数\\30-测试环境参数\\config\\test.pfx", "cfca1234", X509KeyStorageFlags.DefaultKeySet);

            //SHA256 a = SHA256.Create();
            //RSA数字加密

            SHA1 sHA = SHA1.Create();

            var t = sHA.ComputeHash(Encoding.UTF8.GetBytes("12312312321321321"));

            //使用加密服务提供程序 (CSP) 提供的 RSA 算法的实现执行不对称加密和解密。 此类不能被继承。
            RSACryptoServiceProvider rSACrypto = new RSACryptoServiceProvider();

            RSAPKCS1SignatureFormatter rSAPKCS = new RSAPKCS1SignatureFormatter(rSACrypto);

            rSAPKCS.SetKey(x509Certificate.PrivateKey);

            rSAPKCS.SetHashAlgorithm("SHA1");

            var d = rSAPKCS.CreateSignature(t);
            aa = d;

            //RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rSACrypto);
            //rSAPKCS1SignatureDeformatter.SetHashAlgorithm("SHA1");
            //var bl = rSAPKCS1SignatureDeformatter.VerifySignature(t, d);

            StringBuilder stringBuilder = new StringBuilder();




            foreach (var i in d)
            {
                stringBuilder.Append(i.ToString("x2"));
            }
            //4e5b66f93c7f4ab7f19830b2036045a9f7a1364102746641322f71ad83ecd15b4d9741a668d8de90cf433f030c0450819d858f93fddae237f64318f5148560c9f0dab96b798d574cc8be9f8dd5cf00061e031e3332af9e223bc1aff29c380233512b7005848a1378fb6297a0b814d7d38dc872f8112e7aa6c4e3ee03086faa5e
            var v = stringBuilder.ToString();
        }



        public static void RSAjieMiCreate()
        {
            X509Certificate2 x509Certificate = new X509Certificate2("C:\\Users\\Administrator\\Desktop\\Folder\\接口规范及Demo\\40-C#版API,示例程序,配置参数\\30-测试环境参数\\config\\paytest.cer");
            string xmlString = x509Certificate.PublicKey.Key.ToXmlString(false);

            RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider();

            rsacryptoServiceProvider.FromXmlString(xmlString);

            RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rsacryptoServiceProvider);
            rSAPKCS1SignatureDeformatter.SetHashAlgorithm("SHA1");
            SHA1 sHA = SHA1.Create();
            var t = sHA.ComputeHash(Encoding.UTF8.GetBytes("12312312321321321"));

            var c = rSAPKCS1SignatureDeformatter.VerifySignature(t, aa);
        }


        /// <summary>
        /// 获取加密所使用的key，RSA算法是一种非对称密码算法，所谓非对称，就是指该算法需要一对密钥，使用其中一个加密，则需要用另一个才能解密。
        /// </summary>
        public static void GetKey()
        {
            //<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>
            string PublicKey = string.Empty;
            //
            string PrivateKey = string.Empty;
            //<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent><P>0bKKnHLcSY/4BZnrfJ/D2fkTEHdW6xooEiq1hT5u9aCGZXuURoUrANWiUnU7yVvvesoJRVyWjJR6mBmNlMyxxw==</P><Q>/8F1cpltfuMLMlHBtFb5TGoyx/hVn/rzRIsHh4G6OsvXIJqDtFD1sZGJ1epVGvKFlnNHZNAc9XpyKU51iuWnmw==</Q><DP>yGLoaHauobFtXtTmntIBk3OcTzjrm4EEV8/uZKTz3c+HfsToPbeWD5cXJdsXxeUP5XPaBiljSHW+7UhF7rLpEw==</DP><DQ>PzxKGcettw3UGuD0D+7hPO+VFrRkF2Yo9+2YMvz0Ws1Dp6AMqGzMEtd1SRrjaAJG3WgrYtXCEz/vMh9gGLOnuQ==</DQ><InverseQ>mNXK/AXX29L6NOMAvTN99VNzwWVHExNkuPjA5vODRWupe0tnA+fUQiccY2kAZcDhu8+YiBZr5qiX6jqWc2g1bQ==</InverseQ><D>aAI2DR2KhMxYl83QkiJdHxMcT7BxdjJ5owrZ7fyB6isOntVRcscvnFesmPlBZI+z6Hf8EvpT3JTgZHWNlJLZq6pDyNovzC9UXA9RWnIT2WNmvNfh+8bjK6ztIGjMLaQWKxCqqcZ5k+K2J+1tk5RurvLy9byfSL23QUbQM9VJib0=</D></RSAKeyValue>
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            //创建并返回一个包含当前System.Security.Cryptography.RSA密钥的XML字符串
            PublicKey = rSACryptoServiceProvider.ToXmlString(false); // 获取公匙，用于加密
            //为真，以包含公钥和私钥RSA
            PrivateKey = rSACryptoServiceProvider.ToXmlString(true); // 获取公匙和私匙，用于解密

            //Console.WriteLine("PublicKey is {0}", PublicKey);        // 输出公匙
            //Console.WriteLine("PrivateKey is {0}", PrivateKey);     // 输出密匙
            // 密匙中含有公匙，公匙是根据密匙进行计算得来的。

            //using (StreamWriter streamWriter = new StreamWriter("PublicKey.xml"))
            //{
            //    streamWriter.Write(rSACryptoServiceProvider.ToXmlString(false));// 将公匙保存到运行目录下的PublicKey
            //}
            //using (StreamWriter streamWriter = new StreamWriter("PrivateKey.xml"))
            //{
            //    streamWriter.Write(rSACryptoServiceProvider.ToXmlString(true)); // 将公匙&私匙保存到运行目录下的PrivateKey
            //}
        }


        public static void Encryption ()
        {

            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();

            //using (StreamReader streamReader = new StreamReader("PublicKey.xml")) // 读取运行目录下的PublicKey.xml
            //{
            //    rSACryptoServiceProvider.FromXmlString(streamReader.ReadToEnd()); // 将公匙载入进RSA实例中
            //}

            byte[] buffer = Encoding.UTF8.GetBytes("123"); // 将明文转换为byte[]

            // 加密后的数据就是一个byte[] 数组,可以以 文件的形式保存 或 别的形式(网上很多教程,使用Base64进行编码化保存)

            rSACryptoServiceProvider.FromXmlString("<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent><P>0bKKnHLcSY/4BZnrfJ/D2fkTEHdW6xooEiq1hT5u9aCGZXuURoUrANWiUnU7yVvvesoJRVyWjJR6mBmNlMyxxw==</P><Q>/8F1cpltfuMLMlHBtFb5TGoyx/hVn/rzRIsHh4G6OsvXIJqDtFD1sZGJ1epVGvKFlnNHZNAc9XpyKU51iuWnmw==</Q><DP>yGLoaHauobFtXtTmntIBk3OcTzjrm4EEV8/uZKTz3c+HfsToPbeWD5cXJdsXxeUP5XPaBiljSHW+7UhF7rLpEw==</DP><DQ>PzxKGcettw3UGuD0D+7hPO+VFrRkF2Yo9+2YMvz0Ws1Dp6AMqGzMEtd1SRrjaAJG3WgrYtXCEz/vMh9gGLOnuQ==</DQ><InverseQ>mNXK/AXX29L6NOMAvTN99VNzwWVHExNkuPjA5vODRWupe0tnA+fUQiccY2kAZcDhu8+YiBZr5qiX6jqWc2g1bQ==</InverseQ><D>aAI2DR2KhMxYl83QkiJdHxMcT7BxdjJ5owrZ7fyB6isOntVRcscvnFesmPlBZI+z6Hf8EvpT3JTgZHWNlJLZq6pDyNovzC9UXA9RWnIT2WNmvNfh+8bjK6ztIGjMLaQWKxCqqcZ5k+K2J+1tk5RurvLy9byfSL23QUbQM9VJib0=</D></RSAKeyValue>");

            byte[] EncryptBuffer = rSACryptoServiceProvider.Encrypt(buffer, false); // 进行加密


            RSACryptoServiceProvider rSACryptoServiceProviders = new RSACryptoServiceProvider();

            //using (StreamReader streamReader = new StreamReader("PublicKey.xml")) // 读取运行目录下的PublicKey.xml
            //{
            //    rSACryptoServiceProvider.FromXmlString(streamReader.ReadToEnd()); // 将公匙载入进RSA实例中
            //}

            //byte[] buffers = Encoding.UTF8.GetBytes("123"); // 将明文转换为byte[]

            // 加密后的数据就是一个byte[] 数组,可以以 文件的形式保存 或 别的形式(网上很多教程,使用Base64进行编码化保存)

            rSACryptoServiceProviders.FromXmlString("<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

            byte[] EncryptBuffers = rSACryptoServiceProvider.Decrypt(EncryptBuffer, false); // 进行加密


            var t = Encoding.UTF8.GetString(EncryptBuffers);

        }

        public static void Decrypt()
        {

            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();

            //using (StreamReader streamReader = new StreamReader("PublicKey.xml")) // 读取运行目录下的PublicKey.xml
            //{
            //    rSACryptoServiceProvider.FromXmlString(streamReader.ReadToEnd()); // 将公匙载入进RSA实例中
            //}

            byte[] buffer = Encoding.UTF8.GetBytes("123"); // 将明文转换为byte[]

            // 加密后的数据就是一个byte[] 数组,可以以 文件的形式保存 或 别的形式(网上很多教程,使用Base64进行编码化保存)

            rSACryptoServiceProvider.FromXmlString("<RSAKeyValue><Modulus>0X9P4M7kpVARR3vSNUH7lurSjZUFPLt6ATcrgjHVvRUtzG7QjI7uueIHy1y2DCwooauMrc54Suip1SqW8KcqLPMpvESmUoJzx2FJJ2pm/Kd+hYKSXnnwD5u76Nuovc0m1FYtFlwwho7PBNiYmdZ4AtJTmD6EdJqJFzYprezrdH0=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");

            byte[] EncryptBuffer = rSACryptoServiceProvider.Decrypt(buffer, false); // 进行加密

        }

    }
}
