using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace QiNiuCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [Route("uploadFile")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<string>> Upload()
        {
            var files = Request.Form.Files;
            var file = files[0];
            var stream = file.OpenReadStream();
            string url = await QiNiuHelper.PutAsync(file.FileName, stream);
            return url;
        }

        [HttpPost]
        [Route("amrToMp3")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<string>> AmrToMp3()
        {
            var files = Request.Form.Files;
            var file = files[0];
            var stream = file.OpenReadStream();
            var request = HttpContext.Request;
            string url = await QiNiuHelper.PutAmrToMp3Async(file.FileName, stream, $"{request.Scheme}://{request.Host.Value}/api/Upload/notification");
            return url;
        }

        [Route("notification")]
        public IActionResult Notification()
        {
            var req = Request.Form;
            var he = Request.Headers;
            var q = Request.Query;
            var b = Request.Body;
            return Content("11");
        }
    }
}