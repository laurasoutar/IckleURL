using IckleUrl.Service;
using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;


namespace IckleUrl
{
	public static class UnityConfig
	{
		private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
		{
			var container = new UnityContainer();
			RegisterTypes(container);
			return container;
		});

		public static IUnityContainer GetConfiguredContainer()
		{
			return container.Value;
		}

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IIckleUrlService, IckleUrlService>();
        }
    }
}