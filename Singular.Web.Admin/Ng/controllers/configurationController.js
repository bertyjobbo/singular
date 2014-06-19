'use strict';

// config controller
(function($a) {

    $a.controller("configurationController", ["$scope","configDataService", function ($scope, configDataService) {

        configDataService.getFactoryPromise().then(function (promise) {
            $scope.factoryData = promise.data;
            console.log($scope.factoryData);
        });

    }]);

})(Singular.Application)