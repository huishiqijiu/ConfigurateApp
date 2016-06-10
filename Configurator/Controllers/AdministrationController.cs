using Configurator.Services.IServices;
using Configurator.Services.IServices.IAccountService;
using Configurator.Services.ServiceModels;
using Configurator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Configurator.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        IUserService _userService;
        IProductService _productService;
        IPartService _partService;
        IItemTypeService _typeService;
        IItemService _itemService;
        IOrderService _orderService;
        IFinalDesignService _finalDesignService;
        IMailService _mailService;


        public AdministrationController(IProductService productService, IPartService partService, IItemTypeService typeService,
            IItemService itemService, IUserService userService, IOrderService orderService, IFinalDesignService finalDesignService, IMailService mailService)
        {
            _productService = productService;
            _partService = partService;
            _typeService = typeService;
            _itemService = itemService;
            _userService = userService;
            _orderService = orderService;
            _finalDesignService = finalDesignService;
            _mailService = mailService;
        }
        // GET: Administration
        public ActionResult Index()
        {
            var user = _userService.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
            if (user.IsAdmin == true)
            {

                return View();
            }
            else
                return View("RedirectToRegiIfNotAdmin");

        }
        public ActionResult AddNewProduct()
        {
            var model = new AdminAddNewViewModel { Products = _productService.GetAllProducts() };
            return View(model);
        }
        [HttpPost]
        public int SaveProduct(ProductModel model)
        {
            return _productService.SaveProduct(model);
        }
        [HttpPost]
        public void DeleteProduct(ProductModel model)
        {
            _productService.DeleteProduct(model.Id);
        }
        [HttpPost]
        public void DeletePart(PartModel model)
        {
            _partService.DeletePart(model.Id);
        }
        [HttpPost]
        public void DeleteType(ItemTypeModel model)
        {
            _typeService.DeleteType(model.Id);
        }
        [HttpPost]
        public void DeleteItem(ItemModel model)
        {
            _itemService.DeleteItem(model.Id);
        }

        public ActionResult AddNewPart(int id)
        {
            var model = new AdminPartsViewModel { Parts = _partService.GetAllParts(id), /*CodeProd = _productService.GetProductById(id).Name[0].ToString(),*/ ProductId=id };
            return View(model);
        }
        [HttpPost]
        public int SavePart(PartModel model)
        {
            return _partService.SavePart(model);
        }
        public ActionResult AddNewItemType(int id)
        {
            var model = new AdminItemTypesViewModel { ItemTypes = _typeService.GetAllItemTypes(id), PartId = id };
            return View(model);

        }
        [HttpPost]
        public int SaveItemType(ItemTypeModel model)
        {
            return _typeService.SaveItemType(model);
        }
        public ActionResult AddNewItem(int id)
        {
            var model = new AdminItemsViewModel
            {
                Items = _itemService.GetAllItems(id),
                ItemTypeId = id,
                ItemTypeName = _typeService.GetItemTypeById(id).Name[0].ToString() + "_",
                PartId = _typeService.GetItemTypeById(id).PartId,
                PartName = _partService.GetPartById(_typeService.GetItemTypeById(id).PartId).Name[0].ToString() + "_",
                ProductId = _partService.GetPartById(_typeService.GetItemTypeById(id).PartId).ProductId,
                ProductName = _productService.GetProductById(_partService.GetPartById(_typeService.GetItemTypeById(id).PartId).ProductId).Name[0].ToString() + "_"
            };
            return View(model);
        }
        public int SaveItem(ItemModel model)
        {
            return _itemService.SaveItem(model);
        }
        public ActionResult Orders()
        {
            IList<OrderModel> orders = _orderService.GetOrders();
            var model = new OrdersViewModel { AllOrders = orders };
            foreach (var o in orders)
            {
                if(o.DeliverDate < DateTime.Today)
                {
                    
                    _mailService.SendMailAboutDelivery(o);
                }
            }
            return View(model);
        }
        //public string SendEmail()
        //{
        //    var model = new OrdersViewModel { AllOrders = _orderService.GetOrders() };
        //    return View(model);
        //}
        public ActionResult AddPictures()
        {
            var model = new AdminAddPicViewModel { UpbodyItems = _itemService.GetItemsByCode("_U_"), LowerBodyItems = _itemService.GetItemsByCode("_L_"), FootItems = _itemService.GetItemsByCode("_F_") };
            return View(model);
        }
        [HttpPost]
        public ActionResult FileUpload(AdminAddPicViewModel model, HttpPostedFileBase file)
        {
            var code = model.Design.DesignCode;
            if (!_finalDesignService.HasImg(code))
            {
                if (file != null && file.ContentLength > 0)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/App_Data/uploads"), pic);
                    file.SaveAs(path);
                    FinalDesignModel design = new FinalDesignModel();
                    design.DesignCode = model.Design.DesignCode;
                    design.Image = path;
                    _finalDesignService.SaveFinalDesign(design);
                }
                return View("Index");
            }
            else return View("PictureExists");


        }
        [HttpPost]
        public string SaveDesign(FinalDesignModel model)
        {
            _finalDesignService.SaveFinalDesign(model);
            return "Design Saved with an Image";
        }


    }
}