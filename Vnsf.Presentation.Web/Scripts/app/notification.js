(function () {

    function Notification() {
    }

    Notification.prototype = function() {
        var showMessage = function(msg, css, details) {
            var elem = $("#message");
            if (elem.is(":visible")) {
                elem.clearQueue().slideUp("fast", function() {
                    elem.removeClass("alert-success").removeClass("alert-error");
                    showMessage(msg, css, details);
                });
            } else {
                if (details) {
                    if (!Array.isArray(details)) {
                        details = [details];
                    }

                    msg += "<br><ul>";
                    details.forEach(function(detail) {
                        msg += "<li>" + detail + "</li>";
                    });
                    msg += "</ul>";
                }

                elem
                    .hide()
                    .addClass(css)
                    .html(msg)
                    .fadeIn("fast")
                    .delay(3000)
                    .fadeOut(function() {
                        $(this).html("").removeClass(css);
                    });
            }
        },
            showSuccessMessage = function(msg) {
                showMessage(msg, "alert-success");
            },
            showErrorMessage = function(msg, detail) {
                showMessage(msg, "alert-error", detail);
            };
        return {
            showSuccessMessage: showSuccessMessage,
            showErrorMessage: showErrorMessage
        }();
    };
})()