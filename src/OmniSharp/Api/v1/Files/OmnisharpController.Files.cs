using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using OmniSharp.Models;
using OmniSharp.Services;

namespace OmniSharp
{
    public class FilesController
    {
        private readonly IFileSystemWatcher _watcher;
        private readonly IPathRewriter _pathRewriter;

        public FilesController(IFileSystemWatcher watcher, IPathRewriter pathRewriter)
        {
            _watcher = watcher;
            _pathRewriter = pathRewriter;
        }

        [HttpPost("/filesChanged")]
        public bool OnFilesChanged(IEnumerable<Request> requests)
        {
            foreach (var request in requests)
            {
                _watcher.TriggerChange(_pathRewriter.ToServerPath(request.FileName));
            }
            return true;
        }
    }
}
