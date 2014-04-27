$(function () {
    var srv = new Vnsf.Service("api/organizations");

    function Orgs(list) {
        this.orgs = ko.mapping.fromJS(list);
    }

    Orgs.prototype.deleteOrg = function (item) {
        var vm = this;
        srv.delete(item.id()).then(function () {
            vm.orgs.remove(item);
        });
    }

    srv.get().then(function (data) {
        var vm = new Orgs(data);
        ko.applyBindings(vm);
    });
});