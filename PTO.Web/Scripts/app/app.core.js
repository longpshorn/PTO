var app = {
    __namespace: true,

    root: $('#root').val(),

    log: function (msg, force) {
        if (false || force) {
            if (!window.console) {
                window.console = { log: function () { } };
            }
            console.log(msg);
        }
    },

    init: function (context) {
        app.log('core init start');

        $.validator.unobtrusive.parse(context);

        app.log('core init end');
    },

    finalize: function (context) {
        app.log('core finalize start');

        app.log('core finalize end');
    }
};