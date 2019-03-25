(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("uiInput", ['$log', '$compile', function ($log, $compile) {

            var uniqueId = 0;
            var directive = {
                templateUrl: "../wwwroot/view/uiInput.html",
                replace: true,
                scope: {
                    title: "@",
                    ngModel: "=",
                    selectOnOpen: "&",
                    selectOnClose: "&",
                    placeholder: "@",
                    type: "@",
                    start: "@",
                    onText: "@",
                    offText: "@",
                    helper: "@"
                },
                transclude: true,
                require: ["^form", "ngModel"],
                link: link,
                restrict: "EA"
            };

            return directive;

            function link(scope, element, attrs, ctrl) {
                scope.form = ctrl[0];
                scope.uniqueId = "input" + scope.$id + uniqueId++;
                scope.type = angular.isDefined(scope.type) ? scope.type : "text";
                scope.required = angular.isDefined(attrs.required) ? true : false;
                scope.minlength = angular.isDefined(attrs.minlength) ? attrs.minlength : "";
                scope.maxlength = angular.isDefined(attrs.maxlength) ? attrs.maxlength : "";
                scope.min = angular.isDefined(attrs.min) ? attrs.min : "";
                scope.max = angular.isDefined(attrs.max) ? attrs.max : "";
                scope.class = angular.isDefined(attrs.class) ? attrs.class : "col-md-12";

                scope.minus = function () {
                    if (scope.ngModel === undefined) {
                        scope.ngModel = 1;
                    } else {
                        if (scope.ngModel > 0)
                            scope.ngModel -= 1;
                    }
                }

                scope.plus = function () {
                    if (scope.ngModel === undefined) {
                        scope.ngModel = 1;
                    } else {
                        scope.ngModel += 1;
                    }
                }

                if (attrs.type === "images") {
                    scope.ngModel = [];
                }

                scope.removeImage = function (index) {
                    scope.ngModel.splice(index, 1);
                }

                function refreshProgress(val) {
                    scope.progress = val;
                }
                function setModel(obj) {
                    scope.ngModel = scope.ngModel.concat(obj);
                }
                //element.replaceWith($compile(element)(scope));
            }

        }]);

})();