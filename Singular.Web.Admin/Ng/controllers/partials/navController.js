'use strict';

(function($a) {
    
    // nav controller
    $a.controller("navController", ["$scope", function($scope) {

            
            $scope.navItems = [
                { Title: "Test1" },
                { Title: "Test2" },
                { Title: "Test3" }
            ];

        }
    ]);

})(Singular.Application)