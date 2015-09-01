using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using OmniSharp.Options;
using OmniSharp.Services;

namespace OmniSharp
{
    [Route("/")]
    public partial class OmnisharpController
    {
        private readonly OmnisharpWorkspace _workspace;
        private readonly OmniSharpOptions _options;
        private readonly IPathRewriter _pathRewriter;

        public OmnisharpController(OmnisharpWorkspace workspace, IOptions<OmniSharpOptions> optionsAccessor, IPathRewriter pathRewriter)
        {
            _workspace = workspace;
            _options = optionsAccessor != null ? optionsAccessor.Options : new OmniSharpOptions();
            _pathRewriter = pathRewriter;
        }
    }
}
