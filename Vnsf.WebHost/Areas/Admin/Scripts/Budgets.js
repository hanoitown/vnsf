$(function () {
    var parentID = window.location.hash.substring(1);
    var svc = new Vnsf.Service("api/grants/" + parentID + "/budFindByIds");


    svc.get().then(function (data) {
        var vm = new Items(data);
        ko.applyBindings(vm);
    });

    function Items(list) {
        this.parentID = ko.observable(parentID);
        this.items = ko.mapping.fromJS(list);
        this.newItem = ko.mapping.fromJS({
            name: "",
            description: "",
            issuer: "",
            year: 0,
            amount: 0
        });

        //as.util.addRequired(this.newScope, "name", "Name");
        //as.util.addRequired(this.newScope, "description", "Description");
        //as.util.addAnyErrors(this.newScope);
    }
    Items.prototype.addItem = function () {
        var vm = this;
        svc.post(ko.mapping.toJS(vm.newItem), parentID).then(function (data) {
            vm.items.push(ko.mapping.fromJS(data));
            vm.newItem.name("");
            vm.newItem.description("");
        });
    };

    Items.prototype.deleteItem = function (item) {
        var vm = this;
        scopesSvc.delete(item.id()).then(function () {
            vm.items.remove(item);
        });
    }
});
