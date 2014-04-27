$(function () {
    var svc = new Vnsf.Service("api/grants");
    var upload = new Vnsf.Service("api/grants/upload")

    function Grant(keys, data) {

        var vm = this;
        vm.isNew = ko.observable(!data);
        data = data || {
            id: "",
            code: "",
            name: "",
            description: "",
            total: 0,
            maxAward: 0,
            maxDuration: 0
        };

        ko.mapping.fromJS(data, null, this);
        //this.signingKeys = ko.mapping.fromJS(keys);
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
                //upload.post(data)
                svc.put(data, vm.id());
            }
        };
    }

    var keysSvc = new Vnsf.Service("api/grants");
    var kd = keysSvc.get();
    var ad = null;

    if (window.location.hash) {
        var id = window.location.hash.substring(1);
        ad = svc.get(id);
    }

    $.when(kd, ad).then(function (keyData, appData) {
        var vm = new Grant(keyData[0], appData && appData[0]);
        ko.applyBindings(vm);
    });
});
