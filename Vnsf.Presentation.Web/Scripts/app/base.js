
window.vnsf = window.vnsf || {};

(function (cr) {
    var initialId;
    cr.initialId = initialId;

    var initialState;
    cr.initialState = initialState;
    var rootPath = "/";
    cr.rootPath = rootPath;
    var mustEqual = function (val, other) {
        return val == other();
    };
    cr.mustEqual = mustEqual;
}(window.vnsf));

(function (cr) {
    var viewModelHelper = function (rootPath, uri) {

        this.rootPath = rootPath;
        this.uri = uri;
    };
    viewModelHelper.prototype = function () {
        var
            statePopped = false,
            stateInfo = {},
            isLoading = ko.observable(false),
            modelIsValid = ko.observable(true),
            modelErrors = ko.observableArray(),
            apiGet = function (uri, data, success, failure, always) {
                isLoading(true);
                modelIsValid(true);
                $.get(vnsf.rootPath + uri, data)
                    .done(success)
                    .fail(function (result) {
                        alert("Fail");
                        if (failure == null) {
                            if (result.status != 400)
                                modelErrors([result.status + ':' + result.statusText + ' - ' + result.responseText]);
                            else
                                modelErrors(JSON.parse(result.responseText));
                            modelIsValid(false);
                        } else
                            failure(result);
                    })
                    .always(function () {
                        if (always == null)
                            isLoading(false);
                        else
                            always();
                    });
            },
            apiPost = function (uri, data, success, failure, always) {
                isLoading(true);
                modelIsValid(true);
                $.post(vnsf.rootPath + uri, data)
                    .done(success)
                    .fail(function (result) {
                        if (failure == null) {
                            if (result.status != 400)
                                modelErrors([result.status + ':' + result.statusText + ' - ' + result.responseText]);
                            else
                                modelErrors(JSON.parse(result.responseText));
                            modelIsValid(false);
                        } else
                            failure(result);
                    })
                    .always(function () {
                        if (always == null)
                            isLoading(false);
                        else
                            always();
                    });
            },
            pushUrlState = function (code, title, id, url) {
                stateInfo = { State: { Code: code, Id: id }, Title: title, Url: NAFOSTED.rootPath + url };
            },
            handleUrlState = function (initialState) {
                if (!statePopped) {
                    if (initialState != '') {
                        history.replaceState(stateInfo.State, stateInfo.Title, stateInfo.Url);
                        // we're past the initial nav state so from here on everything should push
                        initialState = '';
                    } else {
                        history.pushState(stateInfo.State, stateInfo.Title, stateInfo.Url);
                    }
                } else
                    statePopped = false; // only actual popping of state should set this to true

                return initialState;
            };
        return {
            apiGet: apiGet,
            apiPost: apiPost,
            pushUrlState: pushUrlState,
            handleUrlState: handleUrlState
        };
    }();
    cr.ViewModelHelper = viewModelHelper;
}(window.vnsf));

ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        //initialize datepicker with some optional options
        var options = allBindingsAccessor().datepickerOptions || {};
        $(element).datepicker(options);

        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            var newDate = $(element).datepicker("getDate");
            // newDate format is 2013-01-11T06:11:00.000Z
            observable(moment(newDate).format('MM/DD/YYYY'));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).datepicker("destroy");
        });

    },
    // get the value from the viewmodel and format it for display
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var date = moment(value);
        current = $(element).datepicker("getDate");

        if (value != null) {
            if (value - current !== 0) {
                var date = moment(value);
                $(element).val(date.format("L"));
            }
        }
    }
}

ko.bindingHandlers.loadingWhen = {
    // any ViewModel using this extension needs a property called isLoading
    // the div tag to contain the loaded content uses a data-bind="loadingWhen: isLoading"
    init: function (element) {
        var
            $element = $(element),
            currentPosition = $element.css("position")
        $loader = $("<div>").addClass("loading-loader").hide();

        //add the loader
        $element.append($loader);

        //make sure that we can absolutely position the loader against the original element
        if (currentPosition == "auto" || currentPosition == "static")
            $element.css("position", "relative");

        //center the loader
        $loader.css({
            position: "absolute",
            top: "50%",
            left: "50%",
            "margin-left": -($loader.width() / 2) + "px",
            "margin-top": -($loader.height() / 2) + "px"
        });
    },
    update: function (element, valueAccessor) {
        var isLoading = ko.utils.unwrapObservable(valueAccessor()),
            $element = $(element),
            $childrenToHide = $element.children(":not(div.loading-loader)"),
            $loader = $element.find("div.loading-loader");

        if (isLoading) {
            $childrenToHide.css("visibility", "hidden").attr("disabled", "disabled");
            $loader.show();
        }
        else {
            $loader.fadeOut("fast");
            $childrenToHide.css("visibility", "visible").removeAttr("disabled");
        }
    }
};

ko.extenders.numeric = function (target, precision) {
    //create a writeable computed observable to intercept writes to our observable
    var result = ko.computed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target(),
                roundingMultiplier = Math.pow(10, precision),
                newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue),
                valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            //only write if it changed
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
                //if the rounded value is the same, but a different value was written, force a notification for the current field
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    });

    //initialize with current value to make sure it is rounded appropriately
    result(target());

    //return the new computed observable
    return result;
};

ko.bindingHandlers.date = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        // TODO: this should be able to support foreign date formats
        var jsonDate = valueAccessor(); // 2013-02-19T00:00:00
        var ret = $.datepicker.formatDate('mm-dd-yy', new Date(jsonDate()));
        element.innerHTML = ret;
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
    }
};
