using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Models
{
    public class PageBase<T>
    {
        public Information Info { get; set; }

        public T Results { get; set; }

        public class Information
        {
            public int Page { get; set; }

            public int Results { get; set; }

            public int Total { get; set; }

            public string Seed { get; set; }

            public string Version { get; set; }
        }
    }
}
