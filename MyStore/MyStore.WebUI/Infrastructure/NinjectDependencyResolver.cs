using Moq;
using MyStore.Domain.Abstract;
using MyStore.Domain.Concrete;
using MyStore.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>(); 
            //mock.Setup(m => m.Products).
            //    Returns(new List<Product> {
            //    new Product { Name = "Football", Price = 25 },
            //    new Product { Name = "Surf board", Price = 179 }, 
            //    new Product { Name = "Running shoes", Price = 95 }
            //    }); 
            
            var emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false"),
                FileLocation = System.AppDomain.CurrentDomain.BaseDirectory + "emails"
            };

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>()
                .WithConstructorArgument("settings", emailSettings);

            //kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            //    .WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IOrderProcessor>().To<LiteDBOrderProcessor>();


            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            
        }
    }
}