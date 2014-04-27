$(function () {
    var hash = window.location.hash.substring(1);
    var idx = hash.indexOf("v");
    var itemID = hash.substring(0, idx);
    var parentID = hash.substring(idx + 1);

    var orgSvc = new Vnsf.Service("api/organizations");
    var svc = new Vnsf.Service("api/grants/" + parentID + "/budFindByIds/");

    var org = orgSvc.get();
    var data = null;

    //modify
    if (itemID)
        data = svc.get(itemID);


    $.when(data, org).then(function (itemData, orgData) {
        var vm = new Item(itemData && itemData[0], orgData && orgData[0]);
        ko.applyBindings(vm);
    });



    function Item(data, orgs) {
        var vm = this;
        vm.isNew = ko.observable(!data);

        data = data || {
            id: 0,
            name: "",
            description: "",
            issuer: "",
            financialYear: 0,
            amount: 0,
            supplierId: ""
        };

        ko.mapping.fromJS(data, null, this);
        this.organizations = ko.mapping.fromJS(orgs);

        vm.parentID = ko.computed(function () {
            return parentID;
        });

        //vm.nameEnabled = ko.computed(function () {
        //    return vm.isNew();
        //});

        //vm.editDescription = ko.computed(function () {
        //    return vm.isNew() ? "New" : "Manage";
        //});
        vm.menusEnabled = ko.computed(function () {
            return !vm.isNew();
        });

        //as.util.addRequired(this, "name", "Name");
        //as.util.addRequired(this, "displayName", "Display Name");
        //as.util.addAnyErrors(this);

        vm.save = function () {
            if (vm.isNew()) {
                svc.post(ko.mapping.toJS(vm)).then(function (data, status, xhr) {
                    scopeID = data.id;
                    var url = window.location.toString();
                    url = url.substring(0, url.indexOf('#'));
                    url += "#" + scopeID;
                    window.location = url;

                    vm.id(data.id);
                    vm.isNew(false);

                    svc = new as.Service("admin/Scopes/" + scopeID);
                    scopeClientSvc = new as.Service("admin/ScopeClients/" + scopeID);
                    scopeClientSvc.get().then(function (data) {
                        ko.applyBindings(new ScopeClients(data), document.getElementById("scopeClients"));
                    });
                });
            }
            else {
                svc.put(ko.mapping.toJS(vm), itemID);
            }
        };
    };

    function ScopeClients(list) {
        ko.mapping.fromJS(list, null, this);
        this.appID = ko.computed(function () {
            return appID;
        });
        this.scopeID = ko.computed(function () {
            return scopeID;
        });
    }

    ScopeClients.prototype.addClient = function (item) {
        var vm = this;
        scopeClientSvc.put(null, item.clientId()).then(function () {
            vm.otherClients.remove(item);
            vm.allowedClients.push(item);
        });
    };

    ScopeClients.prototype.deleteClient = function (item) {
        var vm = this;
        scopeClientSvc.delete(item.clientId()).then(function () {
            vm.allowedClients.remove(item);
            vm.otherClients.push(item);
        });
    };
});
