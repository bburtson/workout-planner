//   ********* CONTROLLER: PlanController
(function () {
    "use strict";

    var app = angular.module("WorkoutPlanner");
    app.controller("PlanController", PlanController);

    function PlanController($rootScope, $scope, $routeParams, $http, $location, planService) {
        $scope.excerciseOptions = ["None", "Repetitions", "Timed"];
        $scope.mealOptions = ["None", "Snack", "Meal"];

        var currentPlanDateTime = new Date($routeParams.plandate);
        
        $scope.plandate = currentPlanDateTime.toUTCString().split(" ").splice(0, 4).join(" ");

        $scope.plan = $rootScope.getCurrentPlan();
        if ($scope.plan) {
            var planDateTime = new Date($scope.plan.dateTime).toString();
            var planDate = new Date($scope.plandate).toString();
            if (planDateTime !== planDate) {
                $scope.plan = null;
            }
        }


        $scope.planServiceIsBusy = false;

        var onGetPlan = function (plan) {
            $scope.plan = {};
            angular.copy(plan, $scope.plan);
        };

        var onGetError = function(error) {
            if(error.status === 404) $("#unRoutedCreatePlan").modal("toggle");
        };

        $scope.createPlan = function (newPlanName, plandate) {
            planService.createPlan({
                name: newPlanName,
                dateTime: plandate
            }).then(function (plan) {
                $scope.plan = {};
                angular.copy(plan, $scope.plan);
                $rootScope.calendar.weeks = "";
            });
        };

        var getPlan = function () {
            $scope.planServiceIsBusy = true;
            planService.getPlan($scope.plandate)
                .then(onGetPlan, onGetError)
                .finally(() => $scope.planServiceIsBusy = false);
        };

        $scope.plan ? null : getPlan();
  
        var onPlanDeleted = function () {
            $scope.plan.dayPlanId = 0;
            $scope.setCurrentPlan($scope.plan);
            $('#confirmDeleteDialogue').on('hidden.bs.modal', function () {
                $scope.$apply(() => $location.path('/main'));
            });
        };

        var onExcerciseCreated = (newExcercise) => $scope.plan.excercises.push(newExcercise);

        var onMealCreated = (newMeal) => $scope.plan.meals.push(newMeal);

        $scope.updateName = function (name) {
            $scope.plan.name = name;
            planService.updatePlan($scope.plan);
        };

        $scope.setExcerciseFormData = function (excercise) {
            $scope.excercise = {};
            excercise ? $scope.excercise = excercise : $scope.setDefaults();
        };

        $scope.setMealFormData = function (meal) {
            $scope.meal = {};
            meal ? $scope.meal = meal : $scope.setDefaults();
        };

        $scope.submitExcercise = function (excercise) {
            excercise.excerciseId ?
                planService.updateExcercise(excercise):
                planService.createExcercise(excercise).then(onExcerciseCreated);
        };

        $scope.submitMeal = function (meal) {
            meal.mealId ?
                planService.updateMeal(meal):
                planService.createMeal(meal).then(onMealCreated);
        };

        $scope.flagPlanForDelete = function () {
            $scope.flaggedItem = $scope.plan;
            $scope.removeItem = (item) => $scope.removePlan(item);
        };

        $scope.flagExcerciseForDelete = function (index) {
            $scope.flaggedItem = $scope.plan.excercises[index];
            $scope.flaggedItem.index = index;
            $scope.removeItem = (item) => $scope.removeExcercise(item);
        };

        $scope.flagMealForDelete = function (index) {
            $scope.flaggedItem = $scope.plan.meals[index];
            $scope.flaggedItem.index = index;
            $scope.removeItem = (item) => $scope.removeMeal(item);
        };

        $scope.removePlan = function (flaggedItem) {
            planService.deletePlan(flaggedItem.dayPlanId)
                .then(onPlanDeleted);
        };

        $scope.removeExcercise = function (flaggedItem) {
            $scope.plan.excercises.splice(flaggedItem.index, 1);
            planService.deleteExcercise(flaggedItem.excerciseId);
        };

        $scope.removeMeal = function (flaggedItem) {
                $scope.plan.meals.splice(flaggedItem.index, 1);
                planService.deleteMeal(flaggedItem.mealId);
        };

        $scope.setDefaults = function () {
            $scope.excercise.trackingOption = $scope.excerciseOptions[0];
            $scope.meal.mealOption = $scope.mealOptions[0];
            $scope.meal.dayPlanId = $scope.plan.dayPlanId;
            $scope.excercise.dayPlanId = $scope.plan.dayPlanId;
        };

    }

})();