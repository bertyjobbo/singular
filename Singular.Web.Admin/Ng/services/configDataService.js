'use strict';

// config service
(function ($a) {

    $a.factory("configDataService", ["$http", function ($http) {

        if (!window.singletonCount) {
            window.singletonCount = 1;
        } else {
            window.singletonCount++;
        }

        if (window.singletonCount > 1) alert("THIS IS NOT A SINGLETON");


        return {

            getSectionsPromise: function () {

                return $http.get($a.getRootedUrl("singularapi/config/sections/"));
            },
            getFactoryPromise: function () {
                return $http.get($a.getRootedUrl("singularapi/config/factory/"));
            }
        };

    }]);

})(Singular.Application)