using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace mlc.mControl
{
    /// <summary>
    /// 用于承载Cef控件
    /// </summary>
    public class muc : Control, IBaseClass
    {
        #region variable && attribute
        /// <summary>
        /// Cefsharp-control
        /// </summary>
        ChromiumWebBrowser _Browser;

        /// <summary>
        /// URL地址
        /// </summary>
        private string m_Url { get; set; }

        /// <summary>
        /// 是否初始化
        /// </summary>
        private bool IsInitialization { get; set; }
        #endregion

        #region structure
        /// <summary>
        /// 构造
        /// </summary>
        public muc()
        {
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 构造:带url的构造
        /// </summary>
        /// <param name="url"></param>
        public muc(string url, bool isLoad = true) : this()
        {
            //_Browser = new ChromiumWebBrowser(url);
            m_Url = url;
            Init(isLoad);
        }

        /// <summary>
        /// 构造:带url及默认数据的构造
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        public muc(string url, string args, bool isLoad = true) : this()
        {
            //_Browser = new ChromiumWebBrowser(url);
            m_Url = url;
            Init(isLoad);
            OnLoad(args);
        }
        #endregion

        #region void
        /// <summary>
        /// 刷新控件
        /// </summary>
        public void OnRefresh()
        {
            Init(true);
        }

        /// <summary>
        /// 初始化Cefsharp
        /// </summary>
        private void Init(bool isLoad)
        {
            if (!isLoad) return;
            _Browser = new ChromiumWebBrowser(m_Url);
            _Browser.MenuHandler = new MenuHandler();
            _Browser.RegisterJsObject("mcall", new MCallback(this), false);
            _Browser.Dock = DockStyle.Fill;
            Controls.Add(_Browser);
            IsInitialization = true;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="args"></param>
        private void OnLoad(string args)
        {
            _Browser.EvaluateScriptAsync("load(" + args + ")");
        }
        #endregion

        #region override

        #region reload
        /// <summary>
        /// 重新加载页面
        /// 刷新本页
        /// </summary>
        public void Reload()
        {
            _Browser.Reload();
        }
        /// <summary>
        /// 重新加载页面
        /// 加载新页面
        /// </summary>
        public void Reload(Uri uri)
        {
            _Browser.Load(uri.ToString());
        }
        /// <summary>
        /// 重新加载页面
        /// 加载新页面,并带参数
        /// </summary>
        public void Reload(Uri uri, string args)
        {
            Reload(uri);
            OnLoad(args);
        }
        /// <summary>
        /// 重新加载页面
        /// 加载新页面
        /// </summary>
        public void Reload(string url)
        {
            _Browser.Load(url);
        }
        /// <summary>
        /// 重新加载页面
        /// 加载新页面,并带参数
        /// </summary>
        public void Reload(string url, string args)
        {
            Reload(url);
            OnLoad(args);
        }
        #endregion reload

        #region C# Call CefSharp
        /// <summary>
        /// C# Call CefSharp
        /// 通过CefSharp EvaluateScriptAsync方法实现
        /// 若失败,返回值 String.Empty
        /// </summary>
        /// <returns>String</returns>
        public string EvaluateScriptAsync(string script)
        {
            if (!_Browser.IsBrowserInitialized) return string.Empty;

            var _Task = _Browser.EvaluateScriptAsync(script);
            _Task.Wait();
            if (!_Task.Result.Success) return string.Empty;
            return _Task.Result.Result.ToString();
        }

        /// <summary>
        /// C# Call CefSharp
        /// 通过CefSharp EvaluateScriptAsync方法实现
        /// 若失败,返回值 Null
        /// </summary>
        /// <returns>Object</returns>
        public object EvaluateScriptAsyncObject(string script)
        {
            if (!_Browser.IsBrowserInitialized) return null;
            var _Task = _Browser.EvaluateScriptAsync(script);
            _Task.Wait();
            if (!_Task.Result.Success) return null;
            return _Task.Result.Result;
        }

        /// <summary>
        /// C# Call CefSharp
        /// 通过CefSharp ExecuteScriptAsync方法实现
        /// </summary>
        /// <param name="script"></param>
        public void ExecuteScriptAsync(string script)
        {
            if (!_Browser.IsBrowserInitialized) return;
            _Browser.ExecuteScriptAsync(script);
        }

        /// <summary>
        /// C# Call CefSharp
        /// 通过CefSharp ExecuteScriptAsync方法实现
        /// </summary>
        /// <param name="methodName">方法名称</param>
        /// <param name="args">参数</param>
        public void ExecuteScriptAsync(string methodName, params object[] args)
        {
            if (!_Browser.IsBrowserInitialized) return;
            if (args == null) args = new object[] { };
            _Browser.ExecuteScriptAsync(methodName, args);
        }
        #endregion

        #region Back && Forward
        /// <summary>
        /// 显示上一页
        /// </summary>
        public void BackPage()
        {
            _Browser.Back();
        }
        /// <summary>
        /// 显示下一页
        /// </summary>
        public void ForwardPage()
        {
            _Browser.Forward();
        }

        #endregion

        #region DevTools
        /// <summary>
        /// 打开调试工具
        /// </summary>
        public void ShowDevTools()
        {
            _Browser.ShowDevTools();
        }

        /// <summary>
        /// 关闭调试工具
        /// </summary>
        public void CloseDevTools()
        {
            _Browser.CloseDevTools();
        }
        #endregion 

        #endregion

        #region inherit && exposed
        /// <summary>
        /// 内部方法,请勿随意使用,否则将引起不可预知的情况
        /// </summary>
        /// <param name="args1"></param>
        /// <param name="args2"></param>
        /// <param name="args3"></param>
        public void OnRoutine(string args1, string args2, string args3)
        {
            HandlerArags _Args = new HandlerArags
            {
                Parameter1 = args1,
                Parameter2 = args2,
                Parameter3 = args3,
                Status = EnumHandleStatus.Wait
            };
            BusinessHandler?.Invoke(null, _Args);
        }

        /// <summary>
        /// 内部方法,请勿随意使用,否则将引起不可预知的情况
        /// </summary>
        /// <param name="args1"></param>
        /// <param name="args2"></param>
        /// <param name="args3"></param>
        /// <returns></returns>
        public string OnSpecial(string args1, string args2, string args3)
        {
            HandlerArags _Args = new HandlerArags
            {
                Parameter1 = args1,
                Parameter2 = args2,
                Parameter3 = args3,
                Status = EnumHandleStatus.Wait
            };
            BusinessHandler?.Invoke(null, _Args);
            return _Args.Status == EnumHandleStatus.Success ? _Args.Result : string.Empty;
        }

        /// <summary>
        /// 内部方法,请勿随意使用,否则将引起不可预知的情况
        /// </summary>
        /// <param name="args1"></param>
        /// <param name="args2"></param>
        /// <param name="args3"></param>
        /// <returns></returns>
        public string OnReturnJson(string args1, string args2, string args3)
        {
            HandlerArags _Args = new HandlerArags
            {
                Parameter1 = args1,
                Parameter2 = args2,
                Parameter3 = args3,
                Status = EnumHandleStatus.Wait
            };
            BusinessHandler?.Invoke(null, _Args);
            return _Args.Status == EnumHandleStatus.Success ? _Args.Result : string.Empty;
        }

        /// <summary>
        /// 常规处理,用于处理无需给Html返回值的操作
        /// </summary>
        public event EventHandler<HandlerArags> BusinessHandler;
        ///// <summary>
        ///// 常规处理,用于处理需要给Html返回值的操作
        ///// </summary>
        //public event EventHandler<HandleArags> SpecialHandle;
        #endregion inherit && exposed
    }
}
