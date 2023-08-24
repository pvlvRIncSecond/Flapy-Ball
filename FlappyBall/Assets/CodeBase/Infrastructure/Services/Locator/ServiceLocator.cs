using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services.Locator
{
    public class ServiceLocator
    {
        public static ServiceLocator Container => _instance ??= new ServiceLocator();
        private static ServiceLocator _instance;
        private static Dictionary<Type, IService> _services;

        private ServiceLocator() => 
            _services = new Dictionary<Type, IService>();

        public void RegisterSingle<TService>(TService service) where TService : IService => 
            _services[typeof(TService)] = service;

        public TService Single<TService>() where TService : class, IService => 
            _services[typeof(TService)] as TService;
    }
}