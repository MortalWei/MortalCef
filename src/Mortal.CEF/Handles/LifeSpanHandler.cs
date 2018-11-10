using System;
using CefSharp;
using CefSharp.WinForms;

namespace mlc
{
    /// <summary>
    /// 
    /// </summary>
    public class LifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            //browser.CloseBrowser(true);
            return true;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }

        /// <summary>
        /// 取消新窗口
        /// </summary>
        /// <param name="browserControl"></param>
        /// <param name="browser"></param>
        /// <param name="frame"></param>
        /// <param name="targetUrl"></param>
        /// <param name="targetFrameName"></param>
        /// <param name="targetDisposition"></param>
        /// <param name="userGesture"></param>
        /// <param name="popupFeatures"></param>
        /// <param name="windowInfo"></param>
        /// <param name="browserSettings"></param>
        /// <param name="noJavascriptAccess"></param>
        /// <param name="newBrowser"></param>
        /// <returns></returns>
        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }
    }
}
