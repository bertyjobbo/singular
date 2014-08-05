'use strict';

// config controller
(function (app) {

    app.controller("configurationController", ["$scope", "configDataService", function ($scope, configDataService) {

        $scope.indexAction = function () {

            configDataService
                .getSingularConfigurationFactoryDataPromise()
                .then(function (data) {
                    $scope.factoryData = data;
                    console.log("scope.factoryData = ", $scope.factoryData);
                });

        }

        configDataService
            .getSingularConfigurationFactoryDataPromise()
            .then(function (data) {
                $scope.factoryData = data;
                console.log("scope.factoryData = ", $scope.factoryData);
            });


    }]);

})(Singular.Application)