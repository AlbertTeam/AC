using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Connection
{
    public enum DBString
    {
        [Description("ai网站的查询字符串")]
        Query_AI,
        [Description("ai网站的写入字符串")]
        Action_AI
    }
}
