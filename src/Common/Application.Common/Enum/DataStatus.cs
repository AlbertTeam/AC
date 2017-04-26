using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Enum
{
    /// <summary>
    /// 数据状态
    /// </summary>
    enum DataStatus
    {
        [Description("正常")]
        Normal=0,
        [Description("删除")]
        Delete =1,

    }
}
