(function () {
    "use strict";

    angular
        .module("insurance")
        .directive("ngDestroy", ngDestroy);

    ngDestroy.$inject = ["$document"];

    function ngDestroy($document) {
        var directive = {
            link: link
        };

        return directive;

        function link(scope, element, attr, ctrl) {
            var scopeExpression = attr.ngDestroy,
                onDocumentClick = function (event) {
                    var isChild = element.find(event.target).length > 0;

                    if (!isChild) {
                        scope.$apply(scopeExpression);
                    }
                };

            $document.on("click", onDocumentClick);

            element.on("$destroy", function () {
                $document.off("click", onDocumentClick);
            });
        }

    }

})();