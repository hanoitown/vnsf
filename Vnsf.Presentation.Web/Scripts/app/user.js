//$(function () {
//    var svc = new Vnsf.Service("api/users");

//    function Application(keys, data) {
//        var vm = this;
//        vm.isNew = ko.observable(!data);
//        data = data || {
//            id: 0,
//            name: "",
//            email: "",
//            allowLogin: false,
//            isVerified: false,
//            enabled: true
//        };
//        ko.mapping.fromJS(data, null, this);
//        this.signingKeys = ko.mapping.fromJS(keys);

//        Vnsf.util.addRequired(this, "name", "Name");
//        Vnsf.util.addRequired(this, "namespace", "Namespace");
//        Vnsf.util.addRequired(this, "audience", "Audience");
//        Vnsf.util.addRequired(this, "signingKeyId", "Signing Key");
//        Vnsf.util.addAnyErrors(this);

//        vm.menusEnabled = ko.computed(function () {
//            return !vm.isNew();
//        });

//        vm.editDescription = ko.computed(function () {
//            return vm.isNew() ? "New" : "Manage";
//        });

//        vm.rememberConsentDecisionEnabled = ko.computed(function () {
//            return vm.requireConsent();
//        });

//        vm.save = function () {
//            var data = ko.mapping.toJS(vm);
//            if (!data.requireConsent) {
//                data.rememberConsentDecision = false;
//            }
//            if (vm.isNew()) {
//                svc.post(data).then(function (data, status, xhr) {
//                    window.location = window.location + '#' + data.id;
//                    vm.isNew(false);
//                    vm.id(data.id);
//                });
//            }
//            else {
//                svc.put(data, vm.id());
//            }
//        };
//    }

//    var keysSvc = new as.Service("admin/Keys");
//    var kd = keysSvc.get();
//    var ad = null;

//    if (window.location.hash) {
//        var id = window.location.hash.substring(1);
//        ad = svc.get(id);
//    }

//    $.when(kd, ad).then(function (keyData, appData) {
//        var vm = new Application(keyData[0], appData && appData[0]);
//        ko.applyBindings(vm);
//    });
//});
