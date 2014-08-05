'use strict';

(function ($a) {

    $a.controller("headerController", ["$scope", "$location", "configDataService", function ($scope, $location, configDataService) {

        configDataService
            .getSingularConfigurationFactoryDataPromise()
            .then(function (data) {
                $scope.navItems = data.Sections;
            });

        $scope.go = function (e, url) {
            e.preventDefault();
            $scope.sgnavopen = false;
            window.location = url;
        };

    }]);

})(Singular.Application);

