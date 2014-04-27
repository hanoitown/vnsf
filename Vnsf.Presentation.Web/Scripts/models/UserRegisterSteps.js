(function(sf) {
    var userRegisterStep1 = function () {
        var vm = this;
        vm.email = ko.observable(),
        vm.password = ko.observable(),
        vm.passconfirm = ko.observable();
        vm.mobile = ko.observable();
    };
    sf.UserRegisterStep1 = userRegisterStep1;
})(window.vnsf);

(function(sf) {
    var userRegisterStep2 = function() {
        var vm = this;
        vm.firstName = ko.observable(),
        vm.lastName = ko.observable();
        vm.fullName = ko.computed(function() {
            return vm.firstName() + vm.lastName();
        });
    };
    sf.UserRegisterStep2 = userRegisterStep2;
})(window.vnsf);