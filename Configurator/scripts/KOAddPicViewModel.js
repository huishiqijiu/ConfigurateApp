var KOAddPicViewModel = function (data) {

    var self = this;
    if (data != null) {
        ko.mapping.fromJS(data, { UpbodyItems: itemModelMapping, LowerbodyItems: itemModelMapping, FootItems: itemModelMapping, Design: designModelMapping}, self);
        selectedUpperbodyItem = new ItemModel();
        selectedLowerBodyItem = new ItemModel();
        selectedFootItem = new ItemModel();
    }
    console.log(selectedUpperbodyItem)
    self.ShowPic = function (selectedUpperbodyItem, selectedLowerBodyItem, selectedFootItem) {

    }
    self.AddPicture = function (selectedUpperbodyItem, selectedLowerBodyItem, selectedFootItem) {
        
    }
    };
    var itemModelMapping = {
        create: function (options) {
            return new ItemModel(options.data);
        }
    };
    var designModelMapping = {
        create: function (options) {
            return new FinalDesignModel(options.data);
        }
    }
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

        }
    };
    var FinalDesignModel = function (data) {

        var self = this;
        if (data != null) {
            ko.mapping.fromJS(data, {}, self);
        } else {
            self.Id = ko.observable();
            self.DesignCode = ko.observable();
            self.Image = ko.observable();
        }
        var newDesign;
        self.SaveDesign = function () {
            newDesign = new FinalDesignModel();
            newDesign.Id(0);
            newDesign.DesignCode($('#conbinedCode').text().replace(/\s+/g, ''));
            newDesign.Image($('#file').val());
            var obj = ko.mapping.toJSON(newDesign);
            $.ajax({
                url: "/Administration/SaveDesign",
                type: "Post",
                data: obj,
                contentType: "application/json",
                success: function (result) {
                    $('#uppItem').val("Choose...");
                    $('#lowItem').val("Choose...");
                    $('#footItem').val("Choose...");
                    $('#file').val("");
                    $('#message').val(result);
                }
            })
        }
        };
