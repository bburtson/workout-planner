
(function () {
    "use strict";

    var animation = function () {

        return {
            fadeInShake: function (elementId) {
                $(elementId).fadeIn(400);
                $(elementId).effect({ effect: "bounce", easing: "swing", duration: 900 });
            },
        }
    };

    var module = angular.module('WorkoutPlanner');
    module.factory('animation', animation);

})();
