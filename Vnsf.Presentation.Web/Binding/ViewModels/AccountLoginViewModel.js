define('AccountLoginViewModel', ['ko'],
    function (ko) {
        var accountModel = window.AccountLoginModel(),
            login = function() {
            };
        return {
            accountModel: accountModel,
            login: login
        };
    }
);