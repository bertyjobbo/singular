'use strict';

(function ($a) {

    // nav controller
    $a.controller("navController", ["$scope", "$http", function ($scope, $http) {
            
        // get data
        $http
            .get($a.getRootedUrl("singularapi/config/sections/"))
            .success(function (data) {
                $scope.navItems = data;
            });
        }
    ]);

})(Singular.Application)