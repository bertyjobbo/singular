'use strict';

(function ($a) {

    $a.controller("navController", ["$scope", "configDataService", function ($scope, configDataService) {

        configDataService
            .getSingularConfigurationFactoryDataPromise()
            .then(function (data) {
                $scope.navItems = data.Sections;
            });

    }]);

})(Singular.Application);

