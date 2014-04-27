$(function () {
    var svc = new Vnsf.Service("api/users");

    function userAccounts(list) {
        this.users = ko.mapping.fromJS(list);
    }

    userAccounts.prototype.deleteApp = function (item) {
        var vm = this;
        alert("deleted");
        svc.delete(item.id()).then(function () {
            vm.users.remove(item);
        });
    };

    svc.get().then(function (data) {
        var vm = new userAccounts(data);
        ko.applyBindings(vm);
    });

});