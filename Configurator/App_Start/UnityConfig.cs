using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Configurator.Services.IServices;
using Configurator.Services.Services;
using Configurator.DataLayer.IRepository;
using Configurator.DataLayer.Repository;
using Configurator.Services.IServices.IAccountService;
using Configurator.Services.Services.AccountService;
using Configurator.Services.ServiceModels;

namespace Configurator.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();
           
            container.RegisterType<IFormsAuthenticationAdapter, FormAuthenticationAdapter>();
            container.RegisterType<IUserAuthenticationService, UserAuthenticationService>();

            //container.RegisterType<IMailService, MailService>();// (new InjectionConstructor(ConfigurationManager.AppSettings["smtpServer"], Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]), ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]));
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IPartService, PartService>();
            container.RegisterType<IPartRepository, PartRepository>();
            container.RegisterType<IItemTypeService, ItemTypeService>();
            container.RegisterType<IItemTypeRepository, ItemTypeRepository>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemRepository, ItemRepository>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IOrderRepository, OrderRepository>();
            container.RegisterType<IFinalDesignService, FinalDesignService>();
            container.RegisterType<IFinalDesignRepository, FinalDesignRepository>();
            container.RegisterType<IMailService, MailService>();

        }
    }
}
