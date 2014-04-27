$(function () {
    var srv = new Vnsf.Service("api/grants");

    function Grants(list) {
        this.grants = ko.mapping.fromJS(list);
    }

    Grants.prototype.deleteGrant = function (item) {
        var vm = this;
        srv.delete(item.id()).then(function () {
            vm.grants.remove(item);
        });
    }

    srv.get().then(function (data) {
        var vm = new Grants(data);
        ko.applyBindings(vm);
    });
});