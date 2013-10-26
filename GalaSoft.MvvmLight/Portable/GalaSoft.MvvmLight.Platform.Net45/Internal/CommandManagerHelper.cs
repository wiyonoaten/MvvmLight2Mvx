using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GalaSoft.MvvmLight.Internal
{
    class CommandManagerHelper : ICommandManagerHelper
    {
        public void InvalidateRequerySuggested()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public event EventHandler RequerySuggested
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
