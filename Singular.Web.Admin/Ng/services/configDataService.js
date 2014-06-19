'use strict';

// config service
(function ($a) {

    $a.factory("configDataService", ["$http", "$q", "singularConfigurationFactoryData", function ($http, $q, singularConfigurationFactoryData) {

        if (!window.singletonCount) {
            window.singletonCount = 1;
        } else {
            window.singletonCount++;
        }

        if (window.singletonCount > 1) alert("THIS IS NOT A SINGLETON");


        return {

            getSingularConfigurationFactoryDataPromise: function () {

                // declare promise
                var deferred = $q.defer();

                // check data already exists
                if (singularConfigurationFactoryData) {

                    deferred.resolve(singularConfigurationFactoryData);
                    return deferred.promise;

                } else {

                    // get from service
                    $http
                        .get($a.getRootedUrl("singularapi/config/factory/"))
                        .success(function (data) {
                            singularConfigurationFactoryData = data;
                            deferred.resolve(data);
                        })
                        .error(function (data, status, headers, config) {
                            deferred.reject("Error: request returned status " + status);
                        });

                    return deferred.promise;
                }
            }
        };

    }]);

})(Singular.Application)