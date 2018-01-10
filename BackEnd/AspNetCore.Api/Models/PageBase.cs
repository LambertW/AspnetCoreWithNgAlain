using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Models
{
    public class PageBase<T>
    {
        public Info info { get; set; }

        public T results { get; set; }

        public class Info
        {
            public int page { get; set; }

            public int results { get; set; }

            public string seed { get; set; }

            public string version { get; set; }
        }
    }
}
