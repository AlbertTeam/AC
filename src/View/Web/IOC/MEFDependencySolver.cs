﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.IOC
{
    /// <summary>
    /// mvc Mef依赖注入
    /// </summary>
    public class MEFDependencySolver : IDependencyResolver
    {
        private readonly ComposablePartCatalog _catalog;
        private const string MefContainerKey = "MefContainerKey";

        public MEFDependencySolver(ComposablePartCatalog catalog)
        {
            _catalog = catalog;
        }

        public CompositionContainer Container
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(MefContainerKey))
                {
                    HttpContext.Current.Items.Add(MefContainerKey, new CompositionContainer(_catalog));
                }
                CompositionContainer container = (CompositionContainer)HttpContext.Current.Items[MefContainerKey];
                HttpContext.Current.Application["Container"] = container;
                return container;
            }
        }

        #region IDependencyResolver

        public object GetService(Type serviceType)
        {
            string contractName = AttributedModelServices.GetContractName(serviceType);
            try
            {
                return Container.GetExportedValueOrDefault<object>(contractName);
            }
            catch (Exception ex)
            {

                if (ex is System.Reflection.ReflectionTypeLoadException)
                {
                    var typeLoadException = ex as ReflectionTypeLoadException;
                    var loaderExceptions = typeLoadException.LoaderExceptions;
                    string message = string.Empty;
                    foreach (var item in loaderExceptions)
                    {
                        message += item.Message + ";";
                    }
                    throw new Exception(message);
                }
                throw;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.GetExportedValues<object>(serviceType.FullName);
        }
        #endregion
    }
}
