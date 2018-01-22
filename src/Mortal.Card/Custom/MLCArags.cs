using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlc
{
    /// <summary>
    /// 自定义事件处理类
    /// </summary>
    public class HandlerArags : EventArgs
    {
        /// <summary>
        /// Html传递给C#的第一个参数
        /// </summary>
        public string Parameter1 { get; set; }

        /// <summary>
        /// Html传递给C#的第二个参数
        /// </summary>
        public string Parameter2 { get; set; }

        /// <summary>
        /// Html传递给C#的第三个参数
        /// </summary>
        public string Parameter3 { get; set; }

        /// <summary>
        /// C#处理状态
        /// </summary>
        public EnumHandleStatus Status { get; set; }

        /// <summary>
        /// C#处理结果数据
        /// </summary>
        public string Result { get; set; }
    }
}
