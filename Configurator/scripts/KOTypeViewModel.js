var KOTypeViewModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { ItemTypes: itemTypeModelMapping }, self);
    } else {
        self.ItemTypes = ko.observableArray();
        self.PartId = ko.observable();
        self.PartName = ko.observable();
        self.ProductName = ko.observable();
        self.ProductId = ko.observable();
    }
    self.ShowParts = function () {
        location.href = urlPart + '/' + self.ProductId();

    }
    self.ShowProducts = function () {
        location.href = urlProduct;
    }
};
var itemTypeModelMapping = {
    create: function (options) {
        return new ItemTypeModel(options.data);
    }
};
var ItemTypeModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, {  }, self);
    } else {
        self.Id = ko.observable();
        self.Name = ko.observable();
        self.PartId = ko.observable();
    }
    self.ShowItems = function () {       
        location.href = url + '/' + self.Id();       
    }
    self.Delete = function () {
        var obj = ko.mapping.toJSON(self);
        $.ajax({
            url: "/Administration/DeleteType",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function () {
                koTypeViewModel.ItemTypes.remove(self);
            }
        })
    }
};

var NewItemTypeModel = function () {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.PartId = ko.observable();
    var newItemType;
    self.Save = function (newItemType) {
        newItemType = new ItemTypeModel();
        newItemType.Id(0);
        newItemType.Name(self.Name());
        newItemType.PartId($('#partId').text());
        console.log(newItemType.PartId());
        var obj = ko.mapping.toJSON(newItemType);
        $.ajax({
            url: "/Administration/SaveItemType",
            type: "Post",
            data: obj,
            contentType: "application/json",
            success: function (result) {
                $('#newItemType').val("");
                newItemType.Id = ko.observable(result);
                koTypeViewModel.ItemTypes.push(newItemType);
            }
        })
    }
}