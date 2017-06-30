using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Migazo
{
    public static class MvcExtensions
    {
        /// <summary>
        /// Wraper to @Url.Content to include file modification date as yyyyMMddHHmmss
        /// </summary>
        /// <param name="url">UrlHelper</param>
        /// <param name="path">Path to file</param>
        /// <returns>string with file path with version as ~your/file/path?v=date</returns>
        public static string ContentWithDateParam(this UrlHelper url, string path)
        {
            var filePath = HostingEnvironment.MapPath(path);
            var urlPath = path + "?v=" + new FileInfo(filePath).LastWriteTime.ToString("yyyyMMddHHmmss");
            return url.Content(urlPath);
        }
    }
}
