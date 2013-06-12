using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace XilixShell
{
    public static class NewTopWindowCommand
    {
        public static readonly RoutedUICommand NewTopWindow = new RoutedUICommand("New Top Window", "NewTopWindow", typeof(NewTopWindowCommand));
    }
}
