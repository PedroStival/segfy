(function () {
    "use strict";

    angular.module("insurance").requires.push("ngMessages");
    angular.module("insurance").requires.push("angular.filter");
    angular.module("insurance").requires.push("mdColorMenu");
    angular
        .module("insurance")
        .controller("seguroCadastrarCtrl", seguroCadastrarCtrl);

    seguroCadastrarCtrl.$inject = ["$scope", "$window", "$element", "$mdSelect", "toastr", "SeguroService", "ProdutoTipoService"];

    function seguroCadastrarCtrl($scope, $window, $element, $mdSelect, toastr, SeguroService, ProdutoTipoService) {
        $scope.seguro = {};
        $scope.seguro.produto = {};
        $scope.produtoTipos = [];
        $scope.edit = false;
        var id = getParameterByName('id');

        if (id !== null) {
            $scope.edit = true;

            SeguroService.get(id, function (resp) {
                $scope.seguro = resp.data;
            },
                function (resp) {
                    toastr.error("Não foi encontrado esse seguro", "Calma, houve um problema");
                });
        }

        $scope.loadProdutoTipos = function () {
            ProdutoTipoService.getAll(function (resp) {
                $scope.produtoTipos = resp.data;
            },
                function (resp) {
                    toastr.error(resp.data.message, "Calma, houve um problema");
                });
        };

        $scope.finish = function () {

            if ($scope.edit) {
                SeguroService.update($scope.seguro, function (resp) {
                    toastr.success("Seguro editado com sucesso", "Parabéns");
                    $scope.seguro = {};
                    $scope.seguro.produto = {};
                    $scope.formSeguro.$setPristine();
                    $scope.formSeguro.$setUntouched();
                    setTimeout(function () {
                        window.location.href = "/wwwroot/seguros.html";
                    }, 1000);
                },
                    function (resp) {
                        toastr.error(resp.data.message, "Calma, houve um problema");
                    });
            } else {
                SeguroService.create($scope.seguro, function (resp) {
                    toastr.success("Seguro cadastrado com sucesso", "Parabéns");
                    $scope.seguro = {};
                    $scope.seguro.produto = {};
                    $scope.formSeguro.$setPristine();
                    $scope.formSeguro.$setUntouched();
                },
                    function (resp) {
                        toastr.error(resp.data.message, "Calma, houve um problema");
                    });
            }
           
        };

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, '\\$&');
            var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, ' '));
        }

        $scope.loadProdutoTipos();

    }

})();
