$(function () {
    var svc = new Vnsf.Service("api/users/login");

    function accountLoginModel(data) {
        var vm = this;
        vm.isNew = ko.observable(!data);
        data = data || {
            userEmail: "",
            password: "",
            rememberMe: false,
            returnUrl:""
        };
    };

    accountLoginModel.prototype.login = function () {
        var vm = this;
        var data = ko.mapping.fromJS(vm);
        svc.post(data);
    };

});