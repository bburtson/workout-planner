//  ****** MAIN MODULE: WorkoutPlanner

(function () {
    "use strict";


    var app = angular.module('WorkoutPlanner', ['ngRoute', 'AppComponents']);
    app.run(function ($rootScope) {

    

        $rootScope.calendar = {};
        $rootScope.selectedCalendarItem = {};

        $rootScope.getCurrentPlan = function () {
            return $rootScope.selectedCalendarItem.dayPlan;
        };

        $rootScope.setCurrentPlan = function (value) {
            $rootScope.selectedCalendarItem.dayPlan = value;
        };
    });
    app.config(function ($routeProvider, $locationProvider) {

        $routeProvider
            .when('/calendar', {
                templateUrl: '/views/calendar.html',
                controller: 'CalendarController'
            }).when('/dayplan/:plandate', {
                templateUrl: '/views/dayplan.html',
                controller: 'PlanController'

            }).otherwise({ redirectTo: '/calendar' });

    });

})();