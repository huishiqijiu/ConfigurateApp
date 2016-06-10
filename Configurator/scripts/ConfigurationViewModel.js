var ConfigurationViewModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { Products: productModelMapping }, self);
    } else {
        self.Products = ko.observableArray();


    }
};
var productModelMapping = {
    create: function (options) {
        return new ProductModel(options.data);
    }
};
var ProductModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { Parts: partModelMapping }, self);
    } else {
        self.Id = ko.observable();
        self.Name = ko.observable();
    }
    self.ShowParts = function () {
        console.log(self.Id());
        location.href = url + '/' + self.Id();
    }
    self.Delete = function () {
        var obj = ko.mapping.toJSON(self);
        $.ajax({
            url: "/Administration/DeleteProduct",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function () {
                
                configurationViewModel.Products.remove(self);

            }
        })
    }
    
};
var partModelMapping = {
    create: function (options) {
        return new PartModel(options.data);
    }
};
var PartModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { Items: itemModelMapping }, self);
    } else {
        self.Id = ko.observable();
        self.Name = ko.observable();
    }
};
var itemModelMapping = {
    create: function (options) {
        return new ItemModel(options.data);
    }
};
var ItemModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, {}, self);
    } else {
        self.Id = ko.observable();
        self.Name = ko.observable();
        self.ItemTypeId = ko.observable();
        self.Price = ko.observable();
        self.Code = ko.observable();
        self.DeliveryTime = ko.observable();
    }
    self.saveItem = function () {
        selectedItemsViewModel.SelectedItems.push(self);
        //selectedItems.push(self);
        //$(self).hide();
        //$(this).parent().siblings().child("input").css("display", "none");
        var styleCode = self.Code().charAt(4);
        var partCode = self.Code().charAt(2);
        $('.itemCode').each(function () {
            if ($(this).text().charAt(4) != styleCode) {
                $(this).siblings("input").css("display", "none");
            }
            else if ($(this).text().charAt(4) == styleCode && $(this).text().charAt(2) == partCode) {
                $(this).siblings("input").css("display", "none");
            }
            else
                return

        })
        selectedItems.push(self);
    }
};
var NewProductModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    var newProduct;
    self.Save = function (newProduct) {
        newProduct = new ProductModel();
        newProduct.Id(0);
        newProduct.Name(self.Name());
        var obj = ko.mapping.toJSON(newProduct);
        $.ajax({
            url: "/Administration/SaveProduct",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function (result) {
                $('#newProduct').val("");
                newProduct.Id = ko.observable(result);
                configurationViewModel.Products.push(newProduct);
               
            }
        })
    }
}
var SelectedItemsViewModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { SelectedItems: itemModelMapping }, self);
    } else {

        self.SelectedItems = ko.observableArray();
    }
    self.saveOrder = function () {
        if ($('#selectedItems li').length > 0) {
            newOrder = new OrderModel();
            newOrder.Id = 0;
            newOrder.ProductCode = "";
            newOrder.TotalPrice = 0;

            console.log(selectedItems.length);
            var dtimes = [];
            for (i = 0; i < selectedItems.length; i++) {
                newOrder.ProductCode += selectedItems[i].Code() + selectedItems[i].Id();
                newOrder.TotalPrice += selectedItems[i].Price();

                dtimes.push(selectedItems[i].DeliveryTime().split('(')[1].split(')')[0]);
            }
            var temp = 0;
            for (var i = 0; i < dtimes.length; i++) {
                if (temp < parseInt(dtimes[i])) {
                    temp = parseInt(dtimes[i]);
                }
            }
            newOrder.ProductCode = newOrder.ProductCode.replace(/\s+/g, '');
            newOrder.DeliverDate = new Date(temp);
            console.log(newOrder.DeliverDate);
            newOrder.UserId = $('#userID').val();
            var obj = ko.mapping.toJSON(newOrder);
            $.ajax({
                url: "SaveOrder",
                type: "Post",
                data: obj,
                contentType: "application/json",
                success: function (result) {
                    $('#showMsg').text(result);
                    location.href = orderUrl;
                }
            })
        }
        else
            alert('Can not save order with no item selected.');

    }
};

var OrderModel = function () {
    var self = this;

}