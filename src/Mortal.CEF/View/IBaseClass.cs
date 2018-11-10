using System;

namespace mlc
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IBaseClass
    {
        #region reload
        /// <summary>
        /// 重新加载页面
        /// 刷新本页
        /// </summary>
        void Reload();
        /// <summary>
        /// 重新加载页面
        /// 加载新页面
        /// </summary>
        void Reload(Uri uri);
        /// <summary>
        /// 重新加载页面
        /// 加载新页面,并带参数
        /// </summary>
        void Reload(Uri uri, string args);
        /// <summary>
        /// 重新加载页面
        /// 加载新页面
        /// </summary>
        void Reload(string url);
        /// <summary>
        /// 重新加载页面
        /// 加载新页面,并带参数
        /// </summary>
        void Reload(string url, string args);
        #endregion reload

        #region Back && Forward
        /// <summary>
        /// 显示上一页
        /// </summary>
        void BackPage();
        /// <summary>
        /// 显示下一页
        /// </summary>
        void ForwardPage();
        #endregion

        #region DevTools
        /// <summary>
        /// 打开调试工具
        /// </summary>
        void ShowDevTools();
        /// <summary>
        /// 关闭调试工具
        /// </summary>
        void CloseDevTools();
        #endregion

        #region Custom
        void OnRoutine(string args1, string args2, string args3);
        string OnSpecial(string args1, string args2, string args3);
        string OnReturnJson(string args1, string args2, string args3);
        event EventHandler<HandlerArags> BusinessHandler;
        #endregion
    }
}
