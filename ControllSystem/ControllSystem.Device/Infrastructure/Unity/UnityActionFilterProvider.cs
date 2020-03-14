using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ControlSystem.WebApi.Device.Infrastructure.Unity
{
    public class UnityActionFilterProvider
        : System.Web.Http.Filters.ActionDescriptorFilterProvider,
          System.Web.Http.Filters.IFilterProvider
    {
        private readonly IUnityContainer _container;
        private readonly ActionDescriptorFilterProvider _defaultProvider = new ActionDescriptorFilterProvider();

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="container"></param>
        public UnityActionFilterProvider(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Builds actions filters using unity container
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration,
            HttpActionDescriptor actionDescriptor)
        {
            var attributes = _defaultProvider.GetFilters(configuration, actionDescriptor);

            foreach (var attr in attributes)
            {
                _container.BuildUp(attr.Instance.GetType(), attr.Instance);
            }

            return attributes;
        }
    }
}
