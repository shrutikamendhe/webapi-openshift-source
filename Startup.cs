using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;

namespace webapi_openshift_source
{
    // <copyright file="Startup.cs" company="Click2Cloud">
    // Copyright (c) 2015 All Rights Reserved
    // </copyright>
    // <author>Shrutika Mendhe</author>
    // <date>07/24/2015 10:42 AM </date>
    // <summary>This is entry point for an API</summary>
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            app.UseMvc();

            //Add dummy items in todo list
            if (Controllers.ToDoController._todo == null || Controllers.ToDoController._todo.Count == 0)
            {
                Controllers.ToDoController._todo = new List<ToDo>();
                Controllers.ToDoController._todo.Add(new ToDo() { Title = "Task 1", Detail = "My top 1 priority task.", State = "ACTIVE" });
                Controllers.ToDoController._todo.Add(new ToDo() { Title = "Task 2", Detail = "My top 2 priority task.", State = "ACTIVE" });
                Controllers.ToDoController._todo.Add(new ToDo() { Title = "Task 2", Detail = "My top 3 priority task.", State = "DONE" });
            }
        }
    }
}
