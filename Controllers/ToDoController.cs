using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi_openshift_source.Controllers
{

    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        /// <summary>
        /// Static todo list. Common for all
        /// </summary>
        internal static List<ToDo> _todo = new List<ToDo>();



        // GET: api/todo
        [HttpGet]
        public List<ToDo> Get()
        {
            return _todo;
        }

        // GET api/todo/5
        [HttpGet("{index}")]
        public ToDo Get(int index)
        {
            try { return _todo[index]; } catch (Exception) { return null; }
        }

        // POST api/post
        [HttpPost]
        public void Post([FromBody]string title, [FromBody]string detail)
        {
            _todo.Add(new ToDo()
            {
                Title = title,
                Detail = title
            });
        }

        // PUT api/put/5
        [HttpPut("{index}")]
        public void Put(int index, [FromBody]string title, [FromBody]string detail, [FromBody]string state)
        {
            _todo[index].Title = title;
            _todo[index].Detail = detail;
            if (state.ToLower() == "done")
                _todo[index].State = state;
        }

        // DELETE api/delete/5
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            _todo.RemoveAt(index);
        }
    }
}
