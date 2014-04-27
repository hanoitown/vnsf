define('AccountLoginModel',
    ['ko'],
    function (ko) {
        var accountLoginModel = function() {
            var self = this;
            self.loginEmail = ko.observable("");
        };
    });