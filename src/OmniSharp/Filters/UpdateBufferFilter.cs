using System.Linq;
using Microsoft.AspNet.Mvc;
using OmniSharp.Models;
using OmniSharp.Services;

namespace OmniSharp.Filters
{
    public class UpdateBufferFilter : IActionFilter
    {
        private OmnisharpWorkspace _workspace;
        private readonly IPathRewriter _pathRewriter;

        public UpdateBufferFilter(OmnisharpWorkspace workspace, IPathRewriter pathRewriter)
        {
            _workspace = workspace;
            _pathRewriter = pathRewriter;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Any())
            {
                var requestArg = context.ActionArguments.FirstOrDefault(arg => arg.Value is Request);
                if (requestArg.Value != null)
                {
                    var request = (Request)requestArg.Value;
                    request.FileName = _pathRewriter.ToServerPath(request.FileName);
                    await _workspace.BufferManager.UpdateBuffer(request);
                }
            }
        }
    }
}
