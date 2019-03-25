(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("uiText", uiText);

    uiText.$inject = [];

    function uiText() {
        var directive = {
            require: "ngModel",
            scope: {
                ngModel: "="
            },
            restrict: "A",
            link: link
        };

        return directive;

        function link(scope, element, attr, ctrl) {

            var updateView = function (val) {
                scope.$applyAsync(function () {
                    ctrl.$setViewValue(val || "");
                    ctrl.$render();
                });
            };

        }
    }

})();

(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("uiDecimal", uiDecimal);

    uiDecimal.$inject = [];

    function uiDecimal() {
        var directive = {
            require: "ngModel",
            scope: {
                ngModel: "="
            },
            restrict: "A",
            link: link
        };

        return directive;

        function link(scope, element, attr, ctrl) {

            var defaultValue = angular.isDefined(attr.start) ? attr.start : "0";
 
            var min = attr.min.length > 0 ? attr.min : undefined;
            var max = attr.max.length ? attr.max : undefined;

            attr.$set("ngTrim", "false");
            var first = true;
            var formatter = function (str, isNum) {
                str = String(Number(str || 0) / (isNum ? 1 : 100));
                str = (str === "0" ? "0.0" : str).split(".");
                str[1] = str[1] || "0";
                return str[0].replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.") + "," + (str[1].length === 1 ? str[1] + "0" : str[1]);
            }
            var updateView = function (val) {
                scope.$applyAsync(function () {
                    ctrl.$setViewValue(val || defaultValue);
                    ctrl.$render();
                });
            }
            var parseNumber = function (val) {

                var modelString = formatter(ctrl.$modelValue, true);
                var sign = {
                    pos: /[+]/.test(val),
                    neg: /[-]/.test(val)
                }
                sign.has = sign.pos || sign.neg;
                sign.both = sign.pos && sign.neg;
                var newVal;
                if (!val || sign.has && val.length === 1 || ctrl.$modelValue && Number(val) === 0) {
                    newVal = (!val || ctrl.$modelValue && Number() === 0 ? "" : val);
                    if ((ctrl.$modelValue !== newVal) || first) {
                        updateView(newVal);
                        first = false;
                    }

                    return "";
                }
                else {
                    var valString = String(val || "");
                    var newSign = (sign.both && ctrl.$modelValue >= 0 || !sign.both && sign.neg ? "-" : "");
                    newVal = valString.replace(/[^0-9]/g, "");
                    var viewVal = newSign + formatter(angular.copy(newVal));
                    if ((modelString !== valString) || first) {
                        updateView(viewVal);
                        first = false;
                    }

                    var number = (Number(newSign + newVal) / 100) || 0;

                    if (min !== undefined) {
                        
                        if (number < min) {
                            ctrl.$setValidity("min", false);
                        } else {
                            ctrl.$setValidity("min", true);
                        }
                    }

                    if (max !== undefined) {
                        if (number > max) {
                            ctrl.$setValidity("max", false);
                        } else {
                            ctrl.$setValidity("max", true);
                        }
                    }

                    return number;
                }
            }
            var formatNumber = function (val) {
                if (val) {
                    var str = String(val).split(".");
                    str[1] = str[1] || "0";
                    val = str[0] + "," + (str[1].length === 1 ? str[1] + "0" : str[1]);

                }
                return parseNumber(val);
            }

            ctrl.$parsers.push(parseNumber);
            ctrl.$formatters.push(formatNumber);
        }

    }

})();

(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("uiInteger", uiInteger);

    uiInteger.$inject = [];

    function uiInteger() {
        var directive = {
            require: "ngModel",
            scope: {
                ngModel: "="
            },
            restrict: "A",
            link: link
        };

        return directive;

        function link(scope, element, attr, ctrl) {

            var min = attr.min.length > 0 ? attr.min : undefined;
            var max = attr.max.length ? attr.max : undefined;
            var formatter = function (val) {
                if (val) {
                    var value = val + ""; //convert to string
                    var digits = value.replace(/[^0-9]/g, "");
                    return parseInt(digits);
                }
                return val;
            }
            var updateView = function (val) {
                scope.$applyAsync(function () {
                    ctrl.$setViewValue(val);
                    ctrl.$render();
                });
            };
            var parseNumber = function (val) {
                var modelString = formatter(val);
                updateView(modelString);

                if (min !== undefined) {

                    if (number < min) {
                        ctrl.$setValidity("min", false);
                    } else {
                        ctrl.$setValidity("min", true);
                    }
                }

                if (max !== undefined) {
                    if (number > max) {
                        ctrl.$setValidity("max", false);
                    } else {
                        ctrl.$setValidity("max", true);
                    }
                }

                return val;
            };
            var format = function (num) {
                return formatter(num);
            }

            ctrl.$parsers.push(parseNumber);
            ctrl.$formatters.push(format);


            var startValue = angular.isDefined(attr.start) ? attr.start : "";
            if (startValue.length > 0 && scope.ngModel === undefined) {
                parseNumber(startValue);
            }
        }

    }

})();

(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("uiDate", uiDate);

    uiDate.$inject = ["$filter"];

    function uiDate($filter) {
        var directive = {
            require: "ngModel",
            scope: {
                ngModel: "="
            },
            restrict: "A",
            link: link
        };

        return directive;

        function link(scope, element, attr, ctrl) {

            attr.$set("ngTrim", "false");

            var min = attr.min.length > 0 ? attr.min : undefined;
            var max = attr.max.length ? attr.max : undefined;


            var formatter = function (date) {

                if (date) {
                    date = date.replace(/[^0-9]+/g, "");
                    if (date.length > 2) {
                        date = date.substring(0, 2) + "/" + date.substring(2);
                    }
                    if (date.length > 5) {
                        date = date.substring(0, 5) + "/" + date.substring(5, 9);
                    }
                }
                return date;
            }
            var updateView = function (val) {
                scope.$applyAsync(function () {
                    ctrl.$setViewValue(val);
                    ctrl.$render();
                });
            };
            var parseDate = function (val) {
                var modelString = formatter(val);

                updateView(modelString);

                if (modelString.length === 10) {
                    var dateArray = modelString.split("/");
                    var date = new Date(dateArray[2], dateArray[1] - 1, dateArray[0]);
                    if (min !== undefined) {
                        var minArray = min.split("/");
                        if (minArray.length === 3) {
                            var minDate = new Date(minArray[2], minArray[1] - 1, minArray[0]);

                            if ((minDate instanceof Date)) {
                                if (minDate.getTime() > date.getTime()) {
                                    ctrl.$setValidity("min", false);
                                } else {
                                    ctrl.$setValidity("min", true);
                                }
                            }
                        }
                        
                    }

                    
                    return date;
                }

            };
            var format = function (date) {
                return $filter("date")(date, "dd/MM/yyyy");
            }

            ctrl.$parsers.push(parseDate);
            ctrl.$formatters.push(format);

            var startValue = angular.isDefined(attr.start) ? attr.start : "";
            if (startValue.length > 0 && scope.ngModel === undefined) {
                parseDate(startValue);
            }
        }

    }

})();


//(function () {
//    "use strict";

//    angular
//        .module("insurance")
//        .directive("uiSwitch", uiSwitch);

//    uiSwitch.$inject = [];

//    function uiSwitch() {
//        var directive = {
//            restrict: "E",
//            require: "ngModel",
//            template: "<input bs-switch>",
//            replace: true
//        };

//        return directive;
//    }

//})();