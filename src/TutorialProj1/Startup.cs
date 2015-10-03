using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Dnx.Runtime;

namespace TutorialProj1
{
    public interface IFoo {
        string GetFoo();
        string Connected();

    }
    public class Foo : IFoo
    {
        private MyConfig _config;
        public Foo(MyConfig conf)
        {
            _config = conf;
        }
        public string GetFoo()
        {
            return _config.SiteName;
        }
        int count;
        public Foo()
        {
           count = 0;
        }

        public string Connected()
        {
            return ""+count++;
        }


    }

    public class MyConfig
    {
        public string SiteName { get; set; }
        public string Owner { get; set; }
    }

    public class Startup
    {
        
        public Startup(IApplicationEnvironment env)
        {
            
            var builder = 
                new ConfigurationBuilder(env.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.Configuration}.json", false)
                .AddEnvironmentVariables()
                ;
            config = builder.Build();
        }
        public IConfigurationRoot config { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IFoo,Foo> ();
            //services.AddInstance<IFoo>(new Foo());
            services.AddTransient<IFoo, Foo>();
            //services.AddScoped<IFoo, Foo>();
            services.AddInstance(new MyConfig
            {
                SiteName = config["site:siteName"],
                Owner = config["site:owner"]
            });

            services.AddMvc(mvc =>
            {
                
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            //"{controller}/{action}"
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", 
                    "{controller=Home}/{action=Index}");
                ////routes.MapRoute("about",
                //    "{controller=About}/{action=About}");
            });
            //app.UseMiddleware<Middleware>();
            //app.Run(async (context) =>
            //{
            //    var foo = context.RequestServices.GetRequiredService<IFoo>();
            //    //var conf = context.RequestServices.GetRequiredService<MyConfig>();
            //    await context.Response.WriteAsync(foo.GetFoo());
            //});
        }
    }
}
