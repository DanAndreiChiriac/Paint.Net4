namespace PaintDotNet
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ServiceProviderExtensions
    {
        public static void AssertService<TService>(this IServiceProvider serviceProvider) where TService: class
        {
            if (serviceProvider.GetService<TService>() == null)
            {
                ExceptionUtil.ThrowInvalidOperationException();
            }
        }

        public static TService GetService<TService>(this IServiceProvider serviceProvider) where TService: class
        {
            Type serviceType = typeof(TService);
            return (serviceProvider.GetService(serviceType) as TService);
        }
    }
}

