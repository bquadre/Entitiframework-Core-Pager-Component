using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagerComponent.Utilities
{
    public class PagerResult<T> : PagerResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagerResult()
        {
            Results = new List<T>();
        }
    }
}
