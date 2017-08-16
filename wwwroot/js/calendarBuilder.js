//      **SERVICE:  calendarBuilder
(function () {
    "use strict";

    var calendarBuilder = function ($http) {

        var build = function (date) {
            
            return $http.get("/api/calendar/" + date.toISOString())
                .then(function (response) {
                    return response.data;
                });
        };
        return {
            build: build
        }
    };

    //declare below for definition (when returning promises)
    var module = angular.module('WorkoutPlanner');
    module.factory('calendarBuilder', calendarBuilder);
})();

