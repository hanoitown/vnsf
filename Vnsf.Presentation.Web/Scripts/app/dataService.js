window.vnsf = window.vnsf || {};
(function () {

    function dataService(path, settings) {
        this.baseUrl = "/";
        this.path = path;
        if (this.path.charAt(this.path.length - 1) !== '/') {
            this.path += "/";
        }
        this.noficiation = new v.Notification();
        this.settings = settings || {};
    };

    dataService.prototype = function () {
        var
            getErrorDetail = function (xhr) {
                if (xhr.responseJSON) {
                    return xhr.responseJSON.errors || xhr.responseJSON.exceptionMessage;
                } else {
                    return null;
                }
            },
            get = function (id) {
                //id = id || "";
                return ajax({
                    url: dataService.baseUrl + this.path + id,
                    type: 'GET'
                }).fail(function (xhr, status, error) {
                    this.nofication.showErrorMessage("Error Loading", getErrorDetail(xhr));
                    //showErrorMessage("Error Loading", getErrorDetail(xhr));
                    return xhr;
                });
            },
            put = function (data, id) {
                id = id || "";
                return ajax({
                    url: dataService.baseUrl + this.path + id,
                    type: 'PUT',
                    contentType: 'application/json',
                    data: JSON.stringify(data)
                }).then(
                    function (data, status, xhr) {
                        showSuccessMessage("Update Successful");
                        return xhr;
                    },
                    function (xhr, status, error) {
                        showErrorMessage("Error Updating", getErrorDetail(xhr));
                        return xhr;
                    });
            },
            deleteApp = function (id) {
                id = id || "";
                return ajax({
                    url: dataService.baseUrl + this.path + id,
                    type: 'DELETE'
                }).then(
                    function (data, status, xhr) {
                        showSuccessMessage("Delete Successful");
                        return xhr;
                    },
                    function (xhr, status, error) {
                        showErrorMessage("Error Deleting", getErrorDetail(xhr));
                        return xhr;
                    });
            },
            post = function (data, id) {
                id = id || "";
                return ajax({
                    url: dataService.baseUrl + this.path + id,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(data)
                }).then(
                    function (data, status, xhr) {
                        showSuccessMessage("Create Successful");
                        return xhr;
                    },
                    function (xhr, status, error) {
                        showErrorMessage("Error Creating", getErrorDetail(xhr));
                        return xhr;
                    });
            };
        return {
            get: get,
            post: post,
            deleteApp: deleteApp,
            put: put
        };
    }();
})(vnsf)