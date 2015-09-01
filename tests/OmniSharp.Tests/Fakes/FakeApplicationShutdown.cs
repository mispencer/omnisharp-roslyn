using System.Threading;
using Microsoft.Framework.Runtime;

namespace OmniSharp.Tests
{
    public class FakeApplicationShutdown : IApplicationShutdown
    {
        void IApplicationShutdown.RequestShutdown() { }
        public CancellationToken ShutdownRequested { get { return CancellationToken.None; } }
    }
}
