namespace PaintDotNet.ComponentModel
{
    using PaintDotNet.Diagnostics;
    using System;

    public sealed class ServiceProviderProxy : IServiceProvider
    {
        private readonly IServiceProvider services;

        public ServiceProviderProxy(IServiceProvider services)
        {
            Validate.IsNotNull<IServiceProvider>(services, "services");
            this.services = services;
        }

        public object GetService(Type serviceType) => 
            this.services.GetService(serviceType);
    }
}

