
(function (vn) {

    var wizard = function () {
        var vm = this;
        vm.viewName = ko.observable(),
        vm.wzStep1 = ko.observable(),
        vm.wzStep2 = ko.observable(),
        vm.wzStep3 = ko.observable();

        vm.nextStep = function (model) {
            var currentView = vm.viewName();
            switch (currentView) {
                case 'register-step1':
                    var rawData = ko.mapping.toJS(model);
                    var dataSvc = new vnsf.ViewModelHelper('/');
                    var data = dataSvc.apiPost('api/account/register/validate1', rawData, function () {
                        alert("Done");
                        vm.viewName('register-step2');
                    }, function () {
                        alert("Failed");
                    });

                    break;
                case 'register-step2':
                    vm.viewName('register-step3');
                    break;
                default:
                    break;
            }
        },
        vm.prevStep = function (model) {
            var currentView = vm.viewName();
            switch (currentView) {
                case 'register-step2':
                    vm.viewName('register-step1');
                    break;
                case 'register-step3':
                    vm.viewName('register-step2');
                    break;
                default:
                    break;
            }
        },
        vm.createAccount = function () {
            var unmappedModel;
            var step1Unmapped = ko.mapping.toJS(wzStep1);

            unmappedModel = $.extend(unmappedModel, step1Unmapped);
        },
        vm.initialize = function () {
            vm.wzStep1(new vnsf.UserRegisterStep1());
            vm.wzStep2(new vnsf.UserRegisterStep2());
            vm.viewName('register-step1');
        };
        vm.initialize();
    };
    vn.Wizard = wizard;
})(window.vnsf);


