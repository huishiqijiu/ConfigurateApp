using Configurator.Services.IServices;
using Configurator.Services.ServiceModels;
using Configurator.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configurator.Controllers
{
    [Authorize]
    public class ConfiguratorController : Controller
    {

        IProductService _productService;
        IPartService _partService;
        IItemTypeService _typeService;
        IItemService _itemService;
        IUserService _userService;
        IOrderService _orderService;
        IFinalDesignService _finalDesignService;
        public ConfiguratorController(IProductService productService, IPartService partService, IItemTypeService typeService,
            IItemService itemService, IUserService userService, IOrderService orderService, IFinalDesignService finalDesignService)
        {
            _productService = productService;
            _partService = partService;
            _typeService = typeService;
            _itemService = itemService;
            _userService = userService;
            _orderService = orderService;
            _finalDesignService = finalDesignService;
        }
        // GET: Configurator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var model = new AdminAddNewViewModel { Products = _productService.GetAllProducts() };
            model.UserId = user.Id;
            return View(model);
        }
        public ActionResult Parts(int id)
        {
            var model = new AdminPartsViewModel { Parts = _partService.GetAllParts(id), ProductId = id, ProductName = _productService.GetProductById(id).Name };
            return View(model);
        }
        public ActionResult ItemTypes(int id)
        {
            var model = new AdminItemTypesViewModel
            {
                ItemTypes = _typeService.GetAllItemTypes(id),
                PartId = id,
                PartName = _partService.GetPartById(id).Name,
                ProductName = _productService.GetProductById(_partService.GetPartById(id).ProductId).Name,
                ProductId = _partService.GetPartById(id).ProductId
            };
            return View(model);
        }
        public ActionResult Items(int id)
        {
            var model = new AdminItemsViewModel
            {
                Items = _itemService.GetAllItems(id),
                ItemTypeId = id,
                ItemTypeName = _typeService.GetItemTypeById(id).Name,
                PartName = _partService.GetPartById(_typeService.GetItemTypeById(id).PartId).Name,
                ProductName = _productService.GetProductById(_partService.GetPartById(_typeService.GetItemTypeById(id).PartId).ProductId).Name,
                PartId = _typeService.GetItemTypeById(id).PartId,
                ProductId = _partService.GetPartById(_typeService.GetItemTypeById(id).PartId).ProductId
            };

            return View(model);
        }
        public string SaveOrder(OrderModel o)
        {
            _orderService.SaveOrder(o);
            return "Order Saved";
        }
        public ActionResult MyOrders()
        {
            var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            var model = new OrdersViewModel { UsersOrders = _orderService.GetAllOrders(user.Id) };
            return View(model);
        }

        public string GetImgByteArray(string code)
        {
            Image img;
            var path = _finalDesignService.GetImagePath(code);
            if (path.Length > 0)
            {
                img = Image.FromFile(path);
                var ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return Convert.ToBase64String(ms.ToArray());
            }
            else
                return "";

        }
    }
}