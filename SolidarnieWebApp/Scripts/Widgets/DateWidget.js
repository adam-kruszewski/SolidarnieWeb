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
            this.element.val(this.element.val().substring(0, 10));
        },

        _destroy: function () {
        },
    });
});