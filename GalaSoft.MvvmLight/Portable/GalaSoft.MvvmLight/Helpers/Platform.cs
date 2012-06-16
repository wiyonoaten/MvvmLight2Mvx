using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GalaSoft.MvvmLight.Helpers
{
    public static class PlatformHelper
    {
        public static Platform CurrentPlatform
        {
            get
            {
                if(_currentPlatform == null)
                {
                    _currentPlatform = GetCurrentPlatform();
                }
                return _currentPlatform.Value;
            }
        }

        private static Platform GetCurrentPlatform()
        {
            // Check .NET first -- this will fail on SL and WinRT as we're doing private reflection
            try
            {
                var t = typeof(Type);
                var arrProp = t.GetProperty("IsSzArray", BindingFlags.NonPublic | BindingFlags.Instance);

                if (arrProp != null)
                {
                    var arr = arrProp.GetValue(t, null);
                    var cmdm = Type.GetType(
                        "System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

                    if (cmdm != null && arr != null)
                    {
                        return Platform.Net;
                    }
                }
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            // check WinRT next
            var wadm = Type.GetType("Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime");
            if (wadm != null)
            {
                return Platform.Metro;
            }

            // Check Silverlight

            var dm = Type.GetType("System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
            if (dm != null)
            {
                return Platform.Silverlight;
            }

            return Platform.Unknown;
        }


        private static Platform? _currentPlatform;
    }

    public enum Platform
    {
        Unknown,
        Net,
        Metro,
        Silverlight
    }
}
