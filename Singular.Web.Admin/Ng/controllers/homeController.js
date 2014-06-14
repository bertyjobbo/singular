'use strict';

// HOME CONTROLLER
(function ($a) {

    $a.controller("homeController", ["$scope", function ($scope) {

        $scope.actions = {
            
            index: function(id) {
                console.log("route id is " + id);
            }

        };

    }]);


})(Singular.Application)