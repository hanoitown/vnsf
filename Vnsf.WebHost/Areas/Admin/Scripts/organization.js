$(function () {
    var svc = new Vnsf.Service("api/organizations");

    function Organization(data) {

        var vm = this;
        vm.isNew = ko.observable(!data);
        data = data || {
            id: "",
            name: "",
            description: "",
            shortName: "",
            address: "",
            phone: "",
            email: "",
            website: ""
        };

        ko.mapping.fromJS(data, null, this);
        //this.contacts = ko.mapping.fromJS(contact);
        //as.util.addAnyErrors(this);

        vm.menusEnabled = ko.computed(function () {
            return !vm.isNew();
        });

        vm.editDescription = ko.computed(function () {
            return vm.isNew() ? "New" : "Manage";
        });

        vm.save = function () {
            var data = ko.mapping.toJS(vm);

            if (vm.isNew()) {
                svc.post(data).then(function (data, status, xhr) {
                    window.location = window.location + '#' + data.id;
                    vm.isNew(false);
                    vm.id(data.id);
                });
            }
            else {
                svc.put(data, vm.id());
            }
        };
    }
    var ad = null;

    if (window.location.hash) {
        var id = window.location.hash.substring(1);
        ad = svc.get(id);
    }

    $.when(ad).then(function (appData) {
        var vm = new Organization(appData);
        ko.applyBindings(vm);
    });
});
