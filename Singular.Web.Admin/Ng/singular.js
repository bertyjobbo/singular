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

    // route provider
    $a.config(["$routeProvider", function ($routeProvider) {

        // home
        $routeProvider.when("/", { templateUrl: $a.getRootedUrl("Singular/NgView/home/index/") });

        // else
        $routeProvider.otherwise({ redirectTo: "/system/pagenotfound/" });

    }]);

    // run
    $a.run(["$rootScope", function ($rootScope) {

        // set internal url method
        $rootScope.getSingularUrl = function (controller, action, id) {

            // check
            if (controller === undefined) controller = "home";
            if (action === undefined) action = "index";

            // get root
            var root = $a.getRootedUrl("");

            //
            return root + "singular/#/" + controller + "/" + action + "/" + (id === undefined ? "" : id + "/");
        }

        // get external
        $rootScope.getRootedUrl = $a.getRootedUrl;

    }]);



})(Singular.Application)