using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BasePath
    {
        public string ContentRootPath { get; set; }
        public BasePath(string path)
        {
            ContentRootPath = path; 
        }
    }
}
