using Microsoft.Framework.OptionsModel;
using OmniSharp.Options;
using OmniSharp.Utilities;

namespace OmniSharp.Services
{
    public class OsPathRewriter : IPathRewriter
    {
        private readonly PathMode _client;
        private readonly PathMode _server;

        public OsPathRewriter(IOptions<OmniSharpOptions> optionsAccessor) : this(optionsAccessor.Options.PathOptions.Client, optionsAccessor.Options.PathOptions.Server) {}

        public OsPathRewriter(PathMode client, PathMode server)
        {
            _client = client;
            _server = server;
        }

        public string ToClientPath(string path)
        {
            if (_client == PathMode.Cygwin)
            {
                return CygPathWrapper.GetCygpath(path, _client);
            }
            else
            {
                return path;
            }

        }

        public string ToServerPath(string path)
        {
            if (_client == PathMode.Cygwin)
            {
                return CygPathWrapper.GetCygpath(path, _server);
            }
            else
            {
                return path;
            }
        }
    }
}
