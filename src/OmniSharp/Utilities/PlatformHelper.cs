using OmniSharp.Options;
using System;

namespace OmniSharp
{
    internal static class PlatformHelper
    {
        private static Lazy<bool> _isMono = new Lazy<bool>(() => Type.GetType("Mono.Runtime") != null);

        public static bool IsMono
        {
            get
            {
                return _isMono.Value;
            }
        }

        public static PathMode DefaultPathMode {
            get {
                return IsMono ? PathMode.Unix : PathMode.Windows;
            }
        }
    }
}
