// ******* CONTROLLER: CalendarController
(function () {
    "use strict";

    var app = angular.module('WorkoutPlanner');
    app.controller('CalendarController', CalendarController);

    function CalendarController($rootScope, $scope, $location, calendarBuilder, planService) {

        var date = new Date();
        var monthNum = date.getMonth();
        var yearNum = date.getFullYear();

        $scope.calendarIsBusy = false;

        var onCalendarComplete = (calendar) => angular.copy(calendar, $scope.calendar);
        var onError = () => $scope.error = ""/*"Something went wrong when building your calendar"*/;

        var buildCalendar = function() {
            $scope.calendarIsBusy = true;
            calendarBuilder.build(date)
                .then(onCalendarComplete, onError)
                .finally(() => $scope.calendarIsBusy = false);
        };

        var setDateYearMonth = function () {
            date.setYear(yearNum);
            date.setMonth(monthNum);
        };

        !$scope.calendar.weeks ? buildCalendar() : null;

        $scope.decrementMonth = function () {
            monthNum--;
            if (monthNum < 1) {
                yearNum--;
                monthNum = 12;
            }
            setDateYearMonth();
            buildCalendar();
        };

        $scope.incrementMonth = function () {
            monthNum++;
            if (monthNum > 12) {
                yearNum++;
                monthNum = 1;
            }
            setDateYearMonth();
            buildCalendar();
        };

        $scope.goToPlan = function (calendarItem) {
            $rootScope.selectedCalendarItem = calendarItem;
            if (calendarItem.dayPlan.dayPlanId) {
                $rootScope.setCurrentPlan(calendarItem.dayPlan);
                var theDate = new Date(calendarItem.fullDate);
                $location.path('/dayplan/' + theDate.toISOString().substring(0, 10));
            }
            else {
                $("#createPlan").modal("toggle");
            }
        };

        var onPlanCreated = function(plan) {
            $rootScope.setCurrentPlan(plan);
            $("#createPlan").on("hidden.bs.modal", function() {
                $scope.goToPlan($rootScope.selectedCalendarItem);
                $scope.$apply();
            });
        };

        $scope.createNewPlan = function (newName) {
            var newModel = $rootScope.getCurrentPlan();
            newModel.name = newName;
  
            planService.createPlan(newModel)
                .then(onPlanCreated);
        };
    }
})();
