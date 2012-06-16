using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            // We check .NET first because .NET will load the WinRT library (even though it can't really run it)
            // When running in Metro, it will not load the PresentationFramework lib
            // Silverlight will not load either Windows or PresentationFramework

            // Check .NET first 
            var cmdm = Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

            if (cmdm != null) // loaded the assembly, could be .net 
            {
                return Platform.Net;
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
