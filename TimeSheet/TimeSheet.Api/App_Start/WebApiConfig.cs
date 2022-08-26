using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using TimeSheet.Core.Repositories;
using TimeSheet.Core.Services;
using TimeSheet.Repositories;
using TimeSheet.Repository.Repositories;

namespace TimeSheet.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            config.EnableCors(corsAttr);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()); 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); 
            
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            builder.RegisterType<ClientService>().As<IClientService>();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();

            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();

            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();

            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();

            builder.RegisterType<TeamMemberService>().As<ITeamMemberService>();
            builder.RegisterType<TeamMemberRepository>().As<ITeamMemberRepository>();

            builder.RegisterType<TimeSheetEntryService>().As<ITimeSheetEntryService>();
            builder.RegisterType<TimeSheetEntryRepository>().As<ITimeSheetEntryRepository>();

            builder.RegisterType<WorkService>().As<IWorkService>();
            builder.RegisterType<WorkRepository>().As<IWorkRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); 
        }
    }
}
