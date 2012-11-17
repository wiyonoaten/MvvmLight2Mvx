using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Internal
{
    internal interface ICommandManagerHelper
    {
        void InvalidateRequerySuggested();
        event EventHandler RequerySuggested;
    }
}
