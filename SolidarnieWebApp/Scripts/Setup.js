(function ($) {     /// <param name="$" type="jQuery" />
    'use strict';
    /*global jQuery*/
    var widgets = [];
    $.piatka = $.piatka || {};

    function setupWidgets(container) {
        var $container = $(container || 'body');

        $container.find('[data-toggle="kruchydatepicker"]').kruchydatepicker();
    }

    $.piatka.setupWidgets = function () {
        setupWidgets('body');
    };

    $(function () {
        $.piatka.setupWidgets();
    });

}(jQuery));