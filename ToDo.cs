using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_openshift_source
{
    // <copyright file="ToDo.cs" company="Click2Cloud">
    // Copyright (c) 2015 All Rights Reserved
    // </copyright>
    // <author>Shrutika Mendhe</author>
    // <date>07/24/2015 10:42 AM </date>
    // <summary>ToDo entity contains properties for ToDo Items</summary>
    public class ToDo
    {
        /// <summary>
        /// Specifies sequence number of item.
        /// </summary>
        public int Index { get { return Controllers.ToDoController._todo.IndexOf(this); } }

        /// <summary>
        /// Specifies title for an item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Specifies detail about an item.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// Specifies state of item. It can be ACTIVE or DONE
        /// </summary>
        public string State { get; set; }
    }
}
