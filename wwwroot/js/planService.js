// ******** SERVICE: api plans
(function () {
    "use strict";

    var planService = function ($http) {
        var calendarItem = {};

        var createPlan = function (dayPlan) {
            return $http.post("/api/dayplan", dayPlan)
                .then(function (response) {
                    return response.data;
                });
        };

        var deletePlan = function (id) {
            return $http.delete("/api/dayplan/" + id)
                .then(function (response) {
                    return response.data;
                });
        };

        var updatePlan = function (dayPlan) {
            return $http.put("/api/dayplan", dayPlan)
                .then(function (response) {
                    return response.data;
                });
        };

        var createExcercise = function (excercise) {
            return $http.post("/api/dayplan/excercise/", excercise)
                .then(function (response) {
                    return response.data;
                });
        }


        var updateExcercise = function (excercise) {
            return $http.put("/api/dayplan/excercise/", excercise)
                .then(function (response) {

                    return response.data;
                });
        };


        var deleteExcercise = function (id) {
            return $http.post("/api/dayplan/excercise/" + id)
                .then(function (response) {
                    return response.data;

                });
        };

        var createMeal = function (meal) {
            return $http.post("/api/dayplan/meal/", meal)
                .then(function (response) {
                    return response.data;
                });
        };

        var updateMeal = function (meal) {
            return $http.put("/api/dayplan/meal/", meal)
                .then(function (response) {
                    return response.data;

                });
        };

        var deleteMeal = function (id) {
            return $http.post("/api/dayplan/meal/" + id)
                .then(function (response) {
                    return response.data;
                });

        };

        var getPlan = function (dateTime) {
            return $http.get("/api/dayplan/" + dateTime)
                .then(function (response) {
                    return response.data;
                });
        };

        return {
            createPlan: createPlan,
            updatePlan: updatePlan,
            getPlan: getPlan,
            deletePlan: deletePlan,


            createExcercise: createExcercise,
            updateExcercise: updateExcercise,
            deleteExcercise: deleteExcercise,

            createMeal: createMeal,
            updateMeal: updateMeal,
            deleteMeal: deleteMeal,


            getCurrentCalendarItem: function () {
                return calendarItem;
            },

            setCurrentCalendarItem: function (value) {
                calendarItem = value;
            }
        };
    };


    //declare below for definition (when returning promises)
    var module = angular.module('WorkoutPlanner');
    module.factory('planService', planService);

})();