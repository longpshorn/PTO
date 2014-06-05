// HTML5 Dom-Ready Execution Utility
util = {
    init: function (context) {
        var classNames = $('body')[0].getAttribute('id').split('-'),
            controller = classNames[0],
            action = classNames[1];

        util.exec('core', 'init', context);
        if (controller) {
            util.exec(controller, 'init', context);
        }
        if (action) {
            util.exec(controller, action, context);
        }
        if (controller) {
            util.exec(controller, 'finalize', context);
        }
        util.exec('core', 'finalize', context);
    },

    exec: function (controller, action, context) {
        // set the namespace to the core project object
        var ns = app;

        // if the action is not passed, use init as the default,
        // otherwise,
        // use the action passed.
        action = (action === undefined) ? 'init' : action;

        // if the context isn't passed or if the action is init or finalize,
        // the context should be the entire document,
        // otherwise,
        // restrict the context to the passed context or
        // to the section that has the id of #@controller-@action
        context = (context !== undefined && context !== null)
            ? $(context)
            : $(document);

        // if we have a value for controller and the controller is contained within the namespace object
        // and the namespace has an object and method that is a function,
        // call that method.
        if (controller !== '' && ns[controller] && typeof ns[controller][action] === 'function') {
            ns[controller][action](context);
        }
    }
};

// document ready
$(function () {
    util.init();
});