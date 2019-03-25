(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("uiModal", uiModal);

    function uiModal() {
       
        var directive = {
            templateUrl: "../wwwroot/view/uiModal.html",
            replace: true,
            scope: {
                title: "@",
                callbackOk: "&",
                name: "@",
                modalClass: "@"
            },
            transclude: true,
            link: link,
            restrict: "EA"
        };

        return directive;

        function link(scope, element, attrs, ctrl) {
            scope.btnOkText = angular.isDefined(attrs.btnOkText) ? attrs.btnOkText : "Salvar";
        }

    }

})();