using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_openshift_source.Module
{
    public class ToDo
    {
        public string Title { get; set; }

        public string Detail { get; set; }

        public STATE State { get; set; }

        public enum STATE
        {
            NOTSTARTED,
            INPROGRESS,
            DONE,
            REMOVED
        }
    }
}
