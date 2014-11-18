using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Services
{
    public class ServiceLocator : IServiceLocator 
    {

        private static IServiceLocator _default;
        public static IServiceLocator Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new ServiceLocator();
                }
                return _default;
            }
            set
            {
                if (_default != value)
                    _default = value;
            }
        }

        private ServiceLocator() { }

        /// <summary>
        /// Collection of Services
        /// </summary>
        private static Dictionary<Type, ServiceInfo> services = new Dictionary<Type, ServiceInfo>();

        /// <summary>
        /// Register a Service
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplemention"></typeparam>
        /// <remarks>Lazy Loading registration</remarks>
        public void Register<TInterface, TImplemention>() where TImplemention : TInterface
        {
            services.Add(typeof(TInterface), new ServiceInfo(typeof(TImplemention)));
        }

        /// <summary>
        ///  Register a Service
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="serviceImplementation"></param>
        /// <remarks>Eager Loading registration</remarks>
        public void Register<TInterface, TImplementation>(TImplementation serviceImplementation) where TImplementation : TInterface
        {
            services.Add(typeof(TInterface), new ServiceInfo(serviceImplementation));
        }

        /// <summary>
        /// Get the Service
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public TInterface Resolve<TInterface>()
        {
            return (TInterface)services[typeof(TInterface)].ServiceImplementation;
        }

        #region Service Information
        class ServiceInfo
        {
            #region Fields

            /// <summary>
            /// Service Interface Type
            /// </summary>
            private Type serviceImplementationType;

            /// <summary>
            /// Service Instance
            /// </summary>
            private object serviceImplementation;
            #endregion

            #region Properties

            /// <summary>
            /// Service Instance
            /// </summary>
            public object ServiceImplementation
            {
                get
                {
                    if (serviceImplementation == null)
                    {
                        serviceImplementation = CreateInstance(serviceImplementationType);
                    }
                    return serviceImplementation;
                }
            }

            #endregion

            #region Methods

            /// <summary>
            /// Constructor for Lazy Loading
            /// </summary>
            /// <param name="serviceImplementationType"></param>
            public ServiceInfo(Type serviceImplementationType)
            {
                this.serviceImplementationType = serviceImplementationType;
            }

            /// <summary>
            /// Constructor for Eager Loading
            /// </summary>
            /// <param name="serviceImplementation"></param>
            public ServiceInfo(object serviceImplementation)
            {
                this.serviceImplementation = serviceImplementation;
            }

            /// <summary>
            /// Create Instance of Service
            /// </summary>
            /// <param name="type"></param>
            /// <returns></returns>
            private static object CreateInstance(Type type)
            {
                if (services.ContainsKey(type))
                {
                    return services[type].ServiceImplementation;
                }

                ConstructorInfo ctor = type.GetConstructors().First();

                var parameters =
                    from parameter in ctor.GetParameters()
                    select CreateInstance(parameter.ParameterType);

                return Activator.CreateInstance(type, parameters.ToArray());
            }

            #endregion
        }
        #endregion
    }


}
