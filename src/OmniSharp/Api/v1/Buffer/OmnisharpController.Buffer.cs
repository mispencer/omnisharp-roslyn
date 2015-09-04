﻿using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OmniSharp.Models;

namespace OmniSharp
{
    public partial class OmnisharpController
    {
        [HttpPost("updatebuffer")]
        public async Task<ObjectResult> UpdateBuffer(UpdateBufferRequest request)
        {
            request.FileName = _pathRewriter.ToServerPath(request.FileName);
            await _workspace.BufferManager.UpdateBuffer(request);
            return new ObjectResult(true);
        }

        [HttpPost("changebuffer")]
        public async Task<ObjectResult> ChangeBuffer(ChangeBufferRequest request)
        {
            request.FileName = _pathRewriter.ToServerPath(request.FileName);
            await _workspace.BufferManager.UpdateBuffer(request);
            return new ObjectResult(true);
        }
    }
}
