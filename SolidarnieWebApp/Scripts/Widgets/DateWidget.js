//tu będzie widget dla daty

$(function () {
    $.widget("custom.kruchydatepicker", {
        options: {
        },

        // The constructor
        _create: function () {
            this.element.datepicker(
                {
                    dateFormat: "yy-mm-dd",
                    buttonText: '',
                    showButtonPanel: true
                });
        },

        _destroy: function () {
        },
    });
});