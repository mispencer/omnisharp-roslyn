using System.Threading;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.Runtime;
using OmniSharp.Options;

namespace OmniSharp
{
    [Route("/")]
    public partial class OmnisharpController
    {
        private readonly OmnisharpWorkspace _workspace;
        private readonly OmniSharpOptions _options;
        private readonly IApplicationShutdown _applicationShutdown;

        public OmnisharpController(OmnisharpWorkspace workspace, IOptions<OmniSharpOptions> optionsAccessor, IApplicationShutdown applicationShutdown)
        {
            _workspace = workspace;
            _options = optionsAccessor != null ? optionsAccessor.Options : new OmniSharpOptions();
            _applicationShutdown = applicationShutdown;
        }

        [HttpPost("stopserver")]
        public bool StopServer()
        {
            new Thread(() => {
                Thread.Sleep(200);
                _applicationShutdown.RequestShutdown();
            });
            return true;
        }
    }
}
