
/*
Jquery Plugin pluginTemplate 2.0
Copyright (c) 2014 ServiceLayer
pluginTemplate is released under the MIT License
http://www.servicelayer.no
*/
/*
This is a simple plugin template, it has no other function 
than to server as a starting point for plugin development
*/
(function ($) {

    //contructor
    $.fn.pluginTemplate = function (options) {

        // Public properties with defaults
        var set = $.extend({

            'numeric': 25,
            'boolean': false,
            'enum': 'static',
            'url': 'pluginTemplate/pluginTemplate_content.json'

        }, options);

        // Allow the plugin to be chainable
        return this.each(function () {

            var pluginTemplate_in = {
                pages: []
            };
            // If we want ajax to run asyncronously
            $.ajaxSetup({
                async: false
            });           

            // Extentions methods based on enumerator public property setting.
            if (set.enum == 'json') {
                $.getJSON(set.url,
                     function (json) {
                         pluginTemplate_in = $.extend({}, json);
                     }
                );
            }

            if (set.enum == 'static') {
                pluginTemplate_in = $.extend({}, pluginTemplate);
            }           

        });
    };

})(jQuery);

// TODO: Learn this to the limits