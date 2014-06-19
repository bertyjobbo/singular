'use strict';

// config controller
(function($a) {

    $a.controller("configurationController", ["$scope","configDataService", function ($scope, configDataService) {

        configDataService
            .getSingularConfigurationFactoryDataPromise()
            .then(function (data) {
                $scope.factoryData = data;
                console.log("scope.factoryData = ", $scope.factoryData);
            });
        

    }]);

})(Singular.Application)