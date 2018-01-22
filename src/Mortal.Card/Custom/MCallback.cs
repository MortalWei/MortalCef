using CefSharp;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mlc
{
    /// <summary>
    /// Html注册事件,JS回调事件
    /// </summary>
    internal class MCallback : Presenter<IBaseClass>
    {
        public MCallback(IBaseClass view) : base(view)
        {
            View = view;
        }

        public void SpecialFunc(string args1, string args2, string args3, IJavascriptCallback javascriptCallback)
        {
            Task.Factory.StartNew(async () =>
            {
                using (javascriptCallback)
                {
                    var _result = View.OnSpecial(args1, args2, args3);
                    await javascriptCallback.ExecuteAsync(_result);
                }
            });
        }

        public void RoutineFunc(string args1, string args2, string args3)
        {
            View.OnRoutine(args1, args2, args3);
        }
    }
}
