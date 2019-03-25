(function () {
    "use strict";

    angular
        .module("insurance")
        .factory("SeguroService", SeguroService);

    SeguroService.$inject = ["$http"];

    function SeguroService($http) {
        var service = {
            get: get,
            getAll: getAll,
            searchPlaca: searchPlaca,
            create: create,
            update: update,
            delete: del
        };
        return service;

        function searchPlaca(placa, successCallback, errorCallback) {
            $http.get("/api/seguro/searchPlaca/" + placa).then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

        function get(id, successCallback, errorCallback) {
            $http.get("/api/seguro/" + id).then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

        function getAll(successCallback, errorCallback) {
            $http.get("/api/seguro").then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

        function create(obj, successCallback, errorCallback) {
            $http.post("/api/seguro", obj).then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

        function update(obj, successCallback, errorCallback) {
            $http.put("/api/seguro", obj).then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

        function del(id, successCallback, errorCallback) {
            $http.delete("/api/seguro/" + id).then(function (resp) {
                successCallback(resp);
            }, function (resp) {
                errorCallback(resp);
            });
        }

    }
})();

