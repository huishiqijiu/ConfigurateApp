var KOItemViewModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { Items: itemModelMapping }, self);
    } else {
        self.Items = ko.observableArray();
        self.ItemTypeId = ko.observable();
        self.ItemTypeName = ko.observable();
        self.PartName = ko.observable();
        self.ProductName = ko.observable();
        self.PartId = ko.observable();
        self.ProductId = ko.observable();
    }
    self.ShowItemTypes = function () {
        location.href = urlItemType + '/' + self.PartId();
    }
    self.ShowParts = function () {
        location.href = urlPart + '/' + self.ProductId();
    }
    self.ShowProducts = function () {
        location.href = urlProduct;
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
        ko.mapping.fromJS(data, { }, self);
    } else {
        self.Id = ko.observable();
        self.Name = ko.observable();
        self.ItemTypeId = ko.observable();
        self.Price = ko.observable();
        self.Code = ko.observable();
        self.DeliveryTime = ko.observable();
    }
    self.saveItem = function () {

    }
    self.Delete = function () {
        var obj = ko.mapping.toJSON(self);
        $.ajax({
            url: "/Administration/DeleteItem",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function () {
                koItemViewModel.Items.remove(self);
            }
        })
    }
};
var NewItemModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.ItemTypeId = ko.observable();
    self.Price = ko.observable();
    self.Code = ko.observable($('#productName').text() + $('#partName').text() + $('#itemTypeName').text() );
    self.DeliveryTime = ko.observable();
    var newItem;
    self.Save = function (newItem) {
        newItem = new ItemModel();
        newItem.Id(0);
        newItem.Name(self.Name());
        newItem.ItemTypeId($('#itemTypeId').text());
        newItem.Price(self.Price());
        newItem.Code(self.Code());
        console.log(newItem.Code());
        newItem.DeliveryTime(self.DeliveryTime());

        console.log(newItem.ItemTypeId());
        var obj = ko.mapping.toJSON(newItem);
        $.ajax({
            url: "/Administration/SaveItem",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function (result) {
                $('#code').val("");
                $('#deliveryTime').val("");
                $('#price').val("");
                $('#name').val("");
                newItem.Id = ko.observable(result);
                koItemViewModel.Items.push(newItem);
                $('#myModal').modal('hide');
            }
        })
    }
}