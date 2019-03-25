(function () {
    "use strict";

    angular
        .module("insurance")
        .factory("ProdutoTipoService", ProdutoTipoService);

    ProdutoTipoService.$inject = ["$http"];

    function ProdutoTipoService($http) {
        var service = {
            get: get,
            getAll: getAll
        };
        return service;

        function get(id, successCallback, errorCallback) {
            $http.get("/api/produtotipo/" + id).then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

        function getAll(successCallback, errorCallback) {
            $http.get("/api/produtotipo").then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

    

    }
})();

