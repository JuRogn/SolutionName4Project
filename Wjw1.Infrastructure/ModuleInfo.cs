using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Wjw1.Infrastructure
{
    /// <summary>
    /// 功能模型信息
    /// </summary>
    public class ModuleInfo
    {
        public string Name { get; set; }

        public Assembly Assembly { get; set; }

        public string ShortName
        {
            get
            {
                return Name.Split('.').Last();
            }
        }

        public string Path { get; set; }
    }
}
