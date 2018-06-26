using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;

namespace PL.Infastructures
{
    internal class NinjectDependencyResolver : IDependencyResolver
    {
        private StandardKernel kernel;

        public NinjectDependencyResolver(StandardKernel kernel)
        {
            this.kernel = kernel;
        }

        object IDependencyResolver.GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType) => kernel.GetAll(serviceType, new IParameter[0]);
    }
}