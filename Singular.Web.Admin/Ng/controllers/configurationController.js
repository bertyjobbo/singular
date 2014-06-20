'use strict';

// config controller
(function ($a) {

    $a.controller("configurationController", ["$scope", "configDataService", function ($scope, configDataService) {

        $scope.actions = {

            index: function () {

                configDataService
                    .getSingularConfigurationFactoryDataPromise()
                    .then(function (data) {
                        $scope.factoryData = data;
                        console.log("scope.factoryData = ", $scope.factoryData);
                    });

            }

        }

        configDataService
            .getSingularConfigurationFactoryDataPromise()
            .then(function (data) {
                $scope.factoryData = data;
                console.log("scope.factoryData = ", $scope.factoryData);
            });


    }]);

})(Singular.Application)