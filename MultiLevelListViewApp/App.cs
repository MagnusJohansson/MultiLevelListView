using Microsoft.Practices.Unity;
using MultiLevelListViewApp.Models;
using System;

namespace MultiLevelListViewApp
{
    public static class App
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if (App._container == null)
                {
                    App._container = new UnityContainer();
                    UnityContainerExtensions.RegisterType<IDataProvider, DataProvider>(App._container, Array.Empty<InjectionMember>());
                }
                return App._container;
            }
        }
    }
}