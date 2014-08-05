'use strict';

// NAMESPACE
var Singular = {};

// APP
Singular.Application = angular.module("Singular.Application", ["ngRoute","sgRoute","sgElements"]);

// APP CONFIG
(function (app) {

    // helper to get root url
    app.getRootedUrl = function (restOfUrl) {
        return (window.ROOT_URL + restOfUrl).replace("//", "/");
    }

    // configure sg routes
    app.config(['sgRouteConfigProvider', '$routeProvider', function (sgRouteConfigProvider, $routeProvider) {

        sgRouteConfigProvider
            .configureViewRequestMethod(function (controller, action) {
                //return "Ng/Views/" + controller + "/" + action + ".html";
               return app.getRootedUrl("singular/ngview/" + controller + "/" + action + "/");
            })
            .onPageNotFound("/system/pagenotfound/")
            .onError("/system/error/")
            .finalize($routeProvider);

    }]);

    // factory data
    app.constant("singularConfigurationFactoryData", undefined);

    // run
    app.run(["$rootScope", function ($rootScope) {

        // set internal url method
        $rootScope.getSingularUrl = function (controller, action, id) {
            
            // get root
            var root = app.getRootedUrl("");

            // check
            if (controller !== undefined && controller !== null && controller.toLowerCase() === "home" && action !== undefined && action !== null && action.toLowerCase() === "index")
                return root + "singular/#/";

            //
            return root + "singular/#/" +
                (controller === undefined ? "" : controller + "/")
                +
                (action === undefined ? "" : action + "/")
                +
                (id === undefined ? "" : id + "/");
        }

        // get external
        $rootScope.getRootedUrl = app.getRootedUrl;

    }]);


    //// ERROR HANDLING
    //app.factory("$exceptionHandler", ["$injector", function ($injector) {

    //    // Override error handling
    //    return function (exception, cause) {

    //        // log
    //        console.log("Exception", exception);
    //        console.log("Cause", cause);

    //        //// alert
    //        //alert("Error:\n" + (exception.message === undefined ? exception : exception.message) + "\n\nCause:\n" + cause);

    //        // redirect
    //        var lction = $injector.get("$location");
    //        if (lction) lction.path("/system/error/");
    //    };

    //}]);


})(Singular.Application)