using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mlc
{
    internal abstract class Presenter<T>
    {
        public T View { get; set; }

        public Presenter(T view)
        {
            View = view;
        }
    }
}
