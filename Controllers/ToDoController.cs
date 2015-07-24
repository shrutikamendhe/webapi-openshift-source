using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Web.Http;

namespace webapi_openshift_source.Controllers
{

    // <copyright file="ToDoController.cs" company="Click2Cloud">
    // Copyright (c) 2015 All Rights Reserved
    // </copyright>
    // <author>Shrutika Mendhe</author>
    // <date>07/24/2015 10:42 AM </date>
    // <summary>The controller for ToDo</summary>
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        /// <summary>
        /// The static object of ToDo List. This object is common for all request
        /// </summary>
        internal static List<ToDo> _todo = new List<ToDo>();

        /// <summary>
        /// Get all items in todo list object.
        /// GET: api/todo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ToDo> Get()
        {
            return _todo;
        }

        /// <summary>
        /// Add item in todo list object.
        /// POST api/todo
        /// </summary>
        /// <param name="toDo">Send item in query string of request</param>
        [HttpPost]
        public void Post([FromUri]ToDo toDo)
        {
            _todo.Add(toDo);
        }

        /// <summary>
        /// Update state of an item in todo list object.
        /// PUT api/put/5
        /// </summary>
        /// <param name="index">Index of an item</param>
        /// <param name="state">state either ACTIVE or DONE</param>
        [HttpPut("{index}")]
        public void Put(int index, [FromUri]string state)
        {
            _todo[index].State = state.ToUpper();
        }

        /// <summary>
        /// Delete perticualr item from todo list object
        /// DELETE api/delete/5
        /// </summary>
        /// <param name="index">Index of an item</param>
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            _todo.RemoveAt(index);
        }
    }
}
