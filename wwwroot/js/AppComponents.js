// *********   DIRECTIVE: calendarSegment
(function () {
    "use strict";

    var module = angular.module("AppComponents", [])
        .directive("calendarBlock", calendarBlock);

    function calendarBlock() {
        return {
            scope: {
                block: '=summaryFor'
            },

            restrict: 'E',
            templateUrl: "/views/calendarblock.html"
        };
    }

    module.directive("listComponent", listComponent);

    function listComponent() {
        return {
            scope: {
                viewIds: '=',
                sc: '=scAttr',
            },

            restrict: 'E',
            templateUrl: "/views/listcomponent.html"
        };
    }


    module.directive("planViewEdit", planViewEdit);

    function planViewEdit() {
        return {
            scope: false,

            restrict: 'A',
            templateUrl: "/views/viewedit.html"
        };
    }

    module.directive("mainWaitCursor", mainWaitCursor);

    function mainWaitCursor() {
        return {
            scope: false,

            restrict: 'E',
            templateUrl: "/views/mainwaitcursor.html"
        };
    }

    module.directive("planWaitCursor", planWaitCursor);

    function planWaitCursor() {
        return {
            scope: false,

            restrict: 'E',
            templateUrl: "/views/planWaitCursor.html"
        };
    }

    module.directive("btnWaitCursor", btnWaitCursor);

    function btnWaitCursor() {
        return {
            scope: false,

            restrict: 'E',
            templateUrl: "/views/btnwaitcursor.html"
        };
    }

})();