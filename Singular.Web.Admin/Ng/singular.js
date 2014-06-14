'use strict';

// NAMESPACE
var Singular = {};

// APP
Singular.Application = angular.module("Singular.Application", ["ngRoute"]);

// APP CONFIG
(function ($a) {

    // helper to get root url
    $a.getRootedUrl = function (restOfUrl) {
        return (window.ROOT_URL + restOfUrl).replace("//", "/");
    }

    // route provider config
    $a.config(["$routeProvider", function ($routeProvider) {

        $a.configureRootForSgView($routeProvider);

    }]);

    // run
    $a.run(["$rootScope", function ($rootScope) {

        // set internal url method
        $rootScope.getSingularUrl = function (controller, action, id) {
            
            // get root
            var root = $a.getRootedUrl("");

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
        $rootScope.getRootedUrl = $a.getRootedUrl;

    }]);


    // ERROR HANDLING
    $a.factory("$exceptionHandler", ["$injector", function ($injector) {

        // Override error handling
        return function (exception, cause) {

            // log
            console.log("Exception", exception);
            console.log("Cause", cause);

            //// alert
            //alert("Error:\n" + (exception.message === undefined ? exception : exception.message) + "\n\nCause:\n" + cause);

            // redirect
            var lction = $injector.get("$location");
            if (lction) lction.path("/system/error/");
        };

    }]);


})(Singular.Application)