using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class DownloadFile
    {
        public string FileName { get; set; } = "";
        public byte[] Content { get; set; }

        public string ContentType { get; set; } = null;
    }
}
