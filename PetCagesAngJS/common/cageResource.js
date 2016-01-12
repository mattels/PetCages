(function() {
    "use strict";

        angular
            .module("common.services")
            .factory("cageResource", ["$resource", "appSettings", cageResource]);

        function cageResource($resource, appSettings) {
            return $resource(appSettings.serverPath + "api/cages");
        }
    }()
);