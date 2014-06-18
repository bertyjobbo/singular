'use strict';

(function ($a) {

    $a.controller("navController", ["$scope", "configDataService", function ($scope, configDataService) {

        // get nav items
        configDataService
            .getSectionsPromise()
            .then(function (promise) {
                $scope.navItems = promise.data;
            });

    }]);

})(Singular.Application);

