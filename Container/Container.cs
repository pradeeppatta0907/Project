using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace DeveloperSample.Container
{
    public class Container
    {

        private class Registration
        {
            public Type ImplementationType { get; set; } = null!;
            public object SingletonInstance { get; set; }
            public bool IsSingleton { get; set; }
        }

        private readonly ConcurrentDictionary<Type, Registration> _bindings = new();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new ArgumentException($"{implementationType} does not implement {interfaceType}");

            var isSingleton = implementationType.GetCustomAttribute<SingletonAttribute>() != null;

            _bindings[interfaceType] = new Registration
            {
                ImplementationType = implementationType,
                IsSingleton = isSingleton
            };
        }
        public T Get<T>()
        {
            var type = typeof(T);
            if (!_bindings.TryGetValue(type, out var reg))
                throw new InvalidOperationException($"Type {type} has not been bound.");

            if (reg.IsSingleton)
            {
                if (reg.SingletonInstance == null)
                    reg.SingletonInstance = Activator.CreateInstance(reg.ImplementationType)!;
                return (T)reg.SingletonInstance;
            }

            return (T)Activator.CreateInstance(reg.ImplementationType)!;
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : Attribute { }
}
