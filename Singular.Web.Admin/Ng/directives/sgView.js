'use strict';

// DIRECTIVE sg-view
(function ($a) {

    // add routing
    $a.configureRootForSgView = function($routeProvider) {

        // CONSTANT ROUTE
        var constRoute = {
            //templateUrl: $a.getRootedUrl("Singular/NgView/partials/_router/")
        };

        // ROUTE CONFIG
        $routeProvider
            .when('/', constRoute)
            .when('/:sgroute_controller/', constRoute)
            .when('/:sgroute_controller/:sgroute_action/', constRoute)
            .when('/:sgroute_controller/:sgroute_action/:sgroute_id/', constRoute)
            .otherwise({
                redirectTo: '/system/pagenotfound/'
            });
    }

    // add directive
    $a.directive("sgView", ["$rootScope", "$compile", "$location", "$route", "$templateCache", "$http", function ($rootScope, $compile, $location, $route, $templateCache, $http) {

        // compile function
        var compileTheView = function (element, scope, htmlToAdd) {

            // html
            var theFinalHtml = "<div ng-controller='" + $rootScope.sgroute.controller + "Controller" +
                "' ng-init='actions." + $rootScope.sgroute.action + "(sgroute.id)" + "'>" +
                htmlToAdd +
                "</div>";

            // compiled
            var compiled = $compile(theFinalHtml)(scope);

            // compile
            element.html("");
            element.append(compiled);

        }

        return {

            restrict: "A",
            link: function (scope, element, attrs) {

                // add props to root scope
                $rootScope.sgroute = {
                    controller: undefined,
                    action: undefined,
                    id: undefined,
                    view: undefined
                }

                // add listener
                scope.$on("$routeChangeSuccess", function (ev, routeData) {
                    
                    // check route data for redirects etc
                    if (
                        $route.current !== undefined &&
                        (routeData.redirectTo === undefined || routeData.redirectTo === null || routeData.redirectTo === "")
                        ) {

                        // get route data
                        $rootScope.sgroute.controller = routeData.pathParams.sgroute_controller === undefined ? "home" : routeData.pathParams.sgroute_controller;

                        $rootScope.sgroute.action = routeData.pathParams.sgroute_action === undefined ? "index" : routeData.pathParams.sgroute_action;

                        $rootScope.sgroute.id = routeData.pathParams.sgroute_id;

                        $rootScope.sgroute.view = $a.getRootedUrl("Singular/NgView/" + $rootScope.sgroute.controller + "/" + $rootScope.sgroute.action + "/");

                        // set view
                        $route.current.templateUrl = $rootScope.sgroute.view;

                        // get from cache
                        var cachedTemplate = $templateCache.get($route.current.templateUrl);

                        // check 
                        if (cachedTemplate === undefined) {

                            // get
                            $http({ method: 'get', url: $route.current.templateUrl })
                                .success(function (data) {

                                    // put in cache
                                    $templateCache.put($route.current.templateUrl, data);

                                    // compile
                                    compileTheView(element, scope, data);
                                })
                                .error(function (data, status, headers, config) {

                                    if ($location.$$path !== "/system/pagenotfound" || $location.$$path !== "/system/pagenotfound/")
                                        $location.path("/system/pagenotfound/");
                                });

                        } else {

                            // compile cached
                            compileTheView(element, scope, cachedTemplate);
                        }
                    }

                });
            }

        }
    }]);


})(Singular.Application)