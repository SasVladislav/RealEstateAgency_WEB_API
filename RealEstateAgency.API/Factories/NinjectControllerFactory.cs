using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web.Http.Dispatcher;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace RealEstateAgency.API.Factories
{
    public class NinjectControllerFactory:IHttpControllerActivator
    {
        private IKernel Kernel { get; }

        public NinjectControllerFactory(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)Kernel.Get(controllerType);
            request.RegisterForDispose(new Release(()=>Kernel.Release(controller)));
            return controller;
        }


    }
    internal class Release : IDisposable
    {
        private readonly Action _release;

        public Release(Action release)
        {
            _release = release;
        }

        public void Dispose()
        {
            _release();
        }
    }
}