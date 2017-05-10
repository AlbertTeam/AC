using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Connection.DataBaseConfig
{
    public class DatabaseFilePathSettingException : Exception
    {
        public DatabaseFilePathSettingException(string msg)
            : base("数据库配置文件错误" + msg)
        {
        }
    }


    public class ConnStringEncrytSettingException : Exception
    {
        public ConnStringEncrytSettingException()
            : base("链接字符串加密配置错误（未设置密钥或加解密开关设置错误）！")
        {
        }
    }

    public class DatabaseNotSpecifiedException : Exception
    {
    }

    public class ConnStringDeEncrytException : Exception
    {
        public ConnStringDeEncrytException()
            : base("链接字符串解密错误！")
        {
        }

        public ConnStringDeEncrytException(string dataName)
            : base(dataName + "链接字符串解密错误！")
        {
        }

    }
}
