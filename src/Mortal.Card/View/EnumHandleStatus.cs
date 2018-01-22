using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlc
{
    /// <summary>
    /// C#处理状态
    /// </summary>
    public enum EnumHandleStatus
    {
        /// <summary>
        /// 等待
        /// </summary>
        Wait = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 1,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 2,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 3,
        /// <summary>
        /// 未定义
        /// </summary>
        Undefined = 4
    }
}
